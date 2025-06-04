using System;
using System.Data.SQLite;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace трекер_привычек
{
    public partial class Form2 : Form

    {
        private string _connectionString;

        public Form2()
        {
            InitializeComponent();
            _connectionString = "Data Source=C:\\Users\\liza1\\OneDrive\\Рабочий стол\\habits.db";
            InitializeDatabasePath();
            CreateDatabaseIfNotExists();
        }

        private void InitializeDatabasePath()
        {
            string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string dbFilePath = Path.Combine(desktopPath, "habits.db");
            _connectionString = $"Data Source={dbFilePath};Version=3;";
        }
        private void CreateDatabaseIfNotExists()
        {
            try
            {
                using (var connection = new SQLiteConnection(_connectionString))
                {
                    connection.Open();

                    // Включение внешних ключей
                    new SQLiteCommand("PRAGMA foreign_keys = ON", connection).ExecuteNonQuery();

                    // Таблица привычек
                    string createHabitsTableQuery = @"
                CREATE TABLE IF NOT EXISTS habits (
                    id INTEGER PRIMARY KEY AUTOINCREMENT,
                    habit TEXT NOT NULL UNIQUE,
                    created_at TEXT DEFAULT CURRENT_TIMESTAMP
                );";
                    new SQLiteCommand(createHabitsTableQuery, connection).ExecuteNonQuery();

                    // Таблица выполненных привычек
                    string createCompletedHabitsTableQuery = @"
                CREATE TABLE IF NOT EXISTS completed_habits (
                    id INTEGER PRIMARY KEY AUTOINCREMENT,
                    habit TEXT NOT NULL,
                    completion_date TEXT NOT NULL,
                    FOREIGN KEY(habit) REFERENCES habits(habit) ON DELETE CASCADE,
                    UNIQUE(habit, completion_date)
                );";
                    new SQLiteCommand(createCompletedHabitsTableQuery, connection).ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при создании БД: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private bool IsValidHabitInput(string input)
        {
            return Regex.IsMatch(input, @"^[a-zA-Zа-яА-ЯёЁ]{2,}(?:[ '-][a-zA-Zа-яА-ЯёЁ]+)*$");
        }

        private void btnAddHabit_Click(object sender, EventArgs e)
        {
            try
            {
                string habit = txtHabit.Text.Trim();

                if (string.IsNullOrWhiteSpace(habit))
                {
                    MessageBox.Show("Пожалуйста, введите привычку!", "Ошибка",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (!IsValidHabitInput(habit))
                {
                    MessageBox.Show("Привычка должна содержать только буквы и пробелы!\nМинимум 2 символа.",
                        "Некорректный ввод", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                using (var connection = new SQLiteConnection(_connectionString))
                {
                    connection.Open();

                    string checkQuery = "SELECT COUNT(*) FROM habits WHERE habit = @habit";
                    var checkCmd = new SQLiteCommand(checkQuery, connection);
                    checkCmd.Parameters.AddWithValue("@habit", habit);
                    int exists = Convert.ToInt32(checkCmd.ExecuteScalar());

                    if (exists > 0)
                    {
                        MessageBox.Show("Такая привычка уже существует!", "Предупреждение",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }

                    string insertQuery = "INSERT INTO habits (habit) VALUES (@habit)";
                    var insertCmd = new SQLiteCommand(insertQuery, connection);
                    insertCmd.Parameters.AddWithValue("@habit", habit);
                    insertCmd.ExecuteNonQuery();

                    MessageBox.Show("Привычка успешно добавлена!", "Успех",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtHabit.Clear();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnGoToForm3_Click(object sender, EventArgs e)
        {
            Form3 form3 = new Form3(_connectionString);
            form3.Show();
            this.Hide();
        }

        private void btnGoToForm5_Click_1(object sender, EventArgs e)
        {
            Form5 form5 = new Form5(_connectionString, this);
            form5.Show();
            this.Hide();
        }

        private void txtHabit_TextChanged(object sender, EventArgs e)
        {
            string trimmed = txtHabit.Text.TrimStart();
            if (txtHabit.Text != trimmed)
            {
                txtHabit.Text = trimmed;
                txtHabit.SelectionStart = trimmed.Length;
            }
        }
    }
}

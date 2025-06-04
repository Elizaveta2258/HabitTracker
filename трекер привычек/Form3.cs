using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Drawing;
using System.Windows.Forms;

namespace трекер_привычек
{
    public partial class Form3 : Form
    {
        private string _connectionString;
        private DateTime _selectedDate;

        public Form3(string connectionString)
        {
            InitializeComponent();
            _connectionString = connectionString;
            _selectedDate = DateTime.Today;

            CreateDatabaseTables();
            InitializeCalendar();
            LoadHabitsForSelectedDate();
        }

        private void InitializeCalendar()
        {
            monthCalendar1.MaxDate = DateTime.Today;

            monthCalendar1.DateSelected += (s, e) =>
            {
                _selectedDate = monthCalendar1.SelectionStart;
                LoadHabitsForSelectedDate();
            };
        }

        private void CreateDatabaseTables()
        {
            try
            {
                using (var connection = new SQLiteConnection(_connectionString))
                {
                    connection.Open();

                    string enableForeignKeys = "PRAGMA foreign_keys = ON";
                    using (var pragmaCmd = new SQLiteCommand(enableForeignKeys, connection))
                        pragmaCmd.ExecuteNonQuery();

                    string createHabitsTable = @"
                        CREATE TABLE IF NOT EXISTS habits (
                            id INTEGER PRIMARY KEY AUTOINCREMENT,
                            habit TEXT NOT NULL UNIQUE,
                            created_at TEXT DEFAULT CURRENT_TIMESTAMP
                        )";

                    string createCompletedHabitsTable = @"
                        CREATE TABLE IF NOT EXISTS completed_habits (
                            id INTEGER PRIMARY KEY AUTOINCREMENT,
                            habit TEXT NOT NULL,
                            completion_date TEXT NOT NULL,
                            FOREIGN KEY(habit) REFERENCES habits(habit) ON DELETE CASCADE,
                            UNIQUE(habit, completion_date)
                        )";

                    string createIndex = @"
                        CREATE INDEX IF NOT EXISTS idx_completion_date 
                        ON completed_habits(completion_date)";

                    using (var cmd = new SQLiteCommand(createHabitsTable, connection)) cmd.ExecuteNonQuery();
                    using (var cmd = new SQLiteCommand(createCompletedHabitsTable, connection)) cmd.ExecuteNonQuery();
                    using (var cmd = new SQLiteCommand(createIndex, connection)) cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при создании таблиц БД: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadHabitsForSelectedDate()
        {
            try
            {
                panelHabits.Controls.Clear();
                int yPos = 10;

                using (var connection = new SQLiteConnection(_connectionString))
                {
                    connection.Open();

                    // Загружаем все привычки
                    var habits = new List<string>();
                    using (var cmd = new SQLiteCommand("SELECT habit FROM habits ORDER BY created_at DESC", connection))
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                            habits.Add(reader["habit"].ToString());
                    }

                    // Загружаем выполненные привычки на выбранную дату
                    var completedHabits = new HashSet<string>();
                    using (var cmd = new SQLiteCommand("SELECT habit FROM completed_habits WHERE completion_date = @date", connection))
                    {
                        cmd.Parameters.AddWithValue("@date", _selectedDate.ToString("yyyy-MM-dd"));
                        using (var reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                                completedHabits.Add(reader["habit"].ToString());
                        }
                    }

                    // Отображаем чекбоксы
                    foreach (var habit in habits)
                    {
                        bool isCompleted = completedHabits.Contains(habit);

                        var chk = new CheckBox
                        {
                            Text = habit,
                            Checked = isCompleted,
                            AutoSize = true,
                            Location = new Point(10, yPos),
                            Font = new Font("Segoe UI", 10),
                            Tag = habit
                        };

                        chk.CheckedChanged += (s, e) =>
                        {
                            var cb = s as CheckBox;
                            if (cb != null && cb.Tag != null)
                            {
                                string clickedHabit = cb.Tag.ToString();
                                UpdateHabitCompletionStatus(clickedHabit, cb.Checked);
                            }
                        };

                        panelHabits.Controls.Add(chk);
                        yPos += 35;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при загрузке привычек: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UpdateHabitCompletionStatus(string habit, bool isCompleted)
        {
            try
            {
                using (var connection = new SQLiteConnection(_connectionString))
                {
                    connection.Open();

                    if (isCompleted)
                    {
                        string insertQuery = @"
                            INSERT OR IGNORE INTO completed_habits (habit, completion_date)
                            VALUES (@habit, @date)";
                        using (var cmd = new SQLiteCommand(insertQuery, connection))
                        {
                            cmd.Parameters.AddWithValue("@habit", habit);
                            cmd.Parameters.AddWithValue("@date", _selectedDate.ToString("yyyy-MM-dd"));
                            cmd.ExecuteNonQuery();
                        }
                    }
                    else
                    {
                        string deleteQuery = @"
                            DELETE FROM completed_habits
                            WHERE habit = @habit AND completion_date = @date";
                        using (var cmd = new SQLiteCommand(deleteQuery, connection))
                        {
                            cmd.Parameters.AddWithValue("@habit", habit);
                            cmd.Parameters.AddWithValue("@date", _selectedDate.ToString("yyyy-MM-dd"));
                            cmd.ExecuteNonQuery();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при обновлении статуса: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnbac_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form2 form2 = new Form2();
            form2.Show();
        }
    }
}

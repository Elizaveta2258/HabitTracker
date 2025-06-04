using System;
using System.Data.SQLite;
using System.Windows.Forms;

namespace трекер_привычек
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        String NameConnection = "Data Source = C:\\Users\\liza1\\OneDrive\\Рабочий стол\\reserv.db";

        private void vhod_Click(object sender, EventArgs e)
        {
            try
            {
                using (SQLiteConnection connection = new SQLiteConnection(NameConnection))
                {
                    connection.Open();
                    String Login = textBox_log.Text;
                    String Password = textBox_pas.Text;

                    if (string.IsNullOrWhiteSpace(Login) || string.IsNullOrWhiteSpace(Password))
                    {
                        MessageBox.Show("Пожалуйста, заполните все поля!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    String Query = "SELECT COUNT(1) FROM reserv WHERE login=@login AND password=@password";
                    SQLiteCommand command = new SQLiteCommand(Query, connection);
                    command.Parameters.AddWithValue("@login", Login);
                    command.Parameters.AddWithValue("@password", Password);

                    int count = Convert.ToInt32(command.ExecuteScalar());

                    if (count == 1)
                    {
                        this.Hide();
                        Form2 form2 = new Form2();
                        form2.Show();
                    }
                    else
                    {
                        MessageBox.Show("Аккаунта с такими данными не существует!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void registr_Click(object sender, EventArgs e)
        {
            try
            {
                using (SQLiteConnection connection = new SQLiteConnection(NameConnection))
                {
                    connection.Open();
                    String Login = textBox_log.Text;
                    String Password = textBox_pas.Text;

                    if (string.IsNullOrWhiteSpace(Login) || string.IsNullOrWhiteSpace(Password))
                    {
                        MessageBox.Show("Пожалуйста, заполните все поля!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    String Query = "INSERT INTO reserv (login, password) VALUES (@login, @password)";
                    SQLiteCommand command = new SQLiteCommand(Query, connection);
                    command.Parameters.AddWithValue("@login", Login);
                    command.Parameters.AddWithValue("@password", Password);
                    command.ExecuteNonQuery();

                    MessageBox.Show("Регистрация прошла успешно!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при регистрации: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
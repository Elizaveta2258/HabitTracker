using System;
using System.Data.SQLite;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace трекер_привычек.Tests
{
    [TestClass]
    public class HabitTrackerLogicTests
    {
        private string _testDbPath;
        private string _connectionString;

        [TestInitialize]
        public void Initialize()
        {
            // Создаем временную базу данных в памяти
            _testDbPath = Path.Combine(Path.GetTempPath(), "test_habits.db");
            if (File.Exists(_testDbPath))
                File.Delete(_testDbPath);

            _connectionString = $"Data Source={_testDbPath};Version=3;";

            // Инициализируем тестовую БД
            using (var connection = new SQLiteConnection(_connectionString))
            {
                connection.Open();
                using (var command = new SQLiteCommand(
                    "CREATE TABLE IF NOT EXISTS reserv (login TEXT, password TEXT)", connection))
                {
                    command.ExecuteNonQuery();
                }

                // Добавляем тестового пользователя
                using (var command = new SQLiteCommand(
                    "INSERT INTO reserv (login, password) VALUES ('testuser', 'testpass')", connection))
                {
                    command.ExecuteNonQuery();
                }
            }
        }

        [TestCleanup]
        public void Cleanup()
        {
            // Удаляем временную БД после тестов
            if (File.Exists(_testDbPath))
                File.Delete(_testDbPath);
        }

        [TestMethod]
        public void Authenticate_ValidCredentials_ReturnsTrue()
        {
            // Arrange
            string login = "testuser";
            string password = "testpass";

            // Act
            bool result = AuthenticateUser(login, password);

            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void Authenticate_InvalidCredentials_ReturnsFalse()
        {
            // Arrange
            string login = "testuser";
            string password = "wrongpassword";

            // Act
            bool result = AuthenticateUser(login, password);

            // Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void Register_NewUser_AddsToDatabase()
        {
            // Arrange
            string login = "newuser";
            string password = "newpass";

            // Act
            bool result = RegisterUser(login, password);

            // Assert
            Assert.IsTrue(result);

            // Проверяем, что пользователь добавлен в БД
            using (var connection = new SQLiteConnection(_connectionString))
            {
                connection.Open();
                using (var command = new SQLiteCommand(
                    "SELECT COUNT(*) FROM reserv WHERE login=@login AND password=@password", connection))
                {
                    command.Parameters.AddWithValue("@login", login);
                    command.Parameters.AddWithValue("@password", password);
                    var count = Convert.ToInt32(command.ExecuteScalar());
                    Assert.AreEqual(1, count);
                }
            }
        }

        [TestMethod]
        public void Register_DuplicateUser_ReturnsFalse()
        {
            // Arrange
            string login = "testuser"; // Уже существует
            string password = "testpass";

            // Act
            bool result = RegisterUser(login, password);

            // Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void Authenticate_EmptyFields_ReturnsFalse()
        {
            // Arrange
            string login = "";
            string password = "";

            // Act
            bool result = AuthenticateUser(login, password);

            // Assert
            Assert.IsFalse(result);
        }

        // Методы, имитирующие логику из Form1, но без UI
        private bool AuthenticateUser(string login, string password)
        {
            if (string.IsNullOrWhiteSpace(login) || string.IsNullOrWhiteSpace(password))
                return false;

            using (var connection = new SQLiteConnection(_connectionString))
            {
                connection.Open();
                using (var command = new SQLiteCommand(
                    "SELECT COUNT(1) FROM reserv WHERE login=@login AND password=@password",
                    connection))
                {
                    command.Parameters.AddWithValue("@login", login);
                    command.Parameters.AddWithValue("@password", password);

                    var result = command.ExecuteScalar();
                    return Convert.ToInt32(result) == 1;
                }
            }
        }

        private bool RegisterUser(string login, string password)
        {
            if (string.IsNullOrWhiteSpace(login) || string.IsNullOrWhiteSpace(password))
                return false;

            try
            {
                using (var connection = new SQLiteConnection(_connectionString))
                {
                    connection.Open();

                    // Сначала проверяем, нет ли уже такого пользователя
                    using (var checkCommand = new SQLiteCommand(
                        "SELECT COUNT(1) FROM reserv WHERE login=@login", connection))
                    {
                        checkCommand.Parameters.AddWithValue("@login", login);
                        var exists = Convert.ToInt32(checkCommand.ExecuteScalar()) > 0;
                        if (exists) return false;
                    }

                    // Если пользователя нет, регистрируем
                    using (var command = new SQLiteCommand(
                        "INSERT INTO reserv (login, password) VALUES (@login, @password)",
                        connection))
                    {
                        command.Parameters.AddWithValue("@login", login);
                        command.Parameters.AddWithValue("@password", password);
                        command.ExecuteNonQuery();
                        return true;
                    }
                }
            }
            catch
            {
                return false;
            }
        }
    }
}
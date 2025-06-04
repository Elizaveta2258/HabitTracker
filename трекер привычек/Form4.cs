using System;
using System.Data.SQLite;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace трекер_привычек
{
    public partial class Form4 : Form
    {
        private string _connectionString;
        private DateTime _startDate;
        private DateTime _endDate;

        public Form4(string connectionString, DateTime startDate, DateTime endDate, Form5 form5)
        {
            InitializeComponent();
            _connectionString = connectionString;
            _startDate = startDate;
            _endDate = endDate;

            Text = $"Статистика с {startDate:dd.MM.yyyy} по {endDate:dd.MM.yyyy}";
            InitializeChart();
            LoadHabitsStatistics();
        }

        // Дополнительный конструктор (не используется в текущей логике, можно удалить, если он лишний)
        public Form4(string nameConnection)
        {
            _connectionString = nameConnection;
        }

        private void InitializeChart()
        {
            chart1.Series.Clear();
            chart1.Titles.Clear();

            chart1.Titles.Add($"Статистика ({_startDate:dd.MM.yyyy} - {_endDate:dd.MM.yyyy})");
            chart1.ChartAreas.Clear();
            chart1.ChartAreas.Add(new ChartArea());

            chart1.ChartAreas[0].AxisX.Title = "Привычки";
            chart1.ChartAreas[0].AxisY.Title = "Количество дней";
            chart1.ChartAreas[0].AxisX.LabelStyle.Angle = -45;
            chart1.ChartAreas[0].AxisX.Interval = 1;
        }

        private void LoadHabitsStatistics()
        {
            try
            {
                using (var connection = new SQLiteConnection(_connectionString))
                {
                    connection.Open();

                    Series series = new Series("Выполнено дней")
                    {
                        ChartType = SeriesChartType.Column,
                        Color = Color.SteelBlue,
                        IsValueShownAsLabel = true
                    };

                    string query = @"
                        SELECT h.habit, COUNT(c.habit) AS completed_days
                        FROM habits h
                        LEFT JOIN completed_habits c 
                            ON h.habit = c.habit 
                            AND c.completion_date BETWEEN @startDate AND @endDate
                        GROUP BY h.habit
                        ORDER BY completed_days DESC";

                    using (var command = new SQLiteCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@startDate", _startDate.ToString("yyyy-MM-dd"));
                        command.Parameters.AddWithValue("@endDate", _endDate.ToString("yyyy-MM-dd"));

                        using (var reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                string habit = reader["habit"].ToString();
                                int daysCompleted = Convert.ToInt32(reader["completed_days"]);
                                series.Points.AddXY(habit, daysCompleted);
                            }
                        }
                    }

                    chart1.Series.Add(series);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при загрузке статистики: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnBack_Click_1(object sender, EventArgs e)
        {
            Form5 dateSelectForm = new Form5(_connectionString, this);
            dateSelectForm.Show();
            this.Close();
        }
    }
}

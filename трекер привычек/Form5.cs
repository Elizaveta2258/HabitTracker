using System;
using System.Windows.Forms;

namespace трекер_привычек
{
    public partial class Form5 : Form
    {
        private readonly string _connectionString;
        private readonly Form _previousForm;

        public Form5(string connectionString, Form previousForm)
        {
            InitializeComponent();
            _connectionString = connectionString;
            _previousForm = previousForm;

            InitializeCalendars();
            SetupCalendarEvents();
            UpdateDateLabels();
        }

        private void InitializeCalendars()
        {
            monthCalendar1.MaxDate = DateTime.Today;
            monthCalendar2.MaxDate = DateTime.Today;

            monthCalendar1.SelectionStart = DateTime.Today.AddDays(-7);
            monthCalendar2.SelectionStart = DateTime.Today;
        }

        private void SetupCalendarEvents()
        {
            monthCalendar1.DateChanged += (s, e) => UpdateDateLabels();
            monthCalendar2.DateChanged += (s, e) => UpdateDateLabels();
        }

        private void UpdateDateLabels()
        {
            lblStartDate.Text = $"Начальная дата: {monthCalendar1.SelectionStart:dd.MM.yyyy}";
            lblEndDate.Text = $"Конечная дата: {monthCalendar2.SelectionStart:dd.MM.yyyy}";
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            ReturnToPreviousForm();
        }

        private void ReturnToPreviousForm()
        {
            _previousForm?.Show();
            this.Close();
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);

            if (e.CloseReason == CloseReason.UserClosing && _previousForm != null)
            {
                _previousForm.Show();
            }
        }

        private void btnShowStats_Click_1(object sender, EventArgs e)
        {
            DateTime startDate = monthCalendar1.SelectionStart;
            DateTime endDate = monthCalendar2.SelectionStart;

            if (startDate > endDate)
            {
                MessageBox.Show("Начальная дата не может быть больше конечной", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Переход на форму статистики
            var form4 = new Form4(_connectionString, startDate, endDate, this);
            form4.Show();
            this.Hide();
        }

        private void butBack_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form2 form2 = new Form2();
            form2.Show();
        }
    }
}

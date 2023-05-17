using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace InCinema.Forms
{
    public partial class FormCashier : Form
    {
        string SqlConnectionString = @"Data Source=LEKSA\SQLEXPRESS;Initial Catalog=InCinemaDB;Integrated Security=True";
        private SqlConnection myConnection;
        decimal data;
        public FormCashier()
        {
            InitializeComponent();
        }
        //вывод суммы всех кассовых сборов с фильмов за всё время работы кинотеатра
        private void статистикаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                myConnection = new SqlConnection(SqlConnectionString);
                myConnection.Open();
                string query = "SELECT SUM([AllPrice]) FROM [MoneyTable]";

                var comand = new SqlCommand(query);
                comand.Connection = myConnection;
                var reader = comand.ExecuteReader();
                if (reader.HasRows == false)
                {
                    MessageBox.Show("Данные отсутствуют", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
                else
                {
                    while (reader.Read())
                    {
                        data = Convert.ToDecimal( reader[0]);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                myConnection.Close();
            }
            string str = data.ToString();
            MessageBox.Show($"Доход за всё время работы >> {str.Substring(0, (str.Length - 2))}" + " ₽", "Статистика",MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        //открытие формы с фильмами
        private void фильмыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormFilms formFilms = new FormFilms();
            formFilms.Show();
        }
        //открытие формы с сеансами
        private void сеансыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormSession formSessions = new FormSession();
            formSessions.Show();
        }
        //при закрытии формы, программа завершает работу
        private void FormCashier_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
        //переход на форму с сегодняшними сеансами
        private void btnUser_Click(object sender, EventArgs e)
        {
            FormShow formShow = new FormShow();
            formShow.Show();
        }
        //вызов справки о программе
        private void btnAbout_Click(object sender, EventArgs e)
        {
            FormHelp formHelp = new FormHelp();
            formHelp.ShowDialog(this);
        }
        //переход на форму по кассовому сбору с фильмов
        private void boxOfficeMenuItem_Click(object sender, EventArgs e)
        {
            FormExport formExport = new FormExport();
            formExport.Show();
        }
    }
}

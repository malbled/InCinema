using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace InCinema.Forms
{
    public partial class FormFilms : Form
    {
        string SqlConnectionString = @"Data Source=LEKSA\SQLEXPRESS;Initial Catalog=InCinemaDB;Integrated Security=True";
        private SqlConnection myConnection;
        private bool check;
        public FormFilms()
        {
            InitializeComponent();
        }
        //закрузка данных о фильмах и закгрузка значений жанров фильмов в combobox
        private void FormFilms_Load(object sender, EventArgs e)
        {
            this.filmTableTableAdapter.Fill(this.cinemaDBDataSet.FilmTable);
            string Sql = "SELECT DISTINCT Style FROM FilmTable";
            SqlConnection conn = new SqlConnection(SqlConnectionString);
            conn.Open();
            SqlCommand cmd = new SqlCommand(Sql, conn);
            SqlDataReader DR = cmd.ExecuteReader();
            while (DR.Read())
            {
                cmbFiltr.Items.Add(DR[0]);
            }
        }
        //открытие формы добавление фильма
        private void btnAdd_Click(object sender, EventArgs e)
        {
            FormAddFilm formAddFilm = new FormAddFilm();
            formAddFilm.ShowDialog(this);
        }
        //сохранение изменений над фильмами
        private void btnSaveTool_Click(object sender, EventArgs e)
        {
            this.filmTableTableAdapter.Update(this.cinemaDBDataSet);
        }
        //удаление фильма из базы данных
        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                myConnection = new SqlConnection(SqlConnectionString);
                myConnection.Open();
                string query = "select [FilmTable].[Id] from SessionTable , FilmTable where [SessionTable].[TitleFilm] = [FilmTable].[Id]";
                var comand = new SqlCommand(query);
                comand.Connection = myConnection;
                var reader = comand.ExecuteReader();
                List<int> ints = new List<int>();
                if (reader.HasRows == false)
                {
                    MessageBox.Show("Данные не найдены!");
                }
                else
                {
                    while (reader.Read())
                    {
                        ints.Add(Convert.ToInt32(reader[0]));
                    }
                    int index = dgvFilms.SelectedRows[0].Index;                    
                    foreach (var i in ints)
                    {
                        if(i == Convert.ToInt32(dgvFilms[0, index].Value))
                        {
                            check = false;
                            break;
                        }
                        else check = true;
                    }
                    //если на выбранный фильм для удаления нет сеанса, то удаление может быть выполнено 
                    if (check)
                    {
                        DialogResult dialogResult = MessageBox.Show("Удалить запись?", "Удаление", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                        if (dialogResult == DialogResult.Yes)
                        {
                            int b = Convert.ToInt32(dgvFilms[0, index].Value);
                            string guery1 = $"DELETE MoneyTable WHERE TitleFilm = {b}";
                            SqlConnection connection1 = new SqlConnection(SqlConnectionString);
                            connection1.Open();
                            SqlCommand command1 = new SqlCommand(guery1, connection1);
                            command1.ExecuteNonQuery();
                            connection1.Close();
                            int a = dgvFilms.CurrentRow.Index;
                            dgvFilms.Rows.Remove(dgvFilms.Rows[a]); 
                        }
                    }
                    //если на выбранный фильм для удаления уже есть сеанс, то удаление не может быть выполнено 
                    else MessageBox.Show("Удаление фильма невозможно!\nПоскольку существует Сеанс на этот фильм", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
        }
        //активация кнопки btnFiltr при выборе значения в combobox
        private void cmbFiltr_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnFiltr.Enabled = true;
        }
        //фильтрация фильмов в datagridview по жанру
        private void btnFiltr_Click(object sender, EventArgs e)
        {
            bindingSourceTablFilm.Filter = "Style='" + cmbFiltr.Text + "'";
        }
        //сброс фильтрации
        private void btnShowAll_Click(object sender, EventArgs e)
        {
            bindingSourceTablFilm.Filter = "";
        }
        //активация кнопки btnDelete при выборе строки из datagridview
        private void dgvFilms_SelectionChanged(object sender, EventArgs e)
        {
            btnDelete.Enabled = dgvFilms.SelectedRows.Count > 0;
        }
    }
}

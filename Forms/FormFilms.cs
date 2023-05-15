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
        private void btnAdd_Click(object sender, EventArgs e)
        {
            FormAddFilm formAddFilm = new FormAddFilm();
            formAddFilm.ShowDialog(this);
        }

        private void btnSaveTool_Click(object sender, EventArgs e)
        {
            this.filmTableTableAdapter.Update(this.cinemaDBDataSet);
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                myConnection = new SqlConnection(SqlConnectionString);
                myConnection.Open();
                string query = "select [FilmTable].[Id]\r\n  from SessionTable , FilmTable \r\n where [SessionTable].[TitleFilm] = [FilmTable].[Id]";
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
                    if (check)
                    {
                        DialogResult dialogResult = MessageBox.Show("Удалить запись?", "Удаление", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                        if (dialogResult == DialogResult.Yes)
                        {
                            int a = dgvFilms.CurrentRow.Index;
                            dgvFilms.Rows.Remove(dgvFilms.Rows[a]);
                        }
                    }
                    else  MessageBox.Show("Удаление фильма невозможно, поскольку существует Сеанс на этот фильм", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void cmbFiltr_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnFiltr.Enabled = true;
        }

        private void btnFiltr_Click(object sender, EventArgs e)
        {
            bindingSourceTablFilm.Filter = "Style='" + cmbFiltr.Text + "'";
        }

        private void btnShowAll_Click(object sender, EventArgs e)
        {
            bindingSourceTablFilm.Filter = "";
        }
    }
}

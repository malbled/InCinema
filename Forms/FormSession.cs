using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace InCinema.Forms
{
    public partial class FormSession : Form
    {
        string SqlConnectionString = @"Data Source=LEKSA\SQLEXPRESS;Initial Catalog=InCinemaDB;Integrated Security=True";
        private SqlConnection myConnection;
        bool check;
        public string Name;
        public string Date;
        public string Time;
        public string Price;
        public string Count;
        public string id;
        public FormSession()
        {
            InitializeComponent();
            myConnection = new SqlConnection(SqlConnectionString);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            FormAddSession frm = new FormAddSession();
            frm.ShowDialog(this);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                myConnection = new SqlConnection(SqlConnectionString);
                myConnection.Open();
                string query = "select [SessionTable].[Id]  from SessionTable where [SessionTable].[CountTicket] < 60";
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
                    int index = dgvSession.SelectedRows[0].Index;
                    foreach (var i in ints)
                    {
                        if (i == Convert.ToInt32(dgvSession[0, index].Value))
                        {
                            check = false;
                            break;
                        }
                        else check = true;
                    }
                    var id = Convert.ToInt32(dgvSession.SelectedRows[0].Cells["Column1"].Value);
                    if (check)
                    {
                        DialogResult dialogResult = MessageBox.Show("Удалить запись?", "Удаление", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                        if (dialogResult == DialogResult.Yes)
                        {
                            string guery = $"DELETE SessionTable WHERE Id = {id}";
                            SqlConnection connection = new SqlConnection(SqlConnectionString);
                            connection.Open();
                            SqlCommand command= new SqlCommand(guery,connection);
                            command.ExecuteNonQuery();
                            connection.Close();
                            dgvSession.Rows.Clear();
                            LoadPrint();
                        }
                    }
                    else MessageBox.Show("Удаление Сеанса невозможно, поскольку на него уже проданы билеты", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
        private DataGridViewColumn COL;
        private void btnSort_Click(object sender, EventArgs e)
        {
            COL = new DataGridViewColumn();
            switch (listBoxSort.SelectedIndex)
            {
                case 0: COL = Column2; break;
                case 1: COL = Column3; break;
                case 2: COL = Column4; break;
                case 3: COL = Column5; break;
                case 4: COL = Column6; break;

            }
            if (rb1.Checked)
            {
                dgvSession.Sort(COL, ListSortDirection.Ascending);
            }
            else
            {
                dgvSession.Sort(COL, ListSortDirection.Descending);
            }
        }

        private void listBoxSort_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnSort.Enabled = true;
        }

        private void FormSession_Load(object sender, EventArgs e)
        {
            LoadPrint();

        }
        private void dgvSession_SelectionChanged(object sender, EventArgs e)
        {
            btnDelete.Enabled = btnSale.Enabled = dgvSession.SelectedRows.Count > 0;
        }
        public void LoadPrint()
        {
            try
            {
                myConnection = new SqlConnection(SqlConnectionString);
                myConnection.Open();
                string query = "\tSELECT [SessionTable].[Id], [FilmTable].[Title],[SessionTable].[Date],[SessionTable].[Time], [SessionTable].[Price],\r\n[SessionTable].[CountTicket] FROM [SessionTable],[FilmTable] WHERE [SessionTable].[TitleFilm] = [FilmTable].[Id] AND [SessionTable].[Date] >= CONVERT(date, GETDATE()) AND [SessionTable].[CountTicket] >0";

                var comand = new SqlCommand(query);
                comand.Connection = myConnection;
                var reader = comand.ExecuteReader();
                List<string[]> data = new List<string[]>();
                if (reader.HasRows == false)
                {
                    MessageBox.Show("Данные о сеансах отсутствуют\nДобавьте их!", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
                else
                {
                    while (reader.Read())
                    {
                        data.Add(new string[6]);
                        data[data.Count - 1][0] = reader[0].ToString();
                        data[data.Count - 1][1] = reader[1].ToString();
                        data[data.Count - 1][2] = ((DateTime)reader[2]).ToShortDateString();
                        data[data.Count - 1][3] = reader[3].ToString().Substring(0, (reader[3].ToString()).Length - 3);
                        data[data.Count - 1][4] = reader[4].ToString().Substring(0, (reader[4].ToString()).Length - 2) + " ₽";
                        data[data.Count - 1][5] = reader[5].ToString();
                    }
                    foreach (string[] s in data)
                        dgvSession.Rows.Add(s);
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

        public void btnSale_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dgvSession.SelectedRows)
            {
                id = row.Cells[0].Value.ToString();
                Name  = row.Cells[1].Value.ToString();
                Date = row.Cells[2].Value.ToString();
                Time = row.Cells[3].Value.ToString();
                Price = row.Cells[4].Value.ToString();
                Count = row.Cells[5].Value.ToString();
            }
            FormSale formSale = new FormSale(id,Name,Date,Time,Price,Count);
            formSale.ShowDialog(this);
        }
    }
}

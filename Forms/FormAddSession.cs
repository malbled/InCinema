using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace InCinema.Forms
{
    public partial class FormAddSession : Form
    {
        private SqlConnection myConnection;
        public SqlConnection connection3;
        public FormAddSession()
        {
            InitializeComponent();
            DateTime tomorrow = DateTime.Today.AddDays(1);
            datePicker.MinDate = tomorrow;
        }
        private void ValidateTextBoxes()
        {
            if (txtPrice.Text.Length != 0 && cmbTime.Text.Length != 0)
            {
                btnSave.Enabled = true;
            }
            else  btnSave.Enabled = false;
        }
        private void FormAddSession_Load(object sender, EventArgs e)
        {
            this.filmTableTableAdapter.Fill(this.cinemaDBDataSet.FilmTable);
        }

        private void txtCountBilet_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;
            if (!Char.IsDigit(number) && number != 8)
            {
                e.Handled = true;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string qwery = $"INSERT SessionTable VALUES ({cmbTitleFilm.SelectedValue}, " +
                $"'{datePicker.Value.Date}', '{cmbTime.Text}', {txtPrice.Text.Replace(',','.')}, " +
                $"{Convert.ToInt32(txtCountBilet.Text)})";
              string CONECT = @"Data Source=LEKSA\SQLEXPRESS;Initial Catalog=InCinemaDB;Integrated Security=True";
            SqlConnection connection = new SqlConnection(CONECT);
            connection.Open();
            SqlCommand command = new SqlCommand(qwery, connection);
            command.ExecuteNonQuery();
            connection.Close();

            try
            {
                myConnection = new SqlConnection(CONECT);
                myConnection.Open();
                string qwery1 = $"SELECT [MoneyTable].[TitleFilm] FROM [SessionTable],[MoneyTable] WHERE {cmbTitleFilm.SelectedValue} = [MoneyTable].[TitleFilm]";
                var comand = new SqlCommand(qwery1);
                comand.Connection = myConnection;
                var reader = comand.ExecuteReader();
                int data;
                if (reader.HasRows == false)
                {
                    string qwery3 = $"INSERT MoneyTable VALUES ({cmbTitleFilm.SelectedValue},{0.000})";
                    
                    connection3 = new SqlConnection(CONECT);
                    connection3.Open();
                    SqlCommand command3 = new SqlCommand(qwery3, connection3);
                    command3.ExecuteNonQuery();
                    connection3.Close();
                }
                else
                {

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

            FormSession main = this.Owner as FormSession;
            main.dgvSession.Rows.Clear();
            main.LoadPrint();
            this.Close();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtPrice_TextChanged(object sender, EventArgs e)
        {
            ValidateTextBoxes();
        }

        private void txtCountBilet_TextChanged(object sender, EventArgs e)
        {
            ValidateTextBoxes();
        }

        private void cmbTime_SelectedIndexChanged(object sender, EventArgs e)
        {
            ValidateTextBoxes();
        }
    }
}

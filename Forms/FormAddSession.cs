using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace InCinema.Forms
{
    public partial class FormAddSession : Form
    {
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

using System;
using System.Data;
using System.Windows.Forms;

namespace InCinema.Forms
{
    public partial class FormAddFilm : Form
    {
        public FormAddFilm()
        {
            InitializeComponent();
        }
        private void ValidateTextBoxes()
        {
            if (txtTitle.Text.Length != 0 && txtTime.Text.Length != 0 && txtStyle.Text.Length != 0 && txtPoster.Text.Length != 0)
            {
                btnSave.Enabled = true;
            }
            else btnSave.Enabled = false;
        }

        private void txtTime_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;
            if (!Char.IsDigit(number) && number != 8)
            {
                e.Handled = true;
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            FormFilms main = this.Owner as FormFilms;
            this.Close();
            if (main != null)
            {
                DataRow nRow = main.cinemaDBDataSet.Tables[1].NewRow();
                int rc = main.dgvFilms.RowCount + 1;
                nRow[1] = txtTitle.Text;
                nRow[2] = txtStyle.Text;
                nRow[3] = Convert.ToInt32( txtTime.Text);
                nRow[4] = txtPoster.Text;
                main.cinemaDBDataSet.Tables[1].Rows.Add(nRow);
                main.filmTableTableAdapter.Update(main.cinemaDBDataSet.FilmTable);
                main.cinemaDBDataSet.Tables[2].AcceptChanges();
                main.dgvFilms.Refresh();
            }
        }

        private void txtTitle_TextChanged(object sender, EventArgs e)
        {
            ValidateTextBoxes();
        }

        private void txtStyle_TextChanged(object sender, EventArgs e)
        {
            ValidateTextBoxes();
        }

        private void txtTime_TextChanged(object sender, EventArgs e)
        {
            ValidateTextBoxes();
        }

        private void txtPoster_TextChanged(object sender, EventArgs e)
        {
            ValidateTextBoxes();
            picBox.ImageLocation = txtPoster.Text;
        }
    }
}

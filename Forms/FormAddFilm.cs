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
        //метод валидации полей
        private void ValidateTextBoxes()
        {
            if (txtTitle.Text.Length != 0 && txtTime.Text.Length != 0 && txtStyle.Text.Length != 0 && txtPoster.Text.Length != 0)
            {
                btnSave.Enabled = true;
            }
            else btnSave.Enabled = false;
        }
        //запрет на ввод всех символов, кроме цифр и backspace для поля txtxTime
        private void txtTime_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;
            if (!Char.IsDigit(number) && number != 8)
            {
                e.Handled = true;
            }
        }
        //закрытие формы
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        //сохранение данных о фильме в базу данных и закрытие текущей формы
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
        //валидация поля Название при изменении текста
        private void txtTitle_TextChanged(object sender, EventArgs e)
        {
            ValidateTextBoxes();
        }
        //валидация поля Жанр при изменении текста
        private void txtStyle_TextChanged(object sender, EventArgs e)
        {
            ValidateTextBoxes();
        }
        //валидация поля Время при изменении текста
        private void txtTime_TextChanged(object sender, EventArgs e)
        {
            ValidateTextBoxes();
        }
        //валидация поля Постер при изменении текста и закрузка в picturebox картинки из поля Постер
        private void txtPoster_TextChanged(object sender, EventArgs e)
        {
            ValidateTextBoxes();
            picBox.ImageLocation = txtPoster.Text;
        }
    }
}

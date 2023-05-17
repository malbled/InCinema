using System;
using System.Windows.Forms;

namespace InCinema.Forms
{
    public partial class FormAuthorization : Form
    {
        public FormAuthorization()
        {
            InitializeComponent();
        }
        private void FormAuthorization_Load(object sender, EventArgs e)
        {
            this.cashierTableTableAdapter.Fill(this.cinemaDBDataSet.CashierTable);
        }
        //выход из формы
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        //поиск кассира на основании введеных данных Логина и Пароль
        private void btnOpen_Click(object sender, EventArgs e)
        {

            for (int i = 0; i <= cinemaDBDataSet.Tables["CashierTable"].Rows.Count - 1; i++)
            {
                if (txtLogin.Text == cinemaDBDataSet.Tables["CashierTable"].Rows[i][1].ToString())
                {
                    if (txtPass.Text == cinemaDBDataSet.Tables["CashierTable"].Rows[i][2].ToString())
                    {
                        //при удачном нахождении касссира в базе - переход на формы для кассиров
                        FormCashier formCashier = new FormCashier();
                        formCashier.Show();
                        break;
                    }
                }
                else
                {
                    //при неудачном нахождении кассира в базе
                    MessageBox.Show("Пользователь не найден!", "InCinema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txtPass.Text = "";
                    txtLogin.Text = "";
                    break;
                }
            }
        }
        //метод для активации кнопки btnOpen
        private void ValidateTextBoxes()
        {
            if (txtLogin.Text.Length != 0 && txtPass.Text.Length != 0)
            {
                btnOpen.Enabled = true;
            }
            else
            {
                btnOpen.Enabled = false;
            }
        }
        //валидация поля Логин при изменении текста
        private void txtLogin_TextChanged(object sender, EventArgs e)
        {
            ValidateTextBoxes();
        }
        //валидация поля Пароль при изменении текста
        private void txtPass_TextChanged(object sender, EventArgs e)
        {
            ValidateTextBoxes();
        }
    }
}

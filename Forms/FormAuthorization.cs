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

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {

            for (int i = 0; i <= cinemaDBDataSet.Tables["CashierTable"].Rows.Count - 1; i++)
            {
                if (txtLogin.Text == cinemaDBDataSet.Tables["CashierTable"].Rows[i][1].ToString())
                {
                    if (txtPass.Text == cinemaDBDataSet.Tables["CashierTable"].Rows[i][2].ToString())
                    {
                        FormCashier formCashier = new FormCashier();
                        formCashier.Show();
                        break;
                    }
                }
                else
                {
                    MessageBox.Show("Вы правильно введеные данные");
                    txtPass.Text = "";
                    txtLogin.Text = "";
                    break;
                }
            }
        }
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

        private void txtLogin_TextChanged(object sender, EventArgs e)
        {
            ValidateTextBoxes();
        }

        private void txtPass_TextChanged(object sender, EventArgs e)
        {
            ValidateTextBoxes();
        }
    }
}

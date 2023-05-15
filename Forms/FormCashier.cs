using System;
using System.Windows.Forms;

namespace InCinema.Forms
{
    public partial class FormCashier : Form
    {
        public FormCashier()
        {
            InitializeComponent();
        }
        private void статистикаToolStripMenuItem_Click(object sender, EventArgs e)
        {
           // MessageBox.Show("Доход за всё время работы >> ","Статистика",MessageBoxButtons.OK, MessageBoxIcon.Information);
           // в разработке
        }

        private void фильмыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormFilms formFilms = new FormFilms();
            formFilms.Show();
        }

        private void сеансыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormSession formSessions = new FormSession();
            formSessions.Show();
        }

        private void FormCashier_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void btnUser_Click(object sender, EventArgs e)
        {
            FormShow formShow = new FormShow();
            formShow.Show();
        }

        private void btnAbout_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Справка о программе", "Справка", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void boxOfficeMenuItem_Click(object sender, EventArgs e)
        {
            //в разработке
        }
    }
}

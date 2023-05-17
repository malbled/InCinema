using System;
using System.Drawing;
using System.Windows.Forms;

namespace InCinema.Forms
{
    public partial class FormSessions : Form
    {
        public FormSessions()
        {
            InitializeComponent();
        }
        //переход на форму авторизации кассира
        private void btnAdmin_Click(object sender, EventArgs e)
        {
            FormAuthorization frm = new FormAuthorization();
            frm.Show();
        }
        //дизайн
        private void btnAdmin_MouseLeave(object sender, EventArgs e)
        {
            btnAdmin.ForeColor = Color.Transparent;
        }
        //дизайн
        private void btnAdmin_MouseMove(object sender, MouseEventArgs e)
        {
            btnAdmin.ForeColor = Color.Black;
        }
        //переход на форму просмотра сегодняшних сеансов
        private void btnUser_Click(object sender, EventArgs e)
        {
            FormShow formShow = new FormShow();
            formShow.Show();
        }
        //дизайн
        private void btnUser_MouseLeave(object sender, EventArgs e)
        {
            btnUser.ForeColor = Color.Transparent;
        }
        //дизайн
        private void btnUser_MouseMove(object sender, MouseEventArgs e)
        {
            btnUser.ForeColor = Color.Black;
        }
        //выход из программы
        private void lbExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        //дизайн
        private void lbExit_MouseLeave(object sender, EventArgs e)
        {
            lbExit.ForeColor = Color.White;
        }
        //дизайн
        private void lbExit_MouseMove(object sender, MouseEventArgs e)
        {
            lbExit.ForeColor = Color.FromArgb(249, 124, 57);
        }
    }
}

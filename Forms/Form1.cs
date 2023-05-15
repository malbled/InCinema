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

        private void btnAdmin_Click(object sender, EventArgs e)
        {
            FormAuthorization frm = new FormAuthorization();
            frm.Show();
        }

        private void btnAdmin_MouseLeave(object sender, EventArgs e)
        {
            btnAdmin.ForeColor = Color.Transparent;
        }

        private void btnAdmin_MouseMove(object sender, MouseEventArgs e)
        {
            btnAdmin.ForeColor = Color.Black;
        }

        private void btnUser_Click(object sender, EventArgs e)
        {
            FormShow formShow = new FormShow();
            formShow.Show();
        }

        private void btnUser_MouseLeave(object sender, EventArgs e)
        {
            btnUser.ForeColor = Color.Transparent;
        }

        private void btnUser_MouseMove(object sender, MouseEventArgs e)
        {
            btnUser.ForeColor = Color.Black;
        }

        private void lbExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void lbExit_MouseLeave(object sender, EventArgs e)
        {
            lbExit.ForeColor = Color.White;
        }

        private void lbExit_MouseMove(object sender, MouseEventArgs e)
        {
            lbExit.ForeColor = Color.FromArgb(249, 124, 57);
        }
    }
}

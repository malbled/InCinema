using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace InCinema.Forms
{
    public partial class FormSale : Form
    {
        decimal StartPrice;
        int MaxCount;
        int id;
        string SqlConnectionString = @"Data Source=LEKSA\SQLEXPRESS;Initial Catalog=InCinemaDB;Integrated Security=True";
        private SqlConnection myConnection;
        int dop;
        public FormSale(string id,string name, string date, string time, string Price, string Count)
        {
            InitializeComponent();
            this.id = Convert.ToInt32(id);
            this.txtName.Text = name;
            this.txtDate.Text = date; 
            this.txtTime.Text = time;
            string str = Price.Substring(0, (Price.ToString()).Length - 2);
            StartPrice = Convert.ToDecimal(str);
            this.txtPrice.Text = StartPrice.ToString();
            MaxCount = Convert.ToInt32(Count);
            numUpDown.Maximum = MaxCount;
        }

        private void numUpDown_ValueChanged(object sender, EventArgs e)
        {
            txtPrice.Text = (numUpDown.Value * StartPrice).ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnPay_Click(object sender, EventArgs e)
        {
            try
            {
                myConnection = new SqlConnection(SqlConnectionString);
                myConnection.Open();
                string query = $"SELECT [SessionTable].[CountTicket] FROM [SessionTable] WHERE [Id]={id}";
                var comand = new SqlCommand(query);
                comand.Connection = myConnection;
                var reader = comand.ExecuteReader();
                
                if (reader.HasRows == false)
                {
                    MessageBox.Show("Данные не найдены!");
                }
                else
                {
                    while (reader.Read())
                    {
                        dop = Convert.ToInt32(reader[0]);
                    }
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

            myConnection = new SqlConnection(SqlConnectionString);
            myConnection.Open();
            string query1 = $"UPDATE [SessionTable] SET [CountTicket]={dop- Convert.ToInt32(numUpDown.Value)} WHERE [Id]={id}";
            SqlCommand command = new SqlCommand(query1, myConnection);
            command.ExecuteNonQuery();
            myConnection.Close();
            MessageBox.Show("Оплата прошла!", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            FormSession main = this.Owner as FormSession;
            main.dgvSession.Rows.Clear();
            main.LoadPrint();
            this.Close();
        }
    }
}

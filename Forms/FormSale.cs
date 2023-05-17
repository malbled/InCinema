﻿using System;
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
        
        int dop;
        int dopM;
        decimal dopPrice;
        //загрузка данных о сенссе в форму для продажи
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
            SqlConnection myConnection;
            myConnection = new SqlConnection(SqlConnectionString);
            try
            {
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

            SqlConnection myConnectionP;
            myConnectionP = new SqlConnection(SqlConnectionString);
            myConnectionP.Open();
            string query1 = $"UPDATE [SessionTable] SET [CountTicket]={dop- Convert.ToInt32(numUpDown.Value)} WHERE [Id]={id}";
            SqlCommand command1 = new SqlCommand(query1, myConnectionP);
            command1.ExecuteNonQuery();
            myConnectionP.Close();

            SqlConnection myConnectionM = new SqlConnection(SqlConnectionString);
            try
            {
                myConnectionM.Open();
                string queryM = $"SELECT [FilmTable].[Id] FROM [FilmTable] WHERE [FilmTable].[Title] = '{txtName.Text}'";
                var comandM = new SqlCommand(queryM);
                comandM.Connection = myConnectionM;
                var reader = comandM.ExecuteReader();

                if (reader.HasRows == false)
                {
                    MessageBox.Show("Данные не найдены!");
                }
                else
                {
                    while (reader.Read())
                    {
                        dopM = Convert.ToInt32(reader[0]);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                myConnectionM.Close();
            }
            SqlConnection myConnectionN = new SqlConnection(SqlConnectionString);
            try
            {
                myConnectionN.Open();
                string queryN = $"SELECT [MoneyTable].[AllPrice] FROM [MoneyTable] WHERE [MoneyTable].[TitleFilm] = {dopM}";
                var comandN = new SqlCommand(queryN);
                comandN.Connection = myConnectionN;
                var reader = comandN.ExecuteReader();

                if (reader.HasRows == false)
                {
                    //MessageBox.Show("Данные не найдены!");
                }
                else
                {
                    while (reader.Read())
                    {
                        dopPrice = Convert.ToDecimal(reader[0]);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                myConnectionN.Close();
            }
            string str = (dopPrice + Convert.ToDecimal(txtPrice.Text)).ToString();
            str.Replace(',', '.');
            SqlConnection myConnectionK = new SqlConnection(SqlConnectionString);
            myConnectionK.Open();
            string queryK = $"UPDATE [MoneyTable] SET [AllPrice] = {str.Replace(',', '.')} WHERE [TitleFilm] = {dopM}";
            SqlCommand commandK = new SqlCommand(queryK, myConnectionK);
            commandK.ExecuteNonQuery();
            myConnectionK.Close();

            MessageBox.Show("Оплата прошла!", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            FormSession main = this.Owner as FormSession;
            main.dgvSession.Rows.Clear();
            main.LoadPrint();
            this.Close();
        }
    }
}

using System.Collections.Generic;
using System;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Drawing;

namespace InCinema.Forms
{
    public partial class FormShow : Form
    {
        string SqlConnectionString = @"Data Source=LEKSA\SQLEXPRESS;Initial Catalog=InCinemaDB;Integrated Security=True";
        private SqlConnection myConnection;
        List<string[]> data = new List<string[]>();
        public FormShow()
        {
            InitializeComponent();
        }

        private void FormShow_Load(object sender, System.EventArgs e)
        {
            try
            {
                myConnection = new SqlConnection(SqlConnectionString);
                myConnection.Open();
                string query = "SELECT [FilmTable].[Title],[SessionTable].[Time], [SessionTable].[Price],[SessionTable].[CountTicket] FROM [SessionTable],[FilmTable] WHERE [SessionTable].[TitleFilm] = [FilmTable].[Id] AND [SessionTable].[Date] = CONVERT(date, GETDATE())";

                var comand = new SqlCommand(query);
                comand.Connection = myConnection;
                var reader = comand.ExecuteReader();
                
                if (reader.HasRows == false)
                {
                    MessageBox.Show("Данные о сеансах отсутствуют", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
                else
                {
                    while (reader.Read())
                    {
                        data.Add(new string[4]);
                        data[data.Count - 1][0] = reader[0].ToString();
                        data[data.Count - 1][1] = reader[1].ToString().Substring(0, (reader[1].ToString()).Length - 3);
                        data[data.Count - 1][2] = reader[2].ToString().Substring(0, (reader[2].ToString()).Length - 2) + " ₽";
                        data[data.Count - 1][3] = reader[3].ToString();
                    }
                    foreach (string[] s in data)
                        dataGridView1.Rows.Add(s);
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

            try
            {
                myConnection = new SqlConnection(SqlConnectionString);
                myConnection.Open();
                string query = "SELECT [FilmTable].[Poster] FROM [FilmTable],[SessionTable] WHERE[SessionTable].[TitleFilm] = [FilmTable].[Id] AND [SessionTable].[Date] = CONVERT(date, GETDATE())";

                var comand = new SqlCommand(query);
                comand.Connection = myConnection;
                List<string> ints = new List<string>();
                var reader = comand.ExecuteReader();

                if (reader.HasRows == false)
                {
                    MessageBox.Show("Данные о сеансах отсутствуют", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
                else
                {
                    while (reader.Read())
                    {
                        ints.Add(reader[0].ToString());
                    }
                    int y = 217;
                    foreach(var str in ints)
                    {
                        PictureBox pct = new PictureBox();
                        pct.Height = 150;
                        pct.Width = 110;
                        pct.SizeMode = PictureBoxSizeMode.StretchImage;
                        pct.BackColor = Color.Aqua;
                        pct.Location = new Point(992, y);
                        pct.ImageLocation = str.ToString();
                        Controls.Add(pct);
                        y += 150;
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
        }
        
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;

namespace InCinema.Forms
{
    public partial class FormExport : Form
    {
        string SqlConnectionString = @"Data Source=LEKSA\SQLEXPRESS;Initial Catalog=InCinemaDB;Integrated Security=True";
        private SqlConnection myConnection;
        public FormExport()
        {
            InitializeComponent();
        }

        private void FormExport_Load(object sender, EventArgs e)
        {
            try
            {
                myConnection = new SqlConnection(SqlConnectionString);
                myConnection.Open();
                string query = "SELECT [FilmTable].[Title],[MoneyTable].[AllPrice] FROM [MoneyTable],[FilmTable] WHERE [MoneyTable].[TitleFilm] = [FilmTable].[Id]";

                var comand = new SqlCommand(query);
                comand.Connection = myConnection;
                var reader = comand.ExecuteReader();
                List<string[]> data = new List<string[]>();
                if (reader.HasRows == false)
                {
                    MessageBox.Show("Данные отсутствуют", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
                else
                {
                    while (reader.Read())
                    {
                        data.Add(new string[6]);
                        data[data.Count - 1][0] = reader[0].ToString();
                        data[data.Count - 1][1] = reader[1].ToString().Substring(0, (reader[1].ToString()).Length - 2) + " ₽";
                    }
                    foreach (string[] s in data)
                        dgvBoxOffice.Rows.Add(s);
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

        private void btnExport_Click(object sender, EventArgs e)
        {
            Excel.Application xlApp = new Excel.Application();
            xlApp.Visible = true;
            Excel.Workbook wBook;
            Excel.Worksheet xlSheet;
            wBook = xlApp.Workbooks.Add();
            xlApp.Columns.ColumnWidth = 30;
            xlSheet = (Excel.Worksheet)wBook.Sheets[1];
            xlSheet.Name = "Кассовый сбор";
            xlApp.Cells[1, 1] = "Название фильма";
            xlApp.Cells[1, 2] = "Денежный приход";
            for (int i = 0; i < dgvBoxOffice.Rows.Count; i++)
            {
                for (int j = 0; j < dgvBoxOffice.Columns.Count; j++)
                {
                    xlApp.Cells[i + 2, j + 1] = dgvBoxOffice.Rows[i].Cells[j].Value.ToString();
                    xlSheet.Cells.HorizontalAlignment = 1;
                    xlApp.Visible = true;
                }
            }
        }
    }
}

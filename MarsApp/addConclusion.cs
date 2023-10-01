//Форма "Добавить заключение на основании пройденного испытания"
using System;
using System.Data;
using System.Data.Common;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Linq;

namespace MarsApp
{
    public partial class addConclusion : Form
    {
        public addConclusion()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)//Сохранить новые данные
        {
            label1.Text = "";
            using (SqlConnection connection = new SqlConnection(Properties.Settings.Default.connString))
            {
                using (SqlCommand sqlCommand = new SqlCommand("Selection.addNewConclusion", connection))
                {

                    sqlCommand.CommandType = CommandType.StoredProcedure;

                    //Отправка значений в хранимую процедуру "Selection.addNewConclusion"
                    sqlCommand.Parameters.Add(new SqlParameter("@ApplicantID", SqlDbType.Int));
                    sqlCommand.Parameters["@ApplicantID"].Value = Convert.ToInt32(numericUpDown2.Value);

                    sqlCommand.Parameters.Add(new SqlParameter("@TestID", SqlDbType.Int));
                    sqlCommand.Parameters["@TestID"].Value = Convert.ToInt32(numericUpDown3.Value);

                    sqlCommand.Parameters.Add(new SqlParameter("@SelectorID", SqlDbType.Int));
                    sqlCommand.Parameters["@SelectorID"].Value = Convert.ToInt32(numericUpDown4.Value);

                    sqlCommand.Parameters.Add(new SqlParameter("@Conclusions", SqlDbType.NVarChar, 10));
                    sqlCommand.Parameters["@Conclusions"].Value = comboBox1.Text;

                    try
                    {
                        connection.Open();
                        sqlCommand.ExecuteNonQuery();
                        label1.Text = "Заключение добавлено.";
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    finally
                    {
                        connection.Close();
                    }
                }
            }
        }

        private async void ShowConlusions_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            dataGridView1.Columns.Clear();
            SqlConnection connection = new SqlConnection(Properties.Settings.Default.connString);
            await connection.OpenAsync();
            SqlDataReader sqlReader = null;
            string str = "SELECT c.ID, c.ApplicantID, a.FirstName, a.LastName, TestName, SelectorID, Conclusions FROM Selection.Conclusions c JOIN Selection.Applicants a ON a.ApplicantID = c.ApplicantID JOIN Selection.Tests t ON t.ID = c.TestID";
            SqlCommand command = new SqlCommand(str, connection);
            int l = 0;
            dataGridView1.ColumnCount = 7;
            dataGridView1.Columns[0].HeaderText = "Id";
            dataGridView1.Columns[1].HeaderText = "Id претендента";
            dataGridView1.Columns[2].HeaderText = "Имя";
            dataGridView1.Columns[3].HeaderText = "Фамилия";
            dataGridView1.Columns[4].HeaderText = "Испытание";
            dataGridView1.Columns[5].HeaderText = "Член комиссии (Id)";
            dataGridView1.Columns[6].HeaderText = "Заключение";
            try
            {
                sqlReader = await command.ExecuteReaderAsync();
                while (await sqlReader.ReadAsync())
                {
                    dataGridView1.Rows.Add();
                    dataGridView1.Rows[l].Cells[0].Value = Convert.ToString(sqlReader["ID"]);
                    dataGridView1.Rows[l].Cells[1].Value = Convert.ToString(sqlReader["ApplicantID"]);
                    dataGridView1.Rows[l].Cells[2].Value = Convert.ToString(sqlReader["FirstName"]);
                    dataGridView1.Rows[l].Cells[3].Value = Convert.ToString(sqlReader["LastName"]);
                    dataGridView1.Rows[l].Cells[4].Value = Convert.ToString(sqlReader["TestName"]);
                    dataGridView1.Rows[l].Cells[5].Value = Convert.ToString(sqlReader["SelectorID"]);
                    dataGridView1.Rows[l].Cells[6].Value = Convert.ToString(sqlReader["Conclusions"]);
                    ++l;
                }
            }
           /* catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }*/
            finally
            {
                if (sqlReader != null)
                    sqlReader.Close();
            }

        }
    }
}

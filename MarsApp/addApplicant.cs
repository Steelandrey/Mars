//Форма "Добавить претендента"
using System;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace MarsApp
{
    public partial class addApplicant : Form
    {
        public addApplicant()
        {
            InitializeComponent();
        }

        private void TextBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void Button1_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(Properties.Settings.Default.connString))
            {
                using (SqlCommand sqlCommand = new SqlCommand("Selection.addNewApplicant", connection))
                {
                  
                    sqlCommand.CommandType = CommandType.StoredProcedure;

                    //Отправка значений в хранимую процедуру "Selection.addNewApplicant"
                    sqlCommand.Parameters.Add(new SqlParameter("@FirstName", SqlDbType.NVarChar, 20));
                    sqlCommand.Parameters["@FirstName"].Value = textBox1.Text;

                    sqlCommand.Parameters.Add(new SqlParameter("@LastName", SqlDbType.NVarChar, 20));
                    sqlCommand.Parameters["@LastName"].Value = textBox2.Text;

                    sqlCommand.Parameters.Add(new SqlParameter("@BirthDate", SqlDbType.Date));
                    sqlCommand.Parameters["@BirthDate"].Value = dateTimePicker1.Value;

                    sqlCommand.Parameters.Add(new SqlParameter("@Gender", SqlDbType.NVarChar, 5));
                    sqlCommand.Parameters["@Gender"].Value = textBox4.Text;

                    sqlCommand.Parameters.Add(new SqlParameter("@Country", SqlDbType.NVarChar, 20));
                    sqlCommand.Parameters["@Country"].Value = textBox5.Text;

                    sqlCommand.Parameters.Add(new SqlParameter("@Residence", SqlDbType.NVarChar, 150));
                    sqlCommand.Parameters["@Residence"].Value = textBox6.Text;

                    sqlCommand.Parameters.Add(new SqlParameter("@Education", SqlDbType.NVarChar, 150));
                    sqlCommand.Parameters["@Education"].Value = textBox7.Text;

                    sqlCommand.Parameters.Add(new SqlParameter("@Specialization", SqlDbType.NVarChar, 100));
                    sqlCommand.Parameters["@Specialization"].Value = textBox8.Text;

                    sqlCommand.Parameters.Add(new SqlParameter("@VacancyID", SqlDbType.Int));
                    sqlCommand.Parameters["@VacancyID"].Value = Convert.ToInt32(numericUpDown1.Value);

                    sqlCommand.Parameters.Add(new SqlParameter("@PhoneNumber", SqlDbType.NChar, 12));
                    sqlCommand.Parameters["@PhoneNumber"].Value = maskedTextBox1.Text;

                    sqlCommand.Parameters.Add(new SqlParameter("@Conclusion", SqlDbType.NVarChar, 50));
                    sqlCommand.Parameters["@Conclusion"].Value = textBox11.Text;

                    sqlCommand.Parameters.Add(new SqlParameter("@GroupName", SqlDbType.NVarChar, 5));
                    sqlCommand.Parameters["@GroupName"].Value = textBox12.Text;

                    try
                    {
                        connection.Open();
                        sqlCommand.ExecuteNonQuery();
                        label13.Text = "Претендент успешно добавлен.";
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

        private void Button2_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();
            textBox7.Clear();
            textBox8.Clear();
            maskedTextBox1.Clear();
            textBox11.Clear();
            textBox12.Clear();
            label13.Text = "";
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}

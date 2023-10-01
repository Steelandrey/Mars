//Форма "Поиск претендента"
using System;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace MarsApp
{
    public partial class findApplicants : Form
    {
        public findApplicants()
        {
            InitializeComponent();
        }

        /*Данный асинхронный метод принимает строку SQL-запроса, создаёт подключение к базе данных, выполняет запрос
         * и заполняет таблицу в приложении полученными данными*/
        public async void Inquiry (string str)
        {
            dataGridView1.Rows.Clear();
            dataGridView1.Columns.Clear();
            SqlConnection connection = new SqlConnection(Properties.Settings.Default.connString);
            await connection.OpenAsync();
            SqlDataReader sqlReader = null;
            SqlCommand command = new SqlCommand(str, connection);
            int l = 0;
            dataGridView1.ColumnCount = 13;
            dataGridView1.Columns[0].HeaderText = "Id";
            dataGridView1.Columns[1].HeaderText = "Имя";
            dataGridView1.Columns[2].HeaderText = "Фамилия";
            dataGridView1.Columns[3].HeaderText = "Дата рождения";
            dataGridView1.Columns[4].HeaderText = "Пол";
            dataGridView1.Columns[5].HeaderText = "Страна";
            dataGridView1.Columns[6].HeaderText = "Адрес";
            dataGridView1.Columns[7].HeaderText = "Образование";
            dataGridView1.Columns[8].HeaderText = "Специализация";
            dataGridView1.Columns[9].HeaderText = "Id вакансии";
            dataGridView1.Columns[10].HeaderText = "Номер телефона";
            dataGridView1.Columns[11].HeaderText = "Заключение";
            dataGridView1.Columns[12].HeaderText = "Группа";
            try
            {
                sqlReader = await command.ExecuteReaderAsync();
                while (await sqlReader.ReadAsync())
                {
                    dataGridView1.Rows.Add();
                    dataGridView1.Rows[l].Cells[0].Value = Convert.ToString(sqlReader["ApplicantID"]);
                    dataGridView1.Rows[l].Cells[1].Value = Convert.ToString(sqlReader["FirstName"]);
                    dataGridView1.Rows[l].Cells[2].Value = Convert.ToString(sqlReader["LastName"]);
                    dataGridView1.Rows[l].Cells[3].Value = Convert.ToString(sqlReader["BirthDate"]);
                    dataGridView1.Rows[l].Cells[4].Value = Convert.ToString(sqlReader["Gender"]);
                    dataGridView1.Rows[l].Cells[5].Value = Convert.ToString(sqlReader["Country"]);
                    dataGridView1.Rows[l].Cells[6].Value = Convert.ToString(sqlReader["Residence"]);
                    dataGridView1.Rows[l].Cells[7].Value = Convert.ToString(sqlReader["Education"]);
                    dataGridView1.Rows[l].Cells[8].Value = Convert.ToString(sqlReader["Specialization"]);
                    dataGridView1.Rows[l].Cells[9].Value = Convert.ToString(sqlReader["VacancyID"]);
                    dataGridView1.Rows[l].Cells[10].Value = Convert.ToString(sqlReader["PhoneNumber"]);
                    dataGridView1.Rows[l].Cells[11].Value = Convert.ToString(sqlReader["Conclusion"]);
                    dataGridView1.Rows[l].Cells[12].Value = Convert.ToString(sqlReader["GroupName"]);
                    ++l;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                if (sqlReader != null)
                    sqlReader.Close();
            }

        }

        private void Button1_Click(object sender, EventArgs e)/*Найти кандидата по номеру телефона*/
        {
            string n = Convert.ToString(maskedTextBox1.Text);//Считывание введенного номера телефона
            string str = String.Format("SELECT * FROM Selection.Applicants WHERE PhoneNumber = '{0}'", n);
            Inquiry(str);//Передача запроса в метод
        }

        private void Button2_Click(object sender, EventArgs e)//Найти кандидата по id вакансии
        {
            if (checkBox2.Checked)
            {
                int id = Convert.ToInt32(numericUpDown1.Value);
                string str = String.Format("SELECT * FROM Selection.Applicants WHERE VacancyID = {0} AND Conclusion = 'Tests passed'", id);
                Inquiry(str);//Передача запроса в метод
            }
            else
            {
                int id = Convert.ToInt32(numericUpDown1.Value);
                string str = String.Format("SELECT * FROM Selection.Applicants WHERE VacancyID = {0}", id);
                Inquiry(str);//Передача запроса в метод
            }
        }

        private void Button3_Click(object sender, EventArgs e)//Подобрать претендента по уровню образования и специализации
        {
            string edu = Convert.ToString(textBox2.Text);
            string spec = Convert.ToString(textBox3.Text);
            string str = String.Format("SELECT * FROM Selection.Applicants WHERE Education = '{0}' AND Specialization = '{1}'", edu, spec);
            Inquiry(str);//Передача запроса в метод
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                int id = Convert.ToInt32(numericUpDown2.Value);
                string str = String.Format("SELECT * FROM Selection.Applicants WHERE ApplicantID = {0}", id);
                Inquiry(str);//Передача запроса в метод
            }
            else
            {
                string fn = Convert.ToString(textBox1.Text);
                string ln = Convert.ToString(textBox4.Text);
                string co = Convert.ToString(textBox5.Text);
                string str = String.Format("SELECT * FROM Selection.Applicants WHERE FirstName = '{0}' AND LastName = '{1}' AND Country = '{2}'", fn, ln, co);
                Inquiry(str);//Передача запроса в метод
            }
        }
    }
}

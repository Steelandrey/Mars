//Форма "Навигация"
using System;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace MarsApp
{
    public partial class Navigation : Form
    {
        public Navigation()
        {
            InitializeComponent();
        }
        private void AddApplicant_Click(object sender, EventArgs e)
        {
            Form frm = new addApplicant();
            frm.Show();
        }

        private void SelectApplicants_Click(object sender, EventArgs e)
        {
            Form frm = new findApplicants();
            frm.Show();
        }

        private async void Notice_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            dataGridView1.Columns.Clear();
            SqlConnection connection = new SqlConnection(Properties.Settings.Default.connString);
            await connection.OpenAsync();
            SqlDataReader sqlReader = null;
            SqlCommand command = new SqlCommand("SELECT * FROM Staff.Notice", connection);
            int l = 0;
            dataGridView1.ColumnCount = 3;
            dataGridView1.Columns[0].HeaderText = "Id";
            dataGridView1.Columns[1].HeaderText = "Уведомление";
            dataGridView1.Columns[2].HeaderText = "Время";
            try
            {
                sqlReader = await command.ExecuteReaderAsync();
                while (await sqlReader.ReadAsync())
                {
                    dataGridView1.Rows.Add();
                    dataGridView1.Rows[l].Cells[0].Value = Convert.ToString(sqlReader["ID"]);
                    dataGridView1.Rows[l].Cells[1].Value = Convert.ToString(sqlReader["Notice"]);
                    dataGridView1.Rows[l].Cells[2].Value = Convert.ToString(sqlReader["Date_Time"]);
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

        private async void ResTests_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            dataGridView1.Columns.Clear();
            SqlConnection connection = new SqlConnection(Properties.Settings.Default.connString);
            await connection.OpenAsync();
            SqlDataReader sqlReader = null;
            SqlCommand command = new SqlCommand("SELECT * FROM Selection.ResTest", connection);
            int l = 0;
            dataGridView1.ColumnCount = 5;
            dataGridView1.Columns[0].HeaderText = "Id";
            dataGridView1.Columns[1].HeaderText = "Id теста";
            dataGridView1.Columns[2].HeaderText = "Название";
            dataGridView1.Columns[3].HeaderText = "Успех";
            dataGridView1.Columns[4].HeaderText = "Время";
            try
            {
                sqlReader = await command.ExecuteReaderAsync();
                while (await sqlReader.ReadAsync())
                {
                    dataGridView1.Rows.Add();
                    dataGridView1.Rows[l].Cells[0].Value = Convert.ToString(sqlReader["ID"]);
                    dataGridView1.Rows[l].Cells[1].Value = Convert.ToString(sqlReader["TestID"]);
                    dataGridView1.Rows[l].Cells[2].Value = Convert.ToString(sqlReader["TestName"]);
                    dataGridView1.Rows[l].Cells[3].Value = Convert.ToString(sqlReader["Success"]);
                    dataGridView1.Rows[l].Cells[4].Value = Convert.ToString(sqlReader["Date_time"]);
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

        private void Conclusion_Click(object sender, EventArgs e)
        {
            Form frm = new addConclusion();
            frm.Show();
        }
    }
}

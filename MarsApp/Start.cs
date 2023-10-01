//Форма "Старт"
using System;
using System.Windows.Forms;

namespace MarsApp
{
    public partial class Start : Form
    {
        public Start()
        {
            InitializeComponent();
            textBox1.Text = "selection_staff";
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            string log = Convert.ToString(textBox1.Text);
            string pass = Convert.ToString(textBox2.Text);
            if (log == "selection_staff" && pass == "mars")
            {
                label1.Text = "";
                Form frm = new Navigation();
                frm.Show();
            }
            else
            {
                label1.Text = "Неверно введён логин или пароль";
            }
        }
    }
}

using System;
using System.Windows.Forms;

namespace Random_Selection
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int minValue = (int)numericUpDown1.Value;
            int maxValue = (int)numericUpDown2.Value;

            Random random = new Random();

            int randomNumber = random.Next(minValue, maxValue + 1);

            textBox1.Text = randomNumber.ToString();
        }

        private void menuItem2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void menuItem4_Click(object sender, EventArgs e)
        {
            Form1 existingForm = Application.OpenForms["Form1"] as Form1;

            if (existingForm != null)
            {
                existingForm.BringToFront();
            }
            else
            {
                Form1 newForm = new Form1();
                newForm.Show();
            }
        }
    }
}

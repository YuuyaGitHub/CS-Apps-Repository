using System;
using System.Windows.Forms;

namespace Random_Selection
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string inputText = textBox1.Text;

            string[] lines = inputText.Split(new[] { '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);
            string[] ignoreChars = { "=", "-" };

            Random random = new Random();
            int randomLineIndex;

            do
            {
                randomLineIndex = random.Next(lines.Length);
            } while (IsIgnoredLine(lines[randomLineIndex], ignoreChars));

            string randomLine = lines[randomLineIndex];

            textBox2.Text += randomLine + Environment.NewLine;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox2.Clear();
        }

        private void menuItem2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void menuItem4_Click(object sender, EventArgs e)
        {
            Form1 existingForm = Application.OpenForms["Form2"] as Form1;

            if (existingForm != null)
            {
                existingForm.BringToFront();
            }
            else
            {
                Form2 newForm = new Form2();
                newForm.Show();
            }
        }
        private bool IsIgnoredLine(string line, string[] ignoreChars)
        {
            if (string.IsNullOrWhiteSpace(line))
            {
                return true;
            }

            foreach (string ignoreChar in ignoreChars)
            {
                if (line.Contains(ignoreChar))
                {
                    return true;
                }
            }
            return false;
        }
    }
}
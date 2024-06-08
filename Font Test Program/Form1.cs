using System;
using System.IO;
using System.Windows.Forms;

namespace Font_Test_Program
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void menuItem1_Click(object sender, EventArgs e)
        {
            FontDialog fd = new FontDialog();

            fd.Font = textBox1.Font;
            fd.MinSize = 1;
            fd.MaxSize = 9999;
            fd.ShowEffects = false;
            fd.FontMustExist = true;
            fd.AllowVerticalFonts = false;
            fd.ShowEffects = false;

            if (fd.ShowDialog() != DialogResult.Cancel)
            {
                textBox1.Font = fd.Font;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            // Show Font Name in Status Bar
            statusBar1.Text = "Font Name: " + textBox1.Font;
        }

        private void menuItem2_Click(object sender, EventArgs e)
        {
            EnterSampleText();
        }

        private void EnterSampleText()
        {
            // Get the application executable directory
            string appDirectory = AppDomain.CurrentDomain.BaseDirectory;
            // Construct the file path
            string filePath = Path.Combine(appDirectory, "sampletext.txt");

            if (File.Exists(filePath))
            {
                // If the file exists, read its contents and display them in textBox1
                string fileContent = File.ReadAllText(filePath);
                textBox1.Text = fileContent;
            }
            else
            {
                // If the file does not exist, prompt to perform the default sample text
                ConfimDefaultSampleText();
            }
        }
        private void ConfimDefaultSampleText()
        {
            DialogResult result = MessageBox.Show("sampletext.txt is missing. Would you like to load the application's built-in text?",
                "Enter Sample Text",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Exclamation);

            if (result == DialogResult.Yes)
            {
                // This is the built-in sample text embedded in the application

                // Show Sample Text
                string sampleText1 = "This is a Sample Text\r\nこれはサンプルテキストです";
                textBox1.Text = sampleText1;
            }
        }
    }
}

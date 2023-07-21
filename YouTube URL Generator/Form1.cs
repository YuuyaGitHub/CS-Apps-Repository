using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace YouTube_URL_Generator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            textBox2.Text = "http://www.youtube.com/results?search_query=" + textBox1.Text;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            textBox2.Text = "http://www.m.youtube.com/results?search_query=" + textBox1.Text;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(textBox2.Text);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(textBox2.Text);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true)
            {
                textBox2.Text = "http://www.youtube.com/results?search_query=" + textBox1.Text;
            }
            else if (radioButton2.Checked == true)
            {
                textBox2.Text = "http://www.m.youtube.com/results?search_query=" + textBox1.Text;
            }
        }
    }
}

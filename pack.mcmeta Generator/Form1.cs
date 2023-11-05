using System;
using System.Windows.Forms;
using System.IO;

namespace pack.mcmeta_Generator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void menuItem2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void menuItem4_Click(object sender, EventArgs e)
        {
            pack_format_Versions f = new pack_format_Versions();
            f.Show(this);
        }

        private void menuItem6_Click(object sender, EventArgs e)
        {
            About f = new About();
            f.ShowDialog(this);
            f.Dispose();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Minecraft リソースパック/データパック|*.mcmeta";
            saveFileDialog.FileName = "pack.mcmeta";
            saveFileDialog.Title = "pack.mcmetaの保存";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    int packFormat = (int)numericUpDown1.Value;
                    string description = textBox1.Text;
                    string mcmetaContent = $"{{\r\n  \"pack\": {{\r\n    \"pack_format\": {packFormat},\r\n    \"description\": \"{description}\"\r\n  }}\r\n}}";

                    File.WriteAllText(saveFileDialog.FileName, mcmetaContent);

                }
                catch (Exception ex)
                {
                    MessageBox.Show($"エラーが発生しました: {ex.Message}", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}

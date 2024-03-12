using System;
using System.Diagnostics;
using System.Drawing;
using System.Security.Cryptography;
using System.Windows.Forms;

namespace NotificationApp_v2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            comboBox1.SelectedIndex = 0;

            Icon DefaultIcon = Icon.ExtractAssociatedIcon(Process.GetCurrentProcess().MainModule.FileName);
            notifyIcon1.Icon = DefaultIcon;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedItemText = comboBox1.Text;

            if (selectedItemText == "なし")
            {
                notifyIcon1.BalloonTipIcon = ToolTipIcon.None;
            }
            else if (selectedItemText == "Info (情報)")
            {
                notifyIcon1.BalloonTipIcon = ToolTipIcon.Info;
            }
            else if (selectedItemText == "Warning (警告)")
            {
                notifyIcon1.BalloonTipIcon = ToolTipIcon.Warning;
            }
            else if (selectedItemText == "Error (エラー)")
            {
                notifyIcon1.BalloonTipIcon = ToolTipIcon.Error;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            notifyIcon1.BalloonTipTitle = textBox1.Text;
            notifyIcon1.BalloonTipText = textBox2.Text;
            notifyIcon1.ShowBalloonTip(5000);
        }

        private void menuItem2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void menuItem4_Click(object sender, EventArgs e)
        {
            MessageBox.Show("通知が表示されない場合は、次の方法をお試してください。\r\n\r\nWindows 10の場合: 集中モードをオフにする\r\nWindows 11の場合: 応答不可をオフにする",
                "通知が表示されない場合",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }

        private void menuItem5_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Windowsのバージョンによって、表示される形式が異なります。\r\n\r\nWindows 8.1以前: バールンとして表示されます。\r\nWindows 10以降の場合: 通知として表示されます。",
                "通知はどのように表示されますか?",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }

        private void menuItem7_Click(object sender, EventArgs e)
        {
            MessageBox.Show("NotificationApp v2\r\nby Yuuya\r\nCopyright © 2020-2024 Yuuya.",
                "バージョン情報",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }

        private void menuItem9_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();

            ofd.Filter = "アイコンファイル(*.ico)|*.ico";
            ofd.Title = "アイコンの選択";
            ofd.RestoreDirectory = true;

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                notifyIcon1.Icon = new Icon(ofd.FileName);
            }
        }
    }
}

using System;
using System.Windows.Forms;
using System.IO;

namespace Yuuya_Description_Generator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                //概要欄の内容(予告なく変更される場合があります)
                string generatedText = "今日の一言: " + textBox1.Text + "\r\n\r\n"
                    + textBox2.Text + "\r\n\r\n"
                    + "チャンネル登録お願いします！\r\n"
                    + "https://www.youtube.com/channel/UCKMQY0OXZhdiRnbGN9Nm5kA?sub_confirmation=1\r\n\r\n"
                    + "Discord: https://discord.gg/gnvfE46wdr\r\n"
                    + "Discord ID: yuuyachannel\r\n\r\n"
                    + "サブチャンネル: https://youtube.com/channel/UCILL45rdM3CF7d7uW5sqihg\r\n"
                    + "第3チャンネル: https://youtube.com/channel/UCvBOeLnUBVZ0zxdCoxuKT3A\r\n\r\n"
                    + "ホームページ: https://yuuya20061202.wixsite.com/website\r\n\r\n";

                //ハッシュタグ欄の各行に「#」を追加することでハッシュタグを生成
                string[] lines = textBox3.Text.Split(new string[] { Environment.NewLine }, StringSplitOptions.None);
                for (int i = 0; i < lines.Length; i++)
                {
                    lines[i] = "#" + lines[i];
                }
                string hashtaggedText = string.Join(Environment.NewLine, lines);

                generatedText += hashtaggedText;

                //保存ダイアログを表示
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "テキストファイル|*.txt";
                saveFileDialog.Title = "保存先の選択";
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    //概要欄の結果をファイルに書き込む
                    File.WriteAllText(saveFileDialog.FileName, generatedText);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("エラーが発生しました: " + ex.Message, "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}

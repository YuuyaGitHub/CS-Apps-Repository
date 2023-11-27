using System;
using System.Drawing;
using System.Windows.Forms;

namespace Modulo_7_Validation_Program
{
    public partial class Form1 : Form
    {
        private bool isUpdating = false;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //結果表示の初期化
            label3.ForeColor = Color.Black;
            label3.Text = "キーが入力されていません";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // テキストボックスから番号を取得
            string inputNumber = textBox1.Text;

            // 入力がxxx-yyyyyyyの形式であるかを確認
            if (System.Text.RegularExpressions.Regex.IsMatch(inputNumber, @"^\d{3}-\d{7}$"))
            {
                // Modulo-7アルゴリズムで番号を検証
                if (IsModulo7Valid(inputNumber))
                {
                    // 正しい場合は緑色で表示
                    label3.ForeColor = Color.Green;
                    label3.Text = "有効なキーです";
                }
                else
                {
                    // 正しくない場合は赤色で表示
                    label3.ForeColor = Color.Red;
                    label3.Text = "無効なキーです";
                }
            }
            else
            {
                // 適切でない場合は正しい形式で入力するように促す
                label3.ForeColor = Color.Black;
                label3.Text = "無効な形式です。正しい形式で入力してください（例: xxx-yyyyyyy）";
            }
        }
        private bool IsModulo7Valid(string inputNumber)
        {
            // xxx-yyyyyyyの部分を取得
            string numericPart = inputNumber.Substring(0, 3) + inputNumber.Substring(4);

            // 数値を取得
            if (int.TryParse(numericPart, out int numericValue))
            {
                // Modulo-7アルゴリズムを適用して検証
                return numericValue % 7 == 0;
            }

            // 数値でない場合は無効
            return false;
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            // ハイフンと数字以外を入力できないようにする
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '-')
            {
                e.Handled = true;
            }

            // ハイフンが2回入力出来ないようにする
            if (e.KeyChar == '-' && (sender as TextBox).Text.IndexOf('-') > -1)
            {
                e.Handled = true;
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (isUpdating)
                return;

            int selectionStart = textBox1.SelectionStart;

            // テキストがハイフンだらけになるのを防ぐ
            if (textBox1.Text == new string('-', textBox1.Text.Length))
            {
                textBox1.Text = "";
                return;
            }

            string formattedText = FormatText(textBox1.Text);

            isUpdating = true;
            textBox1.Text = formattedText;
            isUpdating = false;

            // カーソル位置を一番右端に設定
            textBox1.SelectionStart = textBox1.Text.Length;
            textBox1.SelectionLength = 0; // カーソルを一文字分に設定
        }

        private string FormatText(string inputText)
        {
            // ハイフンを削除
            string cleanedText = inputText.Replace("-", "");

            // ハイフンを挿入
            if (cleanedText.Length >= 3)
            {
                cleanedText = cleanedText.Insert(3, "-");
            }

            return cleanedText;
        }
    }
}

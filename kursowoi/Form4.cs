using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;

namespace kursowoi
{
    public partial class Form4 : Form
    {
        Stopwatch clock;
        algoritm Encryptor;
        public Form4()
        {
            clock = new Stopwatch();
            Encryptor = new algoritm();
            InitializeComponent();
        }

        private void check_Click(object sender, EventArgs e)
        {
            clock.Restart();
            foreach (char letter in message.Text)
            {
                if (letter > 255)
                {
                    code.Enabled = false;
                    status_text.Text = "Русские буквы в зашифровываемом послании";
                    return;
                }
            }
            if (message.Text.Length <= maskedtext.Text.Length)
            {
                code.Enabled = true;
                status_text.Text = "Можно шифровать, на проверку затраченно " + clock.ElapsedMilliseconds + " миллисекунд";
                return;
            }
            else
            {
                code.Enabled = false;
                status_text.Text = "в этом сообщении можно скрыть " + (maskedtext.Text.Length).ToString() + " символов,введено " + message.Text.Length.ToString() + " символов";
                return;
            }
        }

        private void code_Click(object sender, EventArgs e)
        {
            clock.Restart();
            Encryptor.SetStrings(message.Text, null, message.Text.Length);
            Encryptor.ColorCoding(ref maskedtext,ref progr);
            status_text.Text = "Зашифрованно, затраченно " + clock.ElapsedMilliseconds + " миллисекунд";
        }

        private void encode_Click(object sender, EventArgs e)
        {
            clock.Restart();
            message.Text = "";
            message.Text=Encryptor.ColorEncoding(ref maskedtext,ref progr);
            status_text.Text = "Расшифрованно, затраченно " + clock.ElapsedMilliseconds + " миллисекунд";
        }

        private void test_Click(object sender, EventArgs e)
        {
            string res = "";
            maskedtext.SelectionLength = 1;
            maskedtext.SelectionStart = 0;
            for (int i = 0; i < maskedtext.Text.Length; i++)
            {
                res += Encryptor.DecryptColorInByte(maskedtext.SelectionColor);
                maskedtext.SelectionStart++;
            }
            Bits bt = new Bits(res);
            bt.ShowDialog();
        }

        private void message_TextChanged(object sender, EventArgs e)
        {
            code.Enabled = false;
            status_text.Text = "Текст в контейнере изменился, необходима проверка вместимости";
        }

        private void maskedtext_TextChanged(object sender, EventArgs e)
        {
            code.Enabled = false;
            status_text.Text = "Текст в шифруемом сообщении изменился, необходима проверка вместимости";
        }

        private void save_Click(object sender, EventArgs e)
        {
            SaveFileDialog File = new SaveFileDialog();
            File.Title = "Открыть";
            string patch = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            File.InitialDirectory = patch;
            File.Filter = "Text|*.rtf|All|*.*";
            File.FilterIndex = 1;
            File.RestoreDirectory = true;
            if (File.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    maskedtext.SaveFile(File.FileName, RichTextBoxStreamType.RichText);
                }
                catch (Exception ex) { MessageBox.Show("не удалось прочитать фаил: " + ex.Message); }
            }
        }

        private void load_Click(object sender, EventArgs e)
        {
            OpenFileDialog File = new OpenFileDialog();
            File.Title = "Открыть";
            string patch = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            File.InitialDirectory = patch;
            File.Filter = "Text|*.rtf|All|*.*";
            File.FilterIndex = 1;
            File.RestoreDirectory = true;
            if (File.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    maskedtext.LoadFile(File.FileName, RichTextBoxStreamType.RichText);
                }
                catch (Exception ex) { MessageBox.Show("не удалось прочитать фаил: " + ex.Message); }
            }
        }
    }
}

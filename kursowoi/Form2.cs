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
    public partial class Form2 : Form
    {
        Stopwatch clock;
        algoritm Encryptor;
        public Form2()
        {
            clock = new Stopwatch();
            Encryptor = new algoritm();
            InitializeComponent();
        }

        private void check_Click(object sender, EventArgs e)
        {
            clock.Restart();
            int counter = 0;
            progr.Value = 0;
            progr.Maximum = maskedtext.Text.Length + message.Text.Length;
            foreach (char letter in maskedtext.Text)
            {
                if (letter == 32 || letter == 160) counter++;//32 обычный пробел, 160 неразрывный
                progr.PerformStep();
            }
            foreach (char letter in message.Text)
            {
                if (letter > 255)
                {
                    code.Enabled = false;
                    status_text.Text = "Русские буквы в зашифровываемом послании";
                    return;
                }
                progr.PerformStep();
            }
            if (message.Text.Length <= counter / 8)
            {
                code.Enabled = true;
                status_text.Text = "Можно шифровать, на проверку затраченно " + clock.ElapsedMilliseconds + " миллисекунд";
                return;
            }
            else
            {
                code.Enabled = false;
                status_text.Text = "в этом сообщении можно скрыть " + (counter / 8).ToString() + " символов,введено " + message.Text.Length.ToString() + " символов";
                return;
            }
        }

        private void maskedtext_TextChanged(object sender, EventArgs e)
        {
            code.Enabled = false;
            status_text.Text = "Текст в контейнере изменился, необходима проверка вместимости";
        }

        private void message_TextChanged(object sender, EventArgs e)
        {
            code.Enabled = false;
            status_text.Text = "Текст в шифруемом сообщении изменился, необходима проверка вместимости";
        }

        private void code_Click(object sender, EventArgs e)
        {
            clock.Restart();
            Encryptor.SetStrings(message.Text, maskedtext.Text, message.Text.Length);
            maskedtext.Text = Encryptor.SpaceCoding();
            status_text.Text = "Зашифрованно, затраченно " + clock.ElapsedMilliseconds + " миллисекунд";

        }

        private void test_Click(object sender, EventArgs e)
        {
            Bits bt = new Bits(Encryptor.ToSingleBitsSpaces(maskedtext.Text));
            bt.ShowDialog();
            
        }
        private void encode_Click(object sender, EventArgs e)
        {
            clock.Restart();
            message.Text = "";
            Encryptor.SetStrings(message.Text, maskedtext.Text, message.Text.Length);
            message.Text = Encryptor.SpaceDecoding();
            status_text.Text = "Расшифрованно, затраченно " + clock.ElapsedMilliseconds + " миллисекунд";
        }

        private void button1_Click(object sender, EventArgs e)//сохранение текста стегоконтейнера
        {
            SaveFileDialog File = new SaveFileDialog();
            File.Title = "Открыть";
            string patch = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            File.InitialDirectory = patch;
            File.Filter = "Text|*.txt|All|*.*";
            File.FilterIndex = 1;
            File.RestoreDirectory = true;
            if (File.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    maskedtext.SaveFile(File.FileName, RichTextBoxStreamType.PlainText);
                }
                catch (Exception ex) { MessageBox.Show("не удалось прочитать фаил: " + ex.Message); }
            }
        }

        private void load_Click(object sender, EventArgs e)//загрузка текста стегоконтейнера
        {
            OpenFileDialog File = new OpenFileDialog();
            File.Title = "Открыть";
            string patch = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            File.InitialDirectory = patch;
            File.Filter = "Text|*.txt|All|*.*";
            File.FilterIndex = 1;
            File.RestoreDirectory = true;
            if (File.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    maskedtext.LoadFile(File.FileName, RichTextBoxStreamType.PlainText);
                }
                catch (Exception ex) { MessageBox.Show("не удалось прочитать фаил: " + ex.Message); }
            }
        }
    }
}

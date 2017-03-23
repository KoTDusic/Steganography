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
    public partial class Form3 : Form
    {
        Stopwatch clock;
        algoritm Encryptor;
        public Form3()
        {
            clock = new Stopwatch();
            Encryptor = new algoritm();
            InitializeComponent();
        }

        private void save_Click(object sender, EventArgs e)
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

        private void load_Click(object sender, EventArgs e)
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

        private void check_Click(object sender, EventArgs e)
        {
            clock.Restart();
            int counter = 0;
            Encryptor.SetListLength(maskedtext.Text.Length);
            progr.Value = 0;
            progr.Maximum = maskedtext.Text.Length;
            int temp = maskedtext.Text.Length;
            for (int i = 0; i < temp;i++)
            {
                if (Encryptor.bukv.compare(maskedtext.Text[i]))//узкое место производительности-сравнение
                {
                    Encryptor.IndexMas.Add(i);
                    counter++;
                }
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

        private void code_Click(object sender, EventArgs e)
        {
            clock.Restart();
            Encryptor.SetStrings(message.Text, maskedtext.Text, message.Text.Length);
            maskedtext.Text = Encryptor.RusEnCoding();
            status_text.Text = "Зашифрованно, затраченно " + clock.ElapsedMilliseconds + " миллисекунд";
        }

        private void test_Click(object sender, EventArgs e)
        {
            check_Click(null, null);
            //небольшой хак (принудительный вызов проверки для создания списка индексов)
            Bits bt = new Bits(Encryptor.ToSingleBitsLetters(maskedtext.Text));
            bt.ShowDialog();
        }

        private void encode_Click(object sender, EventArgs e)
        {
            message.Text = "";
            clock.Restart();
            check_Click(null, null);
            Encryptor.SetStrings(message.Text, maskedtext.Text, message.Text.Length);
            message.Text = Encryptor.RusEnDecoding();
            status_text.Text = "Расшифрованно, затраченно " + clock.ElapsedMilliseconds + " миллисекунд";
        }

        private void message_TextChanged(object sender, EventArgs e)
        {
            code.Enabled = false;
            status_text.Text = "Текст в шифруемом сообщении изменился, необходима проверка вместимости";
        }

        private void maskedtext_TextChanged(object sender, EventArgs e)
        {
            code.Enabled = false;
            status_text.Text = "Текст в контейнере изменился, необходима проверка вместимости";
        }
    }
}

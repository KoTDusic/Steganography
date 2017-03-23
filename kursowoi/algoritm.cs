using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
namespace kursowoi
{
    class simvols
    {
        public char[] rus_simv;//список русских букв
        public char [] eng_simv;//список английских букв
        int size;
        int iterator = 0;
        public simvols(int sz)
        {
            size = sz;
            rus_simv = new char[sz];
            eng_simv = new char[sz];
        }
        public char SetBool(bool setdata,char letter)
        {
            int ind = 0;
            if (letter > 255)
            {
                for (; ind < size; ind++)
                {
                    if ((letter == rus_simv[ind])) break;
                }
            }
            else
            {
                for (; ind < size; ind++)
                {
                    if ((letter == eng_simv[ind])) break;
                }
            }
            if (setdata) return eng_simv[ind];
            else return rus_simv[ind];
        }
        public bool ReadBool(char letter)
        {
            if (letter > 255)
            {
                for (int i = 0; i < size; i++)
                {
                    if (letter == rus_simv[i]) return false;
                }
            }
            else
            {
                for (int i = 0; i < size; i++)
                {
                    if (letter == eng_simv[i]) return true;
                }
            }
            return false;
        }
        public void AddPair(char rus, char eng)
        {
            rus_simv[iterator]=rus;
            eng_simv[iterator]=eng;
            iterator++;
        }
        public bool compare(char letter)
        {
            if (letter > 255)
            {
                    if (rus_simv.Contains(letter)) return true;
            }
            else
            {
                if (eng_simv.Contains(letter)) return true;
            }
            return false;
        }
    }
    class algoritm
    {
        string msg;//шифруемое сообщение
        string text;//стегоконтейнер
        int size;//длинна сообщения
        public simvols bukv; //массив соответствий английских букв русским
        public List<int> IndexMas;//индексы букв для второго алгоритма
        public void SetListLength(int length)//меняет длинну листа индексов с потерей данных
        {
            IndexMas = new List<int>(length);
        }
        public algoritm()
        {
            bukv=new simvols(17);
                       //рус англ
            bukv.AddPair('а','a');
            bukv.AddPair('о','o');
            bukv.AddPair('е','e');
            bukv.AddPair('с','c');
            bukv.AddPair('А','A');
            bukv.AddPair('В','B');
            bukv.AddPair('М','M');
            bukv.AddPair('Н','H');
            bukv.AddPair('Е','E');
            bukv.AddPair('Т','T');
            bukv.AddPair('О','O');
            bukv.AddPair('р','p');
            bukv.AddPair('Р','P');
            bukv.AddPair('К','K');
            bukv.AddPair('С','C');
            bukv.AddPair('Х','X');
            bukv.AddPair('х','x');
        }
        /// <summary>
        /// Возвращает двоичное представление строки(0-обычный пробел, 1-неразрывный)
        /// </summary>
        /// <param name="stroka"></param>
        /// <returns></returns>
        public string ToSingleBitsSpaces(string stroka)
        {
            StringBuilder tmp = new StringBuilder();
            foreach (char letter in stroka)
            {
                if (letter == 32) tmp.Append('0');
                if (letter == 160) tmp.Append('1');
            }
            return tmp.ToString();
        }
        /// <summary>
        /// расшифровать англо-русский символ(для 2 алгоритма)
        /// </summary>
        /// <param name="stroka"></param>
        /// <returns></returns>
        public string ToSingleBitsLetters(string stroka)
        {
            StringBuilder tmp = new StringBuilder();
            foreach (int index in IndexMas)
            {
                if (bukv.ReadBool(stroka[index])) tmp.Append('1');
                else tmp.Append('0');
            }
            return tmp.ToString();
        }
        public void SetStrings(string geted_msg, string geted_text, int geted_size)
        {
            msg = geted_msg;
            text = geted_text;
            size = geted_size;
        }
        public string SpaceCoding()
        {
            /*
             *В этом алгоритме обычный и неразрывный пробел служат как единица данных, 
             *обычный пробел (код 32) будет означать 0, неразрывный (код 160) будет 1.
             *
             */
            int birshift = 7;//текущий бит текущей буквы секретного сообщения, от 0 до 7
            StringBuilder result = new StringBuilder(text);//текст-контейнер
            StringBuilder msg_tmp = new StringBuilder(msg);//зашифровываемая строка
            int j = 0;//итератор для контейнера, внутри цикла не объявить
            int mask = 0;//вспомогательная переменная, нужная для проверки отдельных битов строки msg
            for (int i = 0; i < msg.Length; i++)
            {
                for (; j < text.Length; j++)
                {
                    if (birshift == -1)
                    {
                        birshift = 7;
                        break;
                    }
                    //32 обычный пробел(логический 0), 160 неразрывный(логическая 1)
                    if (result[j] == 32 || result[j] == 160) 
                    {
                        mask = 1 << birshift;
                        if ((msg[i] & mask) != 0)
                            result[j] = (char)160;
                        else result[j] = (char)32;
                        birshift--;
                        mask = 0;
                    }
                    
                }
            }
            //остальную часть текста заполняем нулями, убираем лишние неразрывные пробелы(если они есть)
            for (; j < text.Length; j++)
            {
                if (result[j] == 32 || result[j] == 160) //32 обычный пробел, 160 неразрывный
                {
                    result[j] = (char)32;
                }
            }
            return result.ToString();
        }
        public string SpaceDecoding() 
        {
            int birshift = 7;//текущий бит текущей буквы секретного сообщения, от 0 до 7
            StringBuilder result = new StringBuilder(text);//текст-контейнер с скрытой информацией
            StringBuilder msg_res = new StringBuilder();//расшифрованная строка
            int j = 0;//итератор для контейнера, внутри цикла не объявить
            int mask = 0;//вспомогательная переменная, нужная для проверки отдельных битов строки msg
            char bit_letter = (char)0;

                for (; j < text.Length; j++)
                {
                    if (birshift == -1)
                    {
                        birshift = 7;
                        //если 8 бит числа заполненны, добавляем в результирующую строку следующую букву
                        msg_res.Append(bit_letter);
                        bit_letter = (char)0;
                    }
                    //32 обычный пробел(логический 0), 160 неразрывный(логическая 1)
                    if (result[j] == 32 || result[j] == 160) 
                    {
                        mask = 1 << birshift;
                        if (result[j]==(char)160)
                            bit_letter=(char)(bit_letter | mask);
                        birshift--;
                        mask = 0;
                    }

                }
            return msg_res.ToString();
        }
        public string RusEnCoding()
        {
            /*
             *в этом алгоритме заменяются одинаковые по написанию русские и английские буквы, 
             *русская буква будет обозначать 0, английская 1.
             * использующиеся буквы: a A B M H e E T o O p P K c C X x
             */
            int birshift = 7;//текущий бит текущей буквы секретного сообщения, от 0 до 7
            StringBuilder result = new StringBuilder(text);//текст-контейнер
            StringBuilder msg_tmp = new StringBuilder(msg);//зашифровываемая строка
            int j = 0;//итератор для контейнера, внутри цикла не объявить
            int mask = 0;//вспомогательная переменная, нужная для проверки отдельных битов строки msg
            for (int i = 0; i < msg.Length; i++)
            {
                for (; j < IndexMas.Count; j++)
                {
                    if (birshift == -1)
                    {
                        birshift = 7;
                        break;
                    }
                        mask = 1 << birshift;
                        if ((msg[i] & mask) != 0)
                            result[IndexMas[j]] = bukv.SetBool(true,result[IndexMas[j]]);
                        else result[IndexMas[j]] = bukv.SetBool(false,result[IndexMas[j]]);
                        birshift--;
                        mask = 0;
                }
            }
            //остальную часть текста заполняем нулями, убираем лишние неразрывные пробелы(если они есть)
            for (; j <IndexMas.Count; j++)
            {
                result[IndexMas[j]] = bukv.SetBool(false, result[IndexMas[j]]);
            }
            return result.ToString();
        }
        public string RusEnDecoding()
        {
            int birshift = 7;//текущий бит текущей буквы секретного сообщения, от 0 до 7
            StringBuilder result = new StringBuilder(text);//текст-контейнер с скрытой информацией
            StringBuilder msg_res = new StringBuilder();//расшифрованная строка
            int j = 0;//итератор для контейнера, внутри цикла не объявить
            int mask = 0;//вспомогательная переменная, нужная для проверки отдельных битов строки msg
            char bit_letter = (char)0;

            for (; j < IndexMas.Count; j++)
            {
                if (birshift == -1)
                {
                    birshift = 7;
                    //если 8 бит числа заполненны, добавляем в результирующую строку следующую букву
                    msg_res.Append(bit_letter);
                    bit_letter = (char)0;
                }
                    mask = 1 << birshift;
                    if (bukv.ReadBool(result[IndexMas[j]]))
                        bit_letter = (char)(bit_letter | mask);
                    birshift--;
                    mask = 0;
            }
            return msg_res.ToString();
        }
        private Color CryptInColor(bool[] mas)
        {
            int Red=0;
            int Blue=0;
            int Green=0;
            if(mas[0]) Red|=(1<<0);
            if(mas[1]) Red|=(1<<1);
            if(mas[2]) Green|=(1<<0);
            if(mas[3]) Green|=(1<<1);
            if(mas[4]) Green|=(1<<2);
            if(mas[5]) Blue|=(1<<0);
            if(mas[6]) Blue|=(1<<1);
            if(mas[7]) Blue|=(1<<2);
            return Color.FromArgb(Red, Green, Blue);
        }
        private char DecryptInColor(Color clr)
        {
            
            int letter = 0;
            int index = 7;
            int Red = clr.R;
            int Blue = clr.B;
            int Green = clr.G;
            if ((Blue & (1 << 2)) != 0) letter |= (1 << index);
            index--;
            if ((Blue & (1 << 1)) != 0) letter |= (1 << index);
            index--;
            if ((Blue & (1 << 0)) != 0) letter |= (1 << index);
            index--;
            if ((Green & (1 << 2)) != 0) letter |= (1 << index);
            index--;
            if ((Green & (1 << 1)) != 0) letter |= (1 << index);
            index--;
            if ((Green & (1 << 0)) != 0) letter |= (1 << index);
            index--;
            if ((Red & (1 << 1)) != 0) letter |= (1 << index);
            index--;
            if ((Red & (1 << 0)) != 0) letter |= (1 << index);
            index--;
            return (char)letter;
        }
        public string DecryptColorInByte(Color clr)
        {
            int[] mas = new int[8];
            mas.Initialize();
            string res="";
            int index = 7;
            int Red = clr.R;
            int Blue = clr.B;
            int Green = clr.G;
            if ((Blue & (1 << 2)) != 0) mas[index]=1;
            index--;
            if ((Blue & (1 << 1)) != 0) mas[index] = 1;
            index--;
            if ((Blue & (1 << 0)) != 0) mas[index] = 1;
            index--;
            if ((Green & (1 << 2)) != 0) mas[index] = 1;
            index--;
            if ((Green & (1 << 1)) != 0) mas[index] = 1;
            index--;
            if ((Green & (1 << 0)) != 0) mas[index] = 1;
            index--;
            if ((Red & (1 << 1)) != 0) mas[index] = 1;
            index--;
            if ((Red & (1 << 0)) != 0) mas[index] = 1;
            foreach (int tmp in mas)
            {
                res+=Convert.ToString(tmp);
            }
            return res;
        }
        public void ColorCoding(ref RichTextBox container,ref ProgressBar progr)
        {
            bool [] letter = new bool[8];
            Color CodeColor=Color.FromArgb(255,0,132);
            container.SelectionStart = 0;
            container.SelectionLength = container.Text.Length;
            container.SelectionColor = Color.Black;
            container.SelectionLength = 1;
            int birshift = 7;//текущий бит текущей буквы секретного сообщения, от 0 до 7
            StringBuilder msg_tmp = new StringBuilder(msg);//зашифровываемая строка
            int mask = 0;//вспомогательная переменная, нужная для проверки отдельных битов строки msg
            int j = 0;//итератор для контейнера, внутри цикла не объявить
            progr.Maximum = msg.Length;
            progr.Step = 1;
            progr.Value = 0;
            for (; j < msg.Length; j++)
            {
                for (; ; birshift--)
                {
                    if (birshift == -1)
                    {
                        birshift = 7;
                        break;
                    }
                    mask = 1 << birshift;
                    if ((msg[j] & mask) != 0) letter[birshift] = true;
                    else letter[birshift] = false;
                    mask = 0;
                }
                container.SelectionStart=j;
                container.SelectionColor = CryptInColor(letter);
                progr.PerformStep();
            }
        }
        public string ColorEncoding(ref RichTextBox container, ref ProgressBar progr)
        {
            progr.Maximum = container.Text.Length;
            progr.Step = 1;
            progr.Value = 0;
            StringBuilder msg_res = new StringBuilder();//расшифрованная строка
            int j = 0;//итератор для контейнера, внутри цикла не объявить
            container.SelectionLength = 1;
            for (; j < container.Text.Length; j++)
            {
                container.SelectionStart = j;
                msg_res.Append(DecryptInColor(container.SelectionColor));
                progr.PerformStep();
            }
            return msg_res.ToString();
        }
    }
}

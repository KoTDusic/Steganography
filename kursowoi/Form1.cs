using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace kursowoi
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void select_Click(object sender, EventArgs e)
        {
            
            if (AlgoritmList.Text == @"алгоритм ""замена пробелов""")
            {
                Form2 okno = new Form2();
                okno.ShowDialog();
            }
            if (AlgoritmList.Text == @"алгоритм ""разные раскладки""")
            {
                Form3 okno = new Form3();
                okno.ShowDialog();
            }
            if (AlgoritmList.Text == @"алгоритм ""цвета""")
            {
                Form4 okno = new Form4();
                okno.ShowDialog();
            }
            if (AlgoritmList.Text == @"остальное")
            {
                MessageBox.Show("А других алгоритмов тут пока нету(");
            }
        }
    }
}

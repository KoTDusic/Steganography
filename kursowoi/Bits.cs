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
    public partial class Bits : Form
    {
        public Bits(string txt)
        {
            InitializeComponent();
            textbox.Text = txt;
        }
    }
}

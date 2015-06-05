using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JavaScript_EnDecoder
{
    public partial class Console : Form
    {
        public Console()
        {
            InitializeComponent();
        }

        public void LogToText(object text)
        {
            if (textBox1.Lines.Count() > 30)
            {
                textBox1.Text = "";
            }
            textBox1.Text += text.ToString() + Environment.NewLine;
        }
      
    }
}

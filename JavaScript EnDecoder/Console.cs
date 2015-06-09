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
            this.TopMost = true;
            this.WindowState = FormWindowState.Normal;
            if (textBox1.Lines.Count() > 30)
            {
                textBox1.Text = "";
            }
            textBox1.Text += text.ToString() + Environment.NewLine;
        }

        private void Console_Load(object sender, EventArgs e)
        {

        }

        private void Run_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.SendToBack();
        }

		private void textBox1_TextChanged(object sender, EventArgs e)
		{

		}
	}
}

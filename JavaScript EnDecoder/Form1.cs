using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using Jint;
using MCPE_Data_Reader;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace JavaScript_EnDecoder
{
    public partial class Form1 : Form
    {
        Level Runtime = new Level();
		Engine Eng = new Engine();

        public Form1()
        {
            
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Console main = new Console();
            //main.BringToFront();
            if (!StaticUtils.ConsoleIsRunning())
            {
                StaticUtils.startConsole();
            }
            StaticUtils.Focus();
            try
            {
                Eng.Execute(CleanText(textBox1.Text.ToString()));
            }
            catch (Exception except)
            {
                StaticUtils.log(except.ToString());
                MessageBox.Show("Jint error");
            }
            

        }

        private string CleanText(string text)
        {
            return text.Replace("Level.getTile", "LevelGetTile").Replace("Level.setTile", "LevelSetTile").Replace("Level.getData", "LevelGetData").Replace("ModPE.setItem", "ModPESetItem");
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            Eng.SetValue("clientMessage", new Action<object>(StaticUtils.log));
            Eng.SetValue("LevelGetTile", new Func<int, int, int, int>(Runtime.getTile));
            Eng.SetValue("LevelSetTile", new Action<int, int, int, int>(Runtime.setTile));
            Eng.SetValue("LevelGetData", new Func<int, int, int, int>(Runtime.getData));
            Eng.SetValue("ModPESetItem", new Action<int, string, int, string>(ModPE.setItem));
            this.Text = "modPE Sandbox";

            
        }
        

        private void GenerateEnvironment()
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            panel1.Hide();
            DialogResult result = Saver.ShowDialog();
            if (result == DialogResult.OK)
            {
                string name = Saver.FileName;
                File.WriteAllText(name, textBox1.Text);
            }
        }

        private void Saver_FileOk(object sender, CancelEventArgs e)
        {
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            panel1.Hide();
            if (Opener.ShowDialog() == DialogResult.OK)
            {
                textBox1.Text = System.IO.File.ReadAllText(Opener.FileName);
            }

        }

        private void MenuLoad_Click(object sender, EventArgs e)
        {
            panel2.Hide();
            if(panel1.Visible == true)
            {
                panel1.Hide();
            }
            else
                panel1.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            panel1.Hide();
            about aboutopen = new about();
            aboutopen.Show();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to Exit? Any unsaved changes will be lost.", "ModPE-Sandbox", MessageBoxButtons.YesNo) == DialogResult.No)
            {
                e.Cancel = true;
            }        
        }

        private void button5_Click(object sender, EventArgs e)
        {
            panel1.Hide();
            if (panel2.Visible == true)
            {
                panel2.Hide();
            }
            else
                panel2.Show();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            panel2.Hide();
            Font font = new Font("Microsoft Sans Serif", 8.0f, FontStyle.Regular);
            textBox1.Font = font;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            panel2.Hide();
            Font font = new Font("Microsoft Sans Serif", 10.0f, FontStyle.Regular);
            textBox1.Font = font;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            panel2.Hide();
            Font font = new Font("Microsoft Sans Serif", 12.0f, FontStyle.Regular);
            textBox1.Font = font;
        }

		private void LoadWorld_Click(object sender, EventArgs e)
		{
			DataReader WorldData = new DataReader(@"C:/level.ldb");
			var chunk = WorldData.getChunkID(0, 0);
			var BlockIDs = new List<int>();
			BlockIDs.Add(WorldData.getBlockID(chunk, 0, 0, 0));
		}
	}
}

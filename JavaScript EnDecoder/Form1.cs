using System;
using System.ComponentModel;
using System.Drawing;
using Jint;
using System.Windows.Forms;
using System.IO;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace JavaScript_EnDecoder
{
    public partial class Form1 : Form
    {
		private Dictionary<string, int> Hooks = new Dictionary<string, int>();
        Level Runtime = new Level();
		Engine Eng = new Engine();
		ModPE modPEInstance = new ModPE();
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
                Eng.Execute(textBox1.Text.ToString());
            }
            catch (Exception except)
            {
                StaticUtils.log(except.ToString());
            }
            

        }


        private void Form1_Load(object sender, EventArgs e)
        {
			Hooks.Add("modTick", 0);
			Hooks.Add("useItem", 6);
			Hooks.Add("procCmd", 1);
			Hooks.Add("newLevel", 0);
			Hooks.Add("leaveGame", 0);
			Hooks.Add("entityAddedHook", 1);
			Hooks.Add("entityRemovedHook", 1);
			Hooks.Add("deathHook", 2);
			Hooks.Add("levelEventHook", 6);
			Hooks.Add("blockEventHook", 5);
			HookList.DataSource = new BindingSource(Hooks, null);
			HookList.DisplayMember = "Key";
			HookList.ValueMember = "Value";
			if (!StaticUtils.ConsoleIsRunning())
			{
				StaticUtils.startConsole();
			}
			this.Focus();
			Eng.SetValue("clientMessage", new Action<object>(StaticUtils.log));
            Eng.SetValue("Level", Runtime);
			Eng.SetValue("ModPE", modPEInstance); //since the ModPE class is exposed here, we can call this function now from the scripting environment
            this.Text = "modPE Sandbox";       
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

		

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

		private void ModTick_Click(object sender, EventArgs e)
		{
			if (!StaticUtils.ConsoleIsRunning())
			{
				StaticUtils.startConsole();
			}
			StaticUtils.Focus();
			try
			{
				Eng.Execute(textBox1.Text.ToString());
			}
			catch (Exception except)
			{
				StaticUtils.log(except.ToString());
			}
			var helper = ((KeyValuePair<string, int>)HookList.SelectedItem).Key;
			var Hook = Eng.GetValue(helper);
			try
			{
				callHook(Hook, Convert.ToInt32(HookList.SelectedValue));
			}
			
			catch(Exception ex)
			{
				StaticUtils.log("The Hook is either missing or invalid");
			}
			
		}

		private void callHook(Jint.Native.JsValue func, int parameter)
		{
			switch (parameter)
			{
				case 0:
					func.Invoke();
					break;
				case 1:
					func.Invoke(textBox2.Text);
					break;

				case 2:
					func.Invoke(textBox2.Text, textBox3.Text);
					break;

				case 3:
					func.Invoke(textBox2.Text, textBox3.Text, textBox4.Text);
					break;

				case 4:
					func.Invoke(textBox2.Text, textBox3.Text, textBox4.Text, textBox5.Text);
					break;

				case 5:
					func.Invoke(textBox2.Text, textBox3.Text, textBox4.Text, textBox5.Text, textBox6.Text);
					break;

				case 6:
					func.Invoke(textBox2.Text, textBox3.Text, textBox4.Text, textBox5.Text, textBox6.Text, textBox7.Text);
					break;
			}
		}

		private void label3_Click(object sender, EventArgs e)
		{

		}

		private void HookList_SelectedIndexChanged(object sender, EventArgs e)
		{
			
			try
			{
                activateParams(Convert.ToInt32(HookList.SelectedValue));
			}
			catch(Exception er)
			{
				activateParams(0);
			}
			
		}
		private void activateParams(int count)
		{
			switch (count)
			{
				case 0:
					label2.Visible = false;
					textBox2.Visible = false;
					label3.Visible = false;
					textBox3.Visible = false;
					label4.Visible = false;
					textBox4.Visible = false;
					label5.Visible = false;
					textBox5.Visible = false;
					label6.Visible = false;
					textBox6.Visible = false;
					label7.Visible = false;
					textBox7.Visible = false;
					break;
				case 1:
					label2.Visible = true;
					textBox2.Visible = true;
					label3.Visible = false;
					textBox3.Visible = false;
					label4.Visible = false;
					textBox4.Visible = false;
					label5.Visible = false;
					textBox5.Visible = false;
					label6.Visible = false;
					textBox6.Visible = false;
					label7.Visible = false;
					textBox7.Visible = false;
					break;

				case 2:
					label2.Visible = true;
					textBox2.Visible = true;
					label3.Visible = true;
					textBox3.Visible = true;
					label4.Visible = false;
					textBox4.Visible = false;
					label5.Visible = false;
					textBox5.Visible = false;
					label6.Visible = false;
					textBox6.Visible = false;
					label7.Visible = false;
					textBox7.Visible = false;
					break;
				case 3:
					label2.Visible = true;
					textBox2.Visible = true;
					label3.Visible = true;
					textBox3.Visible = true;
					label4.Visible = true;
					textBox4.Visible = true;
					label5.Visible = false;
					textBox5.Visible = false;
					label6.Visible = false;
					textBox6.Visible = false;
					label7.Visible = false;
					textBox7.Visible = false;
					break;
				case 4:
					label2.Visible = true;
					textBox2.Visible = true;
					label3.Visible = true;
					textBox3.Visible = true;
					label4.Visible = true;
					textBox4.Visible = true;
					label5.Visible = true;
					textBox5.Visible = true;
					label6.Visible = false;
					textBox6.Visible = false;
					label7.Visible = false;
					textBox7.Visible = false;
					break;
				case 5:
					label2.Visible = true;
					textBox2.Visible = true;
					label3.Visible = true;
					textBox3.Visible = true;
					label4.Visible = true;
					textBox4.Visible = true;
					label5.Visible = true;
					textBox5.Visible = true;
					label6.Visible = true;
					textBox6.Visible = true;
					label7.Visible = false;
					textBox7.Visible = false;
					break;
				case 6:
					label2.Visible = true;
					textBox2.Visible = true;
					label3.Visible = true;
					textBox3.Visible = true;
					label4.Visible = true;
					textBox4.Visible = true;
					label5.Visible = true;
					textBox5.Visible = true;
					label6.Visible = true;
					textBox6.Visible = true;
					label7.Visible = true;
					textBox7.Visible = true;
					break;
				}
		}

		private void Serialize_Click(object sender, EventArgs e)
		{
			WorldSerializer world = new WorldSerializer(Runtime.getDesign(), modPEInstance.getItems(), modPEInstance.getBlocks());
			string text = world.serialize();
			MessageBox.Show(text);
		}
	}
}

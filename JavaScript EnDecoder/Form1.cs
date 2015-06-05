﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using Jint;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JavaScript_EnDecoder
{
    public partial class Form1 : Form
    {
        Level Runtime = new Level();
        Jint.Engine Eng = new Jint.Engine();
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
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

       
    }
}
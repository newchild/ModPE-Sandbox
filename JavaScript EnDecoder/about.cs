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
    public partial class about : Form
    {
        public about()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("http://www.minecraftforum.net/forums/minecraft-pocket-edition/mcpe-mods-tools/mcpe-wip-mods-tools/2434982-modpe-sandbox-debug-your-modpe-scripts-on-your");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://github.com/newchild/ModPE-Sandbox");
        }
    }
}

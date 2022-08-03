using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace proj1
{
    public partial class FAKat : Form
    {
        public FAKat()
        {
            InitializeComponent();
        }

        private void FAKat_Load(object sender, EventArgs e)
        {
            List<String> list = new List<string>();
            list.Add("                       /^--^\\       /^--^\\       /^--^\\");
            list.Add("                      \\____/     \\____/     \\____/");
            list.Add("                     /          \\   /          \\   /          \\");
            list.Add("KAT             |              | |              | |              |");
            list.Add("                     \\__  __/   \\__  __/   \\__  __/");
            list.Add("|^|^|^|^|^|^|^|^|^|^\\ \\^|^|^|^/ /^|^|^|^|^\\ \\^|^|^|^|^|^|^|^|^|^|^|^|");
            list.Add("| | | | | | | | | | | | | | | | | | |\\ \\| | |/ /| | | | | | | | | | \\ \\ | | | | | | | | | | | | | | | | | |");
            list.Add("#############/ /##\\ \\#######/ /#############");
            list.Add("| | | | | | | | | | | | | | | | | | |\\/| | | | \\/| | | | | | | | | |\\/ | | | | | | | | | | | | | | | | | | |");
            list.Add("|_|_|_|_|_|_|_|_|_|_|_|_|_|_|_|_|_|_|_|_|_|_|_|_|_|_|_|_|_|_|_|_|_|_|_|");

            listBox1.DataSource = list;
        }
    }
}

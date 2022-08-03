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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btn1_1_Click(object sender, EventArgs e)
        {
            FAdministracija f = new FAdministracija();
            Hide();
            f.Location = this.Location;
            f.ShowDialog();
            Show();
        }

        private void btn1_2_Click(object sender, EventArgs e)
        {
            Hide();
            FKupac f = new FKupac();
            f.Location = this.Location;
            f.ShowDialog();
            Show();
        }
    }
}

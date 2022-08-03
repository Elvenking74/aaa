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
    public partial class FAdministracija : Form
    {
        int hehe = 10;
        public FAdministracija()
        {
            InitializeComponent();
        }

        private void btn2_1_Click(object sender, EventArgs e)
        {
            FAFilm f = new FAFilm();
            Hide();
            f.Location = this.Location;
            f.ShowDialog();
            Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            hehe--;
            button1.Text = hehe.ToString();
            if (hehe == 0)
            {
                FAKat f = new FAKat();
                Hide();
                f.Location = this.Location;
                f.ShowDialog();
                Show();
                hehe = 10;
                button1.Text = "---";
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FAProjekcija f = new FAProjekcija();
            Hide();
            f.Location = this.Location;
            f.ShowDialog();
            Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            FASala f = new FASala();
            Hide();
            f.Location = this.Location;
            f.ShowDialog();
            Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            FARezervacija f = new FARezervacija();
            Hide();
            f.Location = this.Location;
            f.ShowDialog();
            Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            FAKupac f = new FAKupac();
            Hide();
            f.Location = this.Location;
            f.ShowDialog();
            Show();
        }

        private void FAdministracija_Load(object sender, EventArgs e)
        {

        }

        private void FAdministracija_FormClosed(object sender, FormClosedEventArgs e)
        {

        }

        private void FAdministracija_FormClosing(object sender, FormClosingEventArgs e)
        {
            
        }
    }
}

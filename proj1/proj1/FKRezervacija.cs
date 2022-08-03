using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Windows.Forms;

namespace proj1
{
    public partial class FKRezervacija : Form
    {
        public KKupac korisnik;
        List<KProjekcija> projekcije;
        List<KSala> sale;
        List<KFilm> filmovi;
        BinaryFormatter bf = new BinaryFormatter();

        public delegate void posaljiK(List<KRezervacija> ul);
        public posaljiK posalji;
        public FKRezervacija()
        {
            InitializeComponent();
        }

        private void FKRezervacija_Load(object sender, EventArgs e)
        {
            //-----------projekcije i listbox1---------------------------
            dateTimePicker1.MinDate = DateTime.Now.Date;

            List<KRezervacija> priv = new List<KRezervacija>();
            if (File.Exists("Projekcije"))
            {
                FileStream fs = File.OpenRead("Projekcije");
                projekcije = bf.Deserialize(fs) as List<KProjekcija>;
                List<KProjekcija> prjk = new List<KProjekcija>();
                fs.Dispose();
                foreach (KProjekcija p in projekcije)
                {
                    DateTime tme = new DateTime(p.Datum.Year, p.Datum.Month, p.Datum.Day, p.Vreme.Hour, p.Vreme.Minute, DateTime.Now.Second);
                    if (tme >= dateTimePicker1.Value)
                    {
                        prjk.Add(p);
                    }
                }
                listBox1.DataSource = prjk;

                int i = Convert.ToInt32(numericUpDown1.Value);
                if (prjk.Count != 0)
                {
                    int rez = i * prjk[listBox1.SelectedIndex].Cena;
                    textBox1.Text = rez.ToString();
                }
                
            }

            //-----------Sale--------------------------------------------

            if (File.Exists("Sale"))
            {
                FileStream fs = File.OpenRead("Sale");
                sale = bf.Deserialize(fs) as List<KSala>;
                fs.Dispose();
                comboBox1.DataSource = sale;

            }

            //-----------Filmovi-----------------------------------------

            if (File.Exists("Filmovi"))
            {
                FileStream fs = File.OpenRead("Filmovi");
                filmovi = bf.Deserialize(fs) as List<KFilm>;
                fs.Dispose();
                comboBox2.DataSource = filmovi;

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DateTime dp = dateTimePicker1.Value.Date;
            DateTime dk = dateTimePicker2.Value.Date;

            List<KProjekcija> proj = new List<KProjekcija>();

            foreach (KProjekcija p in projekcije)
            {
                if (p.Datum.Date >= dp.Date && p.Datum.Date <= dk.Date)
                {
                    proj.Add(p);
                }
            }

            if (comboBox2.Text.Trim().Length != 0)
            {
                if (comboBox2.SelectedItem == null)
                {
                    foreach (KProjekcija p in projekcije)
                    {
                        if (p.Film.Naziv != comboBox2.Text)
                        {
                            proj.Remove(p);
                        }
                    }
                }
                else
                {
                    foreach (KProjekcija p in projekcije)
                    {
                        if (p.Film.Naziv != filmovi[comboBox2.SelectedIndex].Naziv && p.Film.Naziv != comboBox2.Text)
                        {
                            proj.Remove(p);
                        }
                    }
                }
                
            }
            int c;

            List<KProjekcija> proj1 = proj;
            int i = 0;
            if (comboBox1.Text.Trim().Length != 0)
            {
                if (comboBox1.SelectedItem == null)
                {
                    proj1 = new List<KProjekcija>();
                }
                else
                {
                    foreach (KProjekcija p in proj)
                    {

                        if (p.Sala.Br_sale != sale[comboBox1.SelectedIndex].Br_sale && (Int32.TryParse(comboBox1.Text, out c) && p.Sala.Br_sale != c))
                        {

                            proj1.RemoveAt(i);
                            i--;
                        }
                        i++;
                    }
                }
            }

            listBox1.DataSource = proj;
        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            dateTimePicker2.MinDate = dateTimePicker1.Value.Date;
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            if (listBox1.Items.Count != 0)
            {
                int i = Convert.ToInt32(numericUpDown1.Value);
                int rez = i * projekcije[listBox1.SelectedIndex].Cena;
                textBox1.Text = rez.ToString();
            }
            else
                MessageBox.Show("Lista rezervacija je prazna");
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox1.Items.Count != 0)
            {
                int i = Convert.ToInt32(numericUpDown1.Value);
                int rez = i * projekcije[listBox1.SelectedIndex].Cena;
                textBox1.Text = rez.ToString();
            }
            else
                MessageBox.Show("Lista rezervacija je prazna");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (listBox1.Items.Count != 0)
            {
                int i = Convert.ToInt32(numericUpDown1.Value);
                int rez = i * projekcije[listBox1.SelectedIndex].Cena;
                KRezervacija rezerv = new KRezervacija(korisnik.Id, projekcije[listBox1.SelectedIndex].Id, i, rez);

                List<KRezervacija> rezervacije;
                if (File.Exists("Rezervacije"))
                {
                    FileStream fs = File.OpenRead("Rezervacije");

                    rezervacije = bf.Deserialize(fs) as List<KRezervacija>;
                    fs.Dispose();
                }
                else
                {
                    rezervacije = new List<KRezervacija>();
                }
                

                rezervacije.Add(rezerv);

                FileStream fs1 = File.OpenWrite("Rezervacije");
                bf.Serialize(fs1, rezervacije);
                fs1.Dispose();

                Close();
            }
            else
                MessageBox.Show("Lista rezervacija je prazna");
        }

        public void KKorisnik(KKupac k)
        {
            korisnik = k;
        }
    }
}

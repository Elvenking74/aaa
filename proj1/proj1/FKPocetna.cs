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
    public partial class FKPocetna : Form
    {
        public KKupac korisnik;
        List<KRezervacija> rez = new List<KRezervacija>();
        BinaryFormatter bf = new BinaryFormatter();
        public delegate void posaljiK(KKupac kup);
        public posaljiK posalji;

        public delegate void posaljiID(int id);
        public posaljiID pos; 

        public void KKorisnik(KKupac k)
        {
            korisnik = k;
        }

        public void UpdateList()
        {
            //--------------Rezervacije---------------------------------
            if (File.Exists("Rezervacije"))
            {
                FileStream fs2 = File.OpenRead("Rezervacije");
                rez = bf.Deserialize(fs2) as List<KRezervacija>;
                fs2.Dispose();
            }
            //----------------------------------------------------------
            //--------------update listbox1-----------------------------

            List<KRezervacija> lista = rez;
            List<KRezervacija> lista1 = new List<KRezervacija>();

            foreach (KRezervacija r1 in lista)
            {
                if (r1.Idk == korisnik.Id)
                {
                    lista1.Add(r1);
                }
            }

            listBox1.DataSource = lista1;
            //----------------------------------------------------------
        }
        public FKPocetna()
        {
            InitializeComponent();
        }

        private void FKPocetna_Load(object sender, EventArgs e)
        {
            linkLabel1.Text = korisnik.Ime;
            //--------------Rezervacije---------------------------------
            if (File.Exists("Rezervacije"))
            {
                FileStream fs2 = File.OpenRead("Rezervacije");
                rez = bf.Deserialize(fs2) as List<KRezervacija>;
                fs2.Dispose();
            }
            //----------------------------------------------------------
            //--------------update listbox1-----------------------------
            List<KRezervacija> lista = rez;
            List<KRezervacija> lista1 = new List<KRezervacija>();

            foreach (KRezervacija r1 in lista)
            {
                if (r1.Idk == korisnik.Id)
                {
                    lista1.Add(r1);
                }
            }

            listBox1.DataSource = lista1;
            //----------------------------------------------------------
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void FKPocetna_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (File.Exists("Rezervacije") && new FileInfo("Rezervacije").Length == 0)
            {
                File.Delete("Rezervacije");
            }
        }



        private void button3_Click(object sender, EventArgs e)
        {
            FKRezervacija f = new FKRezervacija();
            Hide();
            f.Location = this.Location;
            this.posalji = new posaljiK(f.KKorisnik);
            posalji(korisnik);
            f.ShowDialog();
            UpdateList();
            Show();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (rez.Count != 0)
            {
                //---------------Nadji indeks za brisanje--------------------
                int incr = 0;
                for (int i = 0; i <= listBox1.SelectedIndex; i++)
                {
                    if (rez[incr].Idk == korisnik.Id)
                    {
                        if (i == listBox1.SelectedIndex)
                            break;
                    }
                    else
                    {
                        i--;
                    }
                    incr++;
                }
                //-----------------------------------------------------------
                List<KRezervacija> lista = rez;
                lista.RemoveAt(incr);

                FileStream fs1 = File.OpenWrite("Rezervacije");
                bf.Serialize(fs1, lista);
                rez = lista;

                fs1.Dispose();

                List<KRezervacija> lista1 = new List<KRezervacija>();

                foreach (KRezervacija r1 in lista)
                {
                    if (r1.Idk == korisnik.Id)
                    {
                        lista1.Add(r1);
                    }
                }
                listBox1.DataSource = lista1;
            }
            else 
            {
                MessageBox.Show("Lista rezervacija je prazna");
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (listBox1.Items.Count != 0)
            {
                FKRUpdt f = new FKRUpdt();
                this.posalji = new posaljiK(f.KKorisnik);
                posalji(korisnik);

                this.pos = new posaljiID(f.IDRez);
                pos(listBox1.SelectedIndex);

                f.ShowDialog();


                UpdateList();

                
            }
            else 
            {
                MessageBox.Show("Lista rezervacija je prazna");
            }
        }

        private void FKPocetna_FormClosed(object sender, FormClosedEventArgs e)
        {
            
        }
    }
}

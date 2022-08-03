using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Windows.Forms;

namespace proj1
{
    public partial class FAFilm : Form
    {
        List<KFilm> filmovi = new List<KFilm>();
        int brinc;
        public FAFilm()
        {
            InitializeComponent();

        }

        private void FAFilm_Load(object sender, EventArgs e)
        {
            
            if (File.Exists("Filmovi"))
            {
                BinaryFormatter bf = new BinaryFormatter();
                FileStream fs = File.OpenRead("Filmovi");
                filmovi = bf.Deserialize(fs) as List<KFilm>;
                fs.Dispose();
                listBox1.DataSource = filmovi;
            }

            if (File.Exists("brinc"))
            {
                FileStream fs = File.OpenRead("brinc");
                string str = File.ReadAllText("brinc");
                if (Int32.TryParse(str, out brinc))
                {

                }
                else
                {
                    brinc = 1;
                }
                fs.Dispose();
            }
            else brinc = 1;

        }

        private void btn3_1_Click(object sender, EventArgs e)
        {
            int prov1 = 0;
            if (txt3_1.Text.Trim().Length != 0 && txt3_2.Text.Trim().Length != 0 && txt3_3.Text.Trim().Length != 0 && txt3_4.Text.Trim().Length != 0)
            {
                int duzina;
                int god;
                int prov2 = 0;
                

                if (!Int32.TryParse(txt3_3.Text, out god) || god <= 0)
                {
                    prov2 += 1;
                }
                if (!Int32.TryParse(txt3_4.Text, out god) || god < 0)
                {
                    prov2 += 2;
                }
                switch (prov2)
                {
                    case 1:
                        MessageBox.Show("Dužina trajanja filma mora biti pozitivan broj");
                        break;
                    case 2:
                        MessageBox.Show("Granica godina mora biti pozitivan broj");
                        break;
                    case 3:
                        MessageBox.Show("Dužina filma i granica godina moraju biti pozitivni brojevi");
                        break;
                }

                txt3_1.Focus();
                if (prov2 == 0)
                {
                    if (Int32.TryParse(txt3_3.Text, out duzina) && duzina > 0 && Int32.TryParse(txt3_4.Text, out god) && god >= 0)
                    {
                        KFilm f = new KFilm(brinc, txt3_1.Text, txt3_2.Text, duzina, god);
                        brinc++;
                        File.WriteAllText("brinc", brinc.ToString());
                        filmovi.Add(f);
                        
                        BinaryFormatter bf = new BinaryFormatter();
                        FileStream fs = File.OpenWrite("Filmovi");

                        bf.Serialize(fs, filmovi);

                        
                        fs.Dispose();

                        List<KFilm> lista;
                        FileStream fs1 = File.OpenRead("Filmovi");
                        lista = bf.Deserialize(fs1) as List<KFilm>;
                        listBox1.DataSource = lista;
                        fs1.Dispose();

                        if (!checkBox1.Checked)
                            MessageBox.Show("Uspesno ste dodali film");
                        if (cb3_1.Checked)
                        {
                            txt3_1.Clear();
                            txt3_2.Clear();
                            txt3_3.Clear();
                            txt3_4.Clear();
                        }
                    }
                }
                
            }
            else
            {
                if (txt3_1.Text.Trim().Length == 0)
                {
                    prov1 += 1;
                }
                if (txt3_2.Text.Trim().Length == 0)
                {
                    prov1 += 2;
                }
                if (txt3_3.Text.Trim().Length == 0)
                {
                    prov1 += 4;
                }
                if (txt3_4.Text.Trim().Length == 0)
                {
                    prov1 += 8;
                }
                switch (prov1)
                {
                    case 1:
                        MessageBox.Show("Niste uneli naziv filma");
                        break;
                    case 2:
                        MessageBox.Show("Niste uneli žanr filma");
                        break;
                    case 3:
                        MessageBox.Show("Niste uneli naziv i žanr filma");
                        break;
                    case 4:
                        MessageBox.Show("Niste uneli dužinu filma");
                        break;
                    case 5:
                        MessageBox.Show("Niste uneli naziv i dužinu filma");
                        break;
                    case 6:
                        MessageBox.Show("Niste uneli žanr i dužinu filma");
                        break;
                    case 7:
                        MessageBox.Show("Niste uneli naziv žanr i dužinu filma");
                        break;
                    case 8:
                        MessageBox.Show("Niste uneli granicu godina");
                        break;
                    case 9:
                        MessageBox.Show("Niste uneli naziv filma i granicu godina");
                        break;
                    case 10:
                        MessageBox.Show("Niste uneli žanr filma i granicu godina");
                        break;
                    case 11:
                        MessageBox.Show("Niste uneli granicu godina, naziv i žanr filma");
                        break;
                    case 12:
                        MessageBox.Show("Niste uneli granicu godina i dužinu filma");
                        break;
                    case 13:
                        MessageBox.Show("Niste uneli granicu godina, naziv i dužinu filma");
                        break;
                    case 14:
                        MessageBox.Show("Niste uneli granicu godina, žanr i dužinu filma");
                        break;
                    case 15:
                        MessageBox.Show("Niste uneli nijedan podatak");
                        break;


                }

            }
            
        }

        private void FAFilm_FormClosing(object sender, FormClosingEventArgs e)
        {

            if (filmovi.Count == 0)
            {
                File.Delete("Filmovi");
                File.Delete("brinc");
            }
                
        }

        private void cb3_1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void FAFilm_FormClosed(object sender, FormClosedEventArgs e)
        {
            
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //--------------Brisanje Filma-------------------------
            if (listBox1.Items.Count != 0)
            {
                List<KFilm> lista;
                BinaryFormatter bf = new BinaryFormatter();
                FileStream fs = File.OpenRead("Filmovi");
                lista = bf.Deserialize(fs) as List<KFilm>;

                //--------------Brisanje projekcije--------------------

                List<KProjekcija> lista1;
                FileStream fs2 = File.OpenRead("Projekcije");
                lista1 = bf.Deserialize(fs2) as List<KProjekcija>;

                
                for (int i = 0; i < lista1.Count; i++)
                {
                    KProjekcija p = lista1[i];
                    if (p.Film.Id == lista[listBox1.SelectedIndex].Id)
                    {
                        lista1.RemoveAt(i);
                        i--;
                    }
                }
                fs2.Dispose();
                FileStream fs4 = File.OpenWrite("Projekcije");
                bf.Serialize(fs4, lista1);
                fs4.Dispose();
                //-----------------------------------------------------

                lista.RemoveAt(listBox1.SelectedIndex);
                fs.Dispose();
                FileStream fs1 = File.OpenWrite("Filmovi");
                bf.Serialize(fs1, lista);
                filmovi = lista;
                listBox1.DataSource = filmovi;
                fs1.Dispose();
                if(!checkBox1.Checked)
                    MessageBox.Show("Film Uspešno obrisan");

                
            }
            else
                MessageBox.Show("Lista filmova je prazna");
        }
        private void button2_Click(object sender, EventArgs e)
        {
            //--------------prebacivanje filma---------------------
            if (File.Exists("Filmovi") && filmovi.Count != 0)
            {
                List<KFilm> lista;
                BinaryFormatter bf = new BinaryFormatter();
                FileStream fs = File.OpenRead("Filmovi");
                lista = bf.Deserialize(fs) as List<KFilm>;

                KFilm f1 = lista[listBox1.SelectedIndex];
                textBox4.Text = f1.Naziv;
                textBox3.Text = f1.Zanr;
                textBox2.Text = f1.Duzina.ToString();
                textBox1.Text = f1.Granica.ToString();

                fs.Dispose();
            }
            else
            {
                MessageBox.Show("Lista Filmova je prazna");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //--------------Azuriranje Filma-----------------------
            int ad = 0;
            if (File.Exists("Filmovi") && filmovi.Count != 0)
            {
                List<KFilm> lista;
                BinaryFormatter bf = new BinaryFormatter();
                FileStream fs = File.OpenRead("Filmovi");
                lista = bf.Deserialize(fs) as List<KFilm>;

                fs.Dispose();

                int a1, a2;
                Int32.TryParse(textBox2.Text, out a1);
                Int32.TryParse(textBox1.Text, out a2);


                KFilm f1 = lista[listBox1.SelectedIndex];
                if(textBox4.Text.Trim().Length != 0)
                    f1.Naziv = textBox4.Text;
                if (textBox3.Text.Trim().Length != 0)
                    f1.Zanr = textBox3.Text;
                if (textBox2.Text.Trim().Length != 0)
                {
                    if (Int32.TryParse(textBox2.Text, out a1) && a1 > 0)
                    {
                        f1.Duzina = a1;
                    }
                    else
                    {
                        MessageBox.Show("Duzina Mora biti pozitivan broj");
                        ad += 1;
                    }
                }
                if (textBox1.Text.Trim().Length != 0)
                {
                    if (Int32.TryParse(textBox1.Text, out a2) && a2 >= 0)
                    {

                        f1.Granica = a2;
                    }
                    else
                    {
                        MessageBox.Show("Granica mora biti broj veci od nule");
                        ad += 2;
                    }
                }
                


                    

                lista[listBox1.SelectedIndex] = f1;
                if (ad == 0)
                {
                    FileStream fs1 = File.OpenWrite("Filmovi");
                    bf.Serialize(fs1, lista);
                    fs1.Dispose();
                    filmovi = lista;
                    listBox1.DataSource = filmovi;

                    textBox1.Clear();
                    textBox2.Clear();
                    textBox3.Clear();
                    textBox4.Clear();

                    if (!checkBox1.Checked)
                        MessageBox.Show("Film Uspešno ažuriran");
                }

            }
            else
            {
                MessageBox.Show("Lista Filmova je prazna");
            }

        }
    }
}

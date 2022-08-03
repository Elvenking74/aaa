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
    public partial class FARezervacija : Form
    {
        BinaryFormatter bf = new BinaryFormatter();
        List<KKupac> kupci = new List<KKupac>();
        List<KProjekcija> projekcije = new List<KProjekcija>();
        List<KRezervacija> rezervacije = new List<KRezervacija>();
        public FARezervacija()
        {
            InitializeComponent();
        }

        private void FARezervacija_Load(object sender, EventArgs e)
        {
            List<KRezervacija> priv = new List<KRezervacija>();
            if (File.Exists("Kupci"))
            {
                FileStream fs = File.OpenRead("Kupci");
                kupci = bf.Deserialize(fs) as List<KKupac>;
                fs.Dispose();
                comboBox1.DataSource = kupci;
            }

            if (File.Exists("Projekcije"))
            {
                FileStream fs = File.OpenRead("Projekcije");
                projekcije = bf.Deserialize(fs) as List<KProjekcija>;
                fs.Dispose();
                comboBox2.DataSource = projekcije;
            }

            if (File.Exists("Rezervacije"))
            {
                FileStream fs = File.OpenRead("Rezervacije");
                rezervacije = bf.Deserialize(fs) as List<KRezervacija>;
                fs.Dispose();
            }

            //------------Listbox1 rezervacije----------------------------
            if (File.Exists("Rezervacije"))
            {
                List<KRezervacija> lista;
                List<KRezervacija> lista1 = new List<KRezervacija>();
                FileStream fs1 = File.OpenRead("Rezervacije");
                lista = bf.Deserialize(fs1) as List<KRezervacija>;
                foreach (KRezervacija r1 in lista)
                {
                    if (r1.Idk == kupci[comboBox1.SelectedIndex].Id)
                    {
                        lista1.Add(r1);
                    }
                }
                fs1.Dispose();
                listBox1.DataSource = lista1;
            }
            //------------------------------------------------------------

        }

        private void FARezervacija_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (rezervacije.Count == 0)
            {
                File.Delete("Rezervacije");
            }
        }

        private void comboBox1_SelectionChangeCommitted(object sender, EventArgs e)
        {
            //------------Listbox1 rezervacije----------------------------
            if (File.Exists("Rezervacije"))
            {
                List<KRezervacija> lista;
                List<KRezervacija> lista1 = new List<KRezervacija>();
                FileStream fs1 = File.OpenRead("Rezervacije");
                lista = bf.Deserialize(fs1) as List<KRezervacija>;
                foreach (KRezervacija r1 in lista)
                {
                    if (r1.Idk == kupci[comboBox1.SelectedIndex].Id)
                    {
                        lista1.Add(r1);
                    }
                }
                fs1.Dispose();
                listBox1.DataSource = lista1;
            }
            //------------------------------------------------------------
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //-------------Broj karata------------------------------------
            int prov1 = 0;
            int brk = 1;

            if (numericUpDown1.Value == 0)
            {
                prov1 = 1;
            }
            else
                brk = Convert.ToInt32(numericUpDown1.Value);
            //------------------------------------------------------------
            int cna = 0;
            if (comboBox2.Items.Count != 0)
            {
                cna = projekcije[comboBox2.SelectedIndex].Cena * brk;
            }

            //-------------Ostalo karata----------------------------------
            int j = 0;
            if (comboBox2.Items.Count != 0)
                j = projekcije[comboBox2.SelectedIndex].Sala.Br_sed;

                //--------------Rezervacije-----------------------------------
            List<KRezervacija> rez = new List<KRezervacija>();
            if (File.Exists("Rezervacije"))
            {
                FileStream fs2 = File.OpenRead("Rezervacije");
                rez = bf.Deserialize(fs2) as List<KRezervacija>;
                fs2.Dispose();
            }
                //------------------------------------------------------------

            foreach (KRezervacija p in rez)
            {
                if (p.Idp == projekcije[comboBox2.SelectedIndex].Id)
                    j -= p.Omest;
            }
            j -= brk;
            //------------------------------------------------------------


            //-------------Update---------------------------------------------
            if (j >= 0 && prov1 == 0 && comboBox1.Items.Count !=0 && comboBox2.Items.Count != 0)
            {
                //BinaryFormatter bf1 = new BinaryFormatter();
                KRezervacija r = new KRezervacija(kupci[comboBox1.SelectedIndex].Id, projekcije[comboBox2.SelectedIndex].Id, brk, cna);
                rezervacije.Add(r);

                FileStream fs = File.OpenWrite("Rezervacije");

                bf.Serialize(fs, rezervacije);

                fs.Dispose();

                List<KRezervacija> lista;
                List<KRezervacija> lista1 = new List<KRezervacija>();
                FileStream fs1 = File.OpenRead("Rezervacije");
                lista = bf.Deserialize(fs1) as List<KRezervacija>;
                foreach (KRezervacija r1 in lista)
                {
                    if (r1.Idk == kupci[comboBox1.SelectedIndex].Id)
                    {
                        lista1.Add(r1);
                    }
                }
                
                fs1.Dispose();
                listBox1.DataSource = lista1;
                //------------------------------------------------------------

                //------------update combobox2--------------------------------
                FileStream fs2 = File.OpenRead("Projekcije");
                List<KProjekcija> lista2;
                lista2 = bf.Deserialize(fs2) as List<KProjekcija>;
                fs2.Dispose();
                comboBox2.DataSource = lista2;
                //------------------------------------------------------------
            }
            else
            {
                if (comboBox1.Items.Count == 0 && comboBox2.Items.Count == 0)
                {
                    MessageBox.Show("Nema kupaca niti projekcija");
                }
                else if (comboBox1.Items.Count == 0)
                {
                    MessageBox.Show("Nema kupaca");
                }
                else
                {
                    if (comboBox2.Items.Count == 0)
                    {
                        MessageBox.Show("Nema projekcija");
                    }
                    else
                    {
                        if (prov1 != 0)
                        {
                            MessageBox.Show("Broj karata treba da bude pozitivan");
                        }
                        else
                            MessageBox.Show("Nema više mesta na ovoj projekciji");
                    }
                }
                
            }
        }

        private void FARezervacija_FormClosed(object sender, FormClosedEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (rezervacije.Count != 0)
            {
                //---------------Nadji indeks za brisanje--------------------
                int incr = 0;
                for (int i = 0; i <= listBox1.SelectedIndex; i++)
                {
                    if (rezervacije[incr].Idk == kupci[comboBox1.SelectedIndex].Id)
                    {
                        if(i == listBox1.SelectedIndex)
                            break;
                    }
                    else
                    {
                        i--;
                    }
                    incr ++;
                }
                //-----------------------------------------------------------
                List<KRezervacija> lista;
                FileStream fs = File.OpenRead("Rezervacije");
                lista = bf.Deserialize(fs) as List<KRezervacija>;
                lista.RemoveAt(incr);
                fs.Dispose();
                FileStream fs1 = File.OpenWrite("Rezervacije");
                bf.Serialize(fs1, lista);
                rezervacije = lista;
                fs1.Dispose();

                List<KRezervacija> lista1;
                List<KRezervacija> lista2 = new List<KRezervacija>();
                FileStream fs2 = File.OpenRead("Rezervacije");
                lista1 = bf.Deserialize(fs2) as List<KRezervacija>;
                fs2.Dispose();
                foreach (KRezervacija r1 in lista1)
                {
                    if (r1.Idk == kupci[comboBox1.SelectedIndex].Id)
                    {
                        lista2.Add(r1);
                    }
                }
                listBox1.DataSource = lista2;

                //------------update combobox2--------------------------------
                FileStream fs5 = File.OpenRead("Projekcije");
                List<KProjekcija> lista5;
                lista5 = bf.Deserialize(fs5) as List<KProjekcija>;
                fs5.Dispose();
                comboBox2.DataSource = lista5;
                //------------------------------------------------------------



                MessageBox.Show("Uspesno ste obrisali rezervaciju");
            }
            else
                MessageBox.Show("Lista rezervacija je prazna");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (File.Exists("Rezervacije") && rezervacije.Count != 0)
            {
                //---------------Nadji indeks--------------------------------
                int incr = 0;
                for (int i = 0; i <= listBox1.SelectedIndex; i++)
                {
                    if (rezervacije[incr].Idk == kupci[comboBox1.SelectedIndex].Id)
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
                KRezervacija r = rezervacije[incr];
                //-------------Broj karata------------------------------------
                int prov1 = 0;
                int brk = 1;

                if (numericUpDown1.Value == 0)
                {
                    prov1 = 1;
                }
                brk = Convert.ToInt32(numericUpDown1.Value);

                int cna = projekcije[comboBox2.SelectedIndex].Cena * brk;
                //------------------------------------------------------------

                //-------------Ostalo karata----------------------------------
                int j = projekcije[comboBox2.SelectedIndex].Sala.Br_sed;

                //--------------Rezervacije-----------------------------------
                List<KRezervacija> rez = new List<KRezervacija>();
                if (File.Exists("Rezervacije"))
                {
                    FileStream fs2 = File.OpenRead("Rezervacije");
                    rez = bf.Deserialize(fs2) as List<KRezervacija>;
                    fs2.Dispose();
                }
                //------------------------------------------------------------

                foreach (KRezervacija p in rez)
                {
                    if (p.Idp == projekcije[comboBox2.SelectedIndex].Id)
                        j -= p.Omest;
                }
                j = j - brk + r.Omest;
                //------------------------------------------------------------


                //-------------Update---------------------------------------------
                if (j >= 0 && prov1 == 0 && rezervacije.Count != 0 && kupci.Count != 0)
                {
                    r.Idk = kupci[comboBox1.SelectedIndex].Id;
                    r.Idp = projekcije[comboBox2.SelectedIndex].Id;
                    r.Uc = cna;
                    r.Omest = brk;

                    rezervacije[incr] = r;
                    List<KRezervacija> lista = new List<KRezervacija>();
                    foreach (KRezervacija r1 in rezervacije)
                    {
                        if (r1.Idk == kupci[comboBox1.SelectedIndex].Id)
                        {
                            lista.Add(r1);
                        }
                    }
                    listBox1.DataSource = lista;


                    FileStream fs = File.OpenWrite("Rezervacije");
                    bf.Serialize(fs, rezervacije);
                    fs.Dispose();


                    //------------update combobox2--------------------------------
                    FileStream fs3 = File.OpenRead("Projekcije");
                    List<KProjekcija> lista3;
                    lista3 = bf.Deserialize(fs3) as List<KProjekcija>;
                    fs3.Dispose();
                    comboBox2.DataSource = lista3;
                    //------------------------------------------------------------

                    MessageBox.Show("Uspesno ste ažurirali rezervaciju");
                }
                else
                {
                    if (comboBox1.Items.Count == 0)
                    {
                        MessageBox.Show("Nema kupaca");
                    }
                    else
                    {
                        if (comboBox2.Items.Count == 0)
                        {
                            MessageBox.Show("Nema projekcija");
                        }
                        else
                        {
                            if (prov1 != 0)
                            {
                                MessageBox.Show("Broj karata treba da bude pozitivan");
                            }
                            else
                                MessageBox.Show("Nema više mesta na ovoj projekciji");
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Lista rezervacija je prazna");
            }
                
        }
    }
}

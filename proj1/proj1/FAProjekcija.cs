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
    public partial class FAProjekcija : Form
    {
        List<KSala> sale = new List<KSala>();
        List<KProjekcija> projekcije = new List<KProjekcija>();
        List<KFilm> filmovi = new List<KFilm>();
        DateTime cr = DateTime.Now;
        int brinc;
        public FAProjekcija()
        {
            InitializeComponent();
        }

        private void FAProjekcija_Load(object sender, EventArgs e)
        {
            if (File.Exists("Projekcije"))
            {
                BinaryFormatter bf = new BinaryFormatter();
                FileStream fs = File.OpenRead("Projekcije");
                projekcije = bf.Deserialize(fs) as List<KProjekcija>;
                listBox1.DataSource = projekcije;
                fs.Dispose();
            }

            if (File.Exists("brincP"))
            {
                FileStream fs = File.OpenRead("brincP");
                string str = File.ReadAllText("brincP");
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

            if (File.Exists("Sale"))
            {
                BinaryFormatter bf = new BinaryFormatter();
                FileStream fs = File.OpenRead("Sale");
                sale = bf.Deserialize(fs) as List<KSala>;
                comboBox1.DataSource = sale;
                comboBox4.DataSource = sale;
                fs.Dispose();
            }

            if (File.Exists("Filmovi"))
            {
                BinaryFormatter bf = new BinaryFormatter();
                FileStream fs = File.OpenRead("Filmovi");
                filmovi = bf.Deserialize(fs) as List<KFilm>;
                comboBox2.DataSource = filmovi;
                comboBox3.DataSource = filmovi;
                fs.Dispose();
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Boolean god_pre = false;
            int god1 = 1, mes1 = 1, dan1 = 0;
            int mest = 1;
            int god = 0, mes = 0, dan = 0;
            int sat = 0, min = 0;
            int cena = 0;


            //--------------Godina--------------------------
            int prov1 = 0;


            if (txt23_1.Text.Trim().Length != 0)
            {

                if (Int32.TryParse(txt23_1.Text, out god) && god > 0)
                {

                    if (txt23_1.Text.Trim().Length == 4)
                    {
                        //----------Prestupna---------------------------
                        if (god % 4 == 0)
                        {
                            if (god % 100 == 0 && god % 400 != 0)
                                god_pre = false;
                            else
                                god_pre = true;
                        }
                        else
                            god_pre = false;
                        //----------------------------------------------

                        if (god >= DateTime.Now.Year)
                        {
                            if (god == DateTime.Now.Year)
                            {
                                god1 = 0;
                            }
                            else
                                god1 = 1;
                        }
                        else
                        {
                            prov1 = 1;
                        }
                    }
                    else
                    {
                        prov1 = 1;
                    }
                }
                else
                {
                    prov1 = 1;
                }
            }
            else
            {
                prov1 = 1;
            }
            


            //--------------Mesec---------------------------
            int prov2 = 0;


            if (txt23_2.Text.Trim().Length != 0)
            {
                if (Int32.TryParse(txt23_2.Text, out mes) && (txt23_2.Text.Length == 1 || txt23_2.Text.Length == 2))
                {
                    if (mes <= 12 && mes >= 1)
                    {
                        //----------------------------------------------
                        if (mes == 1 || mes == 3 || mes == 5 || mes == 7 || mes == 8 || mes == 10 || mes == 12)
                            mest = 1;
                        if (mes == 4 || mes == 6 || mes == 9 || mes == 11)
                            mest = 2;
                        if (mes == 2)
                            mest = 3;
                        //----------------------------------------------

                        if (god1 == 0)
                        {
                            if (mes >= DateTime.Now.Month)
                            {
                                if (mes == DateTime.Now.Month)
                                    mes1 = 0;
                                else
                                    mes1 = 1;
                            }
                            else
                                prov2 = 1;
                        }
                    }
                    else
                    {
                        prov2 = 1;
                    }
                }
                else
                {
                    prov2 = 1;
                }
            }
            else
            {
                prov2 = 1;
            }



            //--------------Dan-----------------------------
            int prov3 = 0;


            if (txt23_3.Text.Trim().Length != 0)
            {
                if (Int32.TryParse(txt23_3.Text, out dan))
                {
                    if (mest == 1)
                    {
                        if (dan > 31 || dan < 1)
                        {
                            prov3 = 1;
                        }
                    }

                    if (mest == 2)
                    {
                        if (dan > 30 || dan < 1)
                        {
                            prov3 = 1;
                        }
                    }

                    if (mest == 3 && !god_pre)
                    {
                        if (dan > 28 || dan < 1)
                        {
                            prov3 = 1;
                        }
                    }

                    if (mest == 3 && god_pre)
                    {
                        if (dan > 29 || dan < 1)
                        {
                            prov3 = 1;
                        }
                    }
                    if (mes1 == 0)
                    {
                        if (dan >= DateTime.Now.Day)
                        {
                            if (dan == DateTime.Now.Day)
                            {
                                dan1 = 1;
                            } 
                        }
                        else
                        {
                            prov3 = 1;
                        }

                        
                    }
                }
                else
                {
                    prov3 = 1;
                }
            }
            else
            {
                prov3 = 1;
            }


            
            //--------------Sat-----------------------------
            int prov4 = 0;


            if (txt23_4.Text.Trim().Length != 0)
            {
                if (Int32.TryParse(txt23_4.Text, out sat))
                {
                    if (sat < 24 && sat >= 0)
                    {

                    }
                    else
                    {
                        prov4 = 1;
                    }
                }
                else
                {
                    prov4 = 1;
                }
            }
            else
            {
                prov4 = 1;
            }



            //--------------Minut---------------------------
            int prov5 = 0;


            if (txt23_5.Text.Trim().Length != 0)
            {
                if (Int32.TryParse(txt23_5.Text, out min))
                {
                    if (min < 60 && min >= 0)
                    {

                    }
                    else
                    {
                        prov5 = 1;
                    }
                }
                else
                {
                    prov5 = 1;
                }
            }
            else
            {
                prov5 = 1;
            }



            //--------------Cena Karte----------------------
            int prov6 = 0;
            int nat = 0;
            int cn1, brj = 0;
            string[] cn2;


            foreach (char c in txt23_6.Text)
            {
                if (c == ',' || c == '.')
                {
                    nat = 1;
                    brj++;
                }
            }
            if (txt23_6.Text.Trim().Length != 0)
            {
                if (nat == 1)
                {
                    cn2 = txt23_6.Text.Split(',', '.');
                    if (Int32.TryParse(cn2[0], out cn1))
                    {
                        if (brj == 1)
                        {
                            int upz = 0;
                            foreach (char c in cn2[1])
                            {
                                if (c != '0')
                                {
                                    upz = 1;
                                    break;
                                }
                            }
                            if (upz == 0)
                                cena = cn1;
                            else
                                prov6 = 3;
                        }
                        else
                            prov6 = 2;
                    }
                    else
                    {
                        prov6 = 1;
                    }
                }
                else
                {
                    if (Int32.TryParse(txt23_6.Text, out cena))
                    {

                    }
                    else
                    {
                        prov6 = 1;
                    }
                }
            }
            else
            {
                prov6 = 1;
            }



            //--------------Datum---------------------------
            int DVproj = 0;
            if (dan1 == 1)
            {
                if (sat >= cr.Hour)
                {
                    if (sat == cr.Hour)
                    {
                        if (min > cr.Minute)
                        {

                        }
                        else
                            DVproj = 1;
                    }
                }
                else
                    DVproj = 1;
            }



            
            


            //MessageBox.Show(prov1.ToString() + prov2.ToString() + prov3.ToString() + prov4.ToString() + prov5.ToString() + prov6.ToString());
            //--------update--------------------------------

            if (DVproj == 0 && prov1 == 0 && prov2 == 0 && prov3 == 0 && prov4 == 0 && prov5 == 0 && prov6 == 0 && filmovi.Count != 0 && sale.Count != 0)
            {
                DateTime dt = new DateTime(god, mes, dan);
                DateTime vt = new DateTime(cr.Year, cr.Month, cr.Day, sat, min, 0);
                KProjekcija p = new KProjekcija(brinc, dt, sale[comboBox1.SelectedIndex], cena, vt, filmovi[comboBox2.SelectedIndex]);
                brinc++;
                File.WriteAllText("brincP", brinc.ToString());
                projekcije.Add(p);

                BinaryFormatter bf = new BinaryFormatter();
                FileStream fs = File.OpenWrite("Projekcije");

                bf.Serialize(fs, projekcije);

                fs.Dispose();

                List<KProjekcija> lista;
                FileStream fs1 = File.OpenRead("Projekcije");
                lista = bf.Deserialize(fs1) as List<KProjekcija>;
                listBox1.DataSource = lista;
                fs1.Dispose();

                if(checkBox1.Checked)
                {
                    txt23_1.Clear();
                    txt23_2.Clear();
                    txt23_3.Clear();
                    txt23_4.Clear();
                    txt23_5.Clear();
                    txt23_6.Clear();
                }
                if(!checkBox2.Checked)
                    MessageBox.Show("Uspešno ste dodali projekciju");
                
            }
            else
            {
                if (txt23_1.Text.Trim().Length == 0 || txt23_3.Text.Trim().Length == 0 || txt23_2.Text.Trim().Length == 0 || txt23_4.Text.Trim().Length == 0 || txt23_5.Text.Trim().Length == 0 || txt23_6.Text.Trim().Length == 0)
                {
                    MessageBox.Show("Morate popuniti sva polja");
                }
                else if (comboBox1.Items.Count == 0)
                {
                    if (comboBox1.Items.Count == 0 || comboBox2.Items.Count == 0)
                    {
                        MessageBox.Show("Lista sala i filmova je prazna");
                    }
                    else
                        MessageBox.Show("Lista sala je prazna");
                }
                else if (comboBox2.Items.Count == 0)
                {
                    MessageBox.Show("Lista filmova je prazna");
                }
                else if (prov1 != 0 || prov2 != 0 || prov3 != 0)
                {
                    MessageBox.Show("Datum projekcije ne može biti pre današnjeg" + Environment.NewLine + "Trenutan datum: " + DateTime.Now.Day + "." + DateTime.Now.Month + "." + DateTime.Now.Year);
                }
                else
                {
                    if (prov4 != 0 || prov5 != 0)
                    {
                        MessageBox.Show("Sat(između 0 i 23), minut(između 0 i 59)");
                    }
                    else
                    {
                        if (DVproj != 0)
                        {
                            MessageBox.Show("Datum i vreme moraju biti posle trenutnog: " + DateTime.Now);
                        }
                        else
                        {
                            if (prov6 != 0)
                            {
                                MessageBox.Show("Cena se kuca u 1 od 3 formata: " + Environment.NewLine + "     -Samo cena(\'250\')" + Environment.NewLine + "     -Sa zarezom(\'250,00\')" + Environment.NewLine + "      -Sa tačkom(\'250.00\')");
                            }
                        }
                    }
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //-----------Brisanje-------------------------------
            if (listBox1.Items.Count != 0)
            {
                List<KProjekcija> lista;
                BinaryFormatter bf = new BinaryFormatter();
                FileStream fs = File.OpenRead("Projekcije");
                lista = bf.Deserialize(fs) as List<KProjekcija>;
                //-----------Brisanje rezervacije-------------------
                List<KRezervacija> lista1;
                FileStream fs2 = File.OpenRead("Rezervacije");
                lista1 = bf.Deserialize(fs2) as List<KRezervacija>;

                for (int i = 0; i < lista1.Count; i++)
                {
                    KRezervacija p = lista1[i];
                    if (p.Idp == lista[listBox1.SelectedIndex].Id)
                    {
                        lista1.RemoveAt(i);
                        i--;
                    }
                }
                fs2.Dispose();
                FileStream fs4 = File.OpenWrite("Rezervacije");
                bf.Serialize(fs4, lista1);
                fs4.Dispose();
                //--------------------------------------------------
                lista.RemoveAt(listBox1.SelectedIndex);
                fs.Dispose();
                FileStream fs1 = File.OpenWrite("Projekcije");
                bf.Serialize(fs1, lista);
                projekcije = lista;
                listBox1.DataSource = projekcije;
                fs1.Dispose();
                if (!checkBox2.Checked)
                    MessageBox.Show("Projekcija Uspešno obrisana");
            }
            else
                MessageBox.Show("Lista projekcija je prazna");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //-----------Kopiranje------------------------------
            if (File.Exists("Projekcije") && filmovi.Count != 0)
            {
                List<KProjekcija> lista;
                BinaryFormatter bf = new BinaryFormatter();
                FileStream fs = File.OpenRead("Projekcije");
                lista = bf.Deserialize(fs) as List<KProjekcija>;

                FileStream fs1 = File.OpenRead("Filmovi");
                filmovi = bf.Deserialize(fs1) as List<KFilm>;

                FileStream fs2 = File.OpenRead("Sale");
                sale = bf.Deserialize(fs2) as List<KSala>;

                KProjekcija f1 = lista[listBox1.SelectedIndex];
                txt23_7.Text = f1.Datum.Year.ToString();
                txt23_8.Text = f1.Datum.Month.ToString();
                txt23_9.Text = f1.Datum.Day.ToString();
                txt23_10.Text = f1.Vreme.Hour.ToString();
                txt23_11.Text = f1.Vreme.Minute.ToString();
                txt23_12.Text = f1.Cena.ToString();
                
                int i = 0;
                foreach (KFilm f in filmovi)
                {
                    if (f.Id == f1.Film.Id)
                    {
                        break;
                    }
                    else
                        i++;
                }
                comboBox3.SelectedItem = comboBox3.Items[i];

                int j = 0;
                foreach (KSala s in sale)
                {
                    if (s.Id == f1.Sala.Id)
                    {
                        break;
                    }
                    else
                        j++;
                }
                comboBox4.SelectedItem = comboBox4.Items[j];


                fs.Dispose();
                fs1.Dispose();
                fs2.Dispose();

            }
            else
            {
                MessageBox.Show("Lista projekcija je prazna");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //-----------Azuriranje-----------------------------
            
            int god, mes, dan;
            int min, sat;
            int god1 = 1, mes1 = 1;
            int mest = 1;
            int cena;
            Boolean god_pre = false;


            if (File.Exists("Projekcije") && filmovi.Count != 0)
            {
                List<KProjekcija> lista;
                BinaryFormatter bf = new BinaryFormatter();
                FileStream fs = File.OpenRead("Projekcije");
                lista = bf.Deserialize(fs) as List<KProjekcija>;

                fs.Dispose();

                int a1, a2, a3;
                int s, m;

                KProjekcija f1 = lista[listBox1.SelectedIndex];

                god = f1.Datum.Year;
                mes = f1.Datum.Month;
                dan = f1.Datum.Day;

                min = f1.Vreme.Minute;
                sat = f1.Vreme.Hour;

                cena = f1.Cena;



                //-----------Godina---------------------------------
                int prov1 = 0;


                if (txt23_7.Text.Trim().Length != 0)
                {

                    if (Int32.TryParse(txt23_7.Text, out a1) && a1 > 0)
                    {

                        if (txt23_7.Text.Trim().Length == 4)
                        {
                            //----------Prestupna---------------------------
                            if (a1 % 4 == 0)
                            {
                                if (a1 % 100 == 0 && a1 % 400 != 0)
                                    god_pre = false;
                                else
                                    god_pre = true;
                            }
                            else
                                god_pre = false;
                            //----------------------------------------------

                            if (a1 >= DateTime.Now.Year)
                            {
                                if (a1 == DateTime.Now.Year)
                                {
                                    god1 = 0;
                                }
                                else
                                    god1 = 1;
                                god = a1;
                            }
                            else
                            {
                                prov1 = 1;
                            }
                        }
                        else
                        {
                            prov1 = 1;
                        }
                    }
                    else
                    {
                        prov1 = 1;
                    }
                }



                //-----------Mesec----------------------------------
                int prov2 = 0;


                if (txt23_8.Text.Trim().Length != 0)
                {
                    if (Int32.TryParse(txt23_8.Text, out a2) && (txt23_8.Text.Length == 1 || txt23_8.Text.Length == 2))
                    {
                        if (a2 <= 12 && a2 >= 1)
                        {
                            //----------------------------------------------
                            if (a2 == 1 || a2 == 3 || a2 == 5 || a2 == 7 || a2 == 8 || a2 == 10 || a2 == 12)
                                mest = 1;
                            if (a2 == 4 || a2 == 6 || a2 == 9 || a2 == 11)
                                mest = 2;
                            if (a2 == 2)
                                mest = 3;
                            //----------------------------------------------

                            if (god1 == 0)
                            {
                                if (a2 >= DateTime.Now.Month)
                                {
                                    if (a2 == DateTime.Now.Month)
                                        mes1 = 0;
                                    else
                                        mes1 = 1;
                                }
                                else
                                    prov2 = 1;
                            }
                            mes = a2;
                        }
                        else
                        {
                            prov2 = 1;
                        }
                    }
                    else
                    {
                        prov2 = 1;
                    }
                }



                //-----------Dan------------------------------------
                int prov3 = 0;


                if (txt23_9.Text.Trim().Length != 0)
                {
                    if (Int32.TryParse(txt23_9.Text, out a3))
                    {
                        if (mest == 1)
                        {
                            if (a3 > 31 || a3 < 1)
                            {
                                prov3 = 1;
                            }
                        }

                        if (mest == 2)
                        {
                            if (a3 > 30 || a3 < 1)
                            {
                                prov3 = 1;
                            }
                        }

                        if (mest == 3 && !god_pre)
                        {
                            if (a3 > 28 || a3 < 1)
                            {
                                prov3 = 1;
                            }
                        }

                        if (mest == 3 && god_pre)
                        {
                            if (a3 > 29 || a3 < 1)
                            {
                                prov3 = 1;
                            }
                        }
                        if (mes1 == 0)
                        {
                            if (a3 >= DateTime.Now.Day)
                            {

                            }
                            else
                            {
                                prov3 = 1;
                            }
                        }
                        dan = a3;
                    }
                    else
                    {
                        prov3 = 1;
                    }
                }



                //-----------Sat------------------------------------
                int prov4 = 0;


                if(txt23_10.Text.Trim().Length != 0)
                {
                    if (Int32.TryParse(txt23_10.Text, out s))
                    {
                        if (s < 24 && s >= 0)
                        {
                            sat = s;
                        }
                        else
                        {
                            prov4 = 1;
                        }
                    }
                    else
                    {
                        prov4 = 1;
                    }
                }



                //-----------Minut----------------------------------
                int prov5 = 0;


                if (txt23_11.Text.Trim().Length != 0)
                {
                    if (Int32.TryParse(txt23_11.Text, out m))
                    {
                        if (m < 60 && m >= 0)
                        {
                            min = m;
                        }
                        else
                        {
                            prov5 = 1;
                        }
                    }
                    else
                    {
                        prov5 = 1;
                    }
                }



                //-----------Cena Karte-----------------------------
                int prov6 = 0;
                int nat = 0;
                int cn1, brj = 0;
                string[] cn2;


                foreach (char c in txt23_12.Text)
                {
                    if (c == ',' || c == '.')
                    {
                        nat = 1;
                        brj++;
                    }
                }
                if (txt23_12.Text.Trim().Length != 0)
                {
                    if (nat == 1)
                    {
                        cn2 = txt23_12.Text.Split(',', '.');
                        if (Int32.TryParse(cn2[0], out cn1))
                        {
                            if (brj == 1)
                            {
                                int upz = 0;
                                foreach (char c in cn2[1])
                                {
                                    if (c != '0')
                                    {
                                        upz = 1;
                                        break;
                                    } 
                                }
                                if(upz == 0)
                                    cena = cn1;
                                else
                                    prov6 = 3;
                            }
                            else
                                prov6 = 2;
                        }
                        else
                        {
                            prov6 = 1;
                        }
                    }
                    else
                    {
                        if (Int32.TryParse(txt23_12.Text, out cena))
                        {

                        }
                        else
                        {
                            prov6 = 1;
                        }
                    }
                    f1.Cena = cena;
                }

                //-----------Datum i Vreme--------------------------
                DateTime dt = new DateTime(god, mes, dan);
                DateTime vt = new DateTime(cr.Year, cr.Month, cr.Day, sat, min, 0);
                f1.Vreme = vt;
                f1.Datum = dt;
                int DVprov = 0;


                if (f1.Datum.Year == cr.Year)
                {
                    if (f1.Datum.Month >= cr.Month)
                    {
                        if (f1.Datum.Month == cr.Month)
                        {
                            if (f1.Datum.Day >= cr.Day)
                            {
                                if (f1.Datum.Day == cr.Day)
                                {
                                    if (f1.Vreme.Hour >= cr.Hour)
                                    {
                                        if (f1.Vreme.Hour == cr.Hour)
                                        {
                                            if (f1.Vreme.Minute > cr.Minute)
                                            {

                                            }
                                            else
                                                DVprov = 1;
                                        }
                                    }
                                    else
                                        DVprov = 1;
                                }
                            }
                            else
                                DVprov = 1;
                        }
                    }
                    else
                        DVprov = 1;
                }

            

                //MessageBox.Show(prov1.ToString() + prov2.ToString() + prov3.ToString() + prov4.ToString() + prov5.ToString() + prov6.ToString());
                //-----------update---------------------------------
                if (DVprov == 0 && prov1 == 0 && prov2 == 0 && prov3 == 0 && prov4 == 0 && prov5 == 0 && prov6 == 0 && filmovi.Count != 0 && sale.Count != 0)
                {
                    

                    int i = 0;
                    foreach (KFilm fi in filmovi)
                    {
                        if (fi.Id == filmovi[comboBox3.SelectedIndex].Id)
                        {
                            break;
                        }
                        else
                            i++;
                        
                    }
                    f1.Film = filmovi[i];

                    int j = 0;
                    foreach (KSala sa in sale)
                    {
                        if (sa.Id == sale[comboBox4.SelectedIndex].Id)
                        {
                            break;
                        }
                        else
                            j++;
                    }
                    f1.Sala = sale[j];


                    lista[listBox1.SelectedIndex] = f1;

                    FileStream fs1 = File.OpenWrite("Projekcije");
                    bf.Serialize(fs1, lista);

                    fs1.Dispose();

                    projekcije = lista;
                    listBox1.DataSource = projekcije;


                    txt23_1.Clear();
                    txt23_2.Clear();
                    txt23_3.Clear();
                    txt23_4.Clear();
                    txt23_5.Clear();
                    txt23_6.Clear();
                    if (!checkBox2.Checked)
                        MessageBox.Show("Uspešno ste ažurirali projekciju");
                }
                else
                {
                    if (prov1 != 0 || prov2 != 0 || prov3 != 0)
                    {
                        MessageBox.Show("Datum projekcije ne može biti pre današnjeg" + Environment.NewLine + "Trenutan datum: " + DateTime.Now.Day + "." + DateTime.Now.Month + "." + DateTime.Now.Year);
                    }
                    else
                    {
                        if (prov4 != 0 || prov5 != 0)
                        {
                            MessageBox.Show("Sat(između 0 i 23), minut(između 0 i 59)");
                        }
                        else
                        {
                            if (DVprov != 0)
                            {
                                MessageBox.Show("Datum i vreme moraju biti posle trenutnog: " + DateTime.Now);
                            }
                            else
                            {
                                if (prov6 != 0)
                                {
                                    MessageBox.Show("Cena se kuca u 1 od 3 formata: " + Environment.NewLine + "     -Samo cena(\'250\')" + Environment.NewLine + "     -Sa zarezom(\'250,00\')" + Environment.NewLine + "      -Sa tačkom(\'250.00\')");
                                }
                            }
                        }
                    }
                    
                }
            }
            else
            {
                MessageBox.Show("Lista projekcija je prazna");
            }
        }

        private void txt23_5_TextChanged(object sender, EventArgs e)
        {

        }

        private void txt23_6_TextChanged(object sender, EventArgs e)
        {

        }

        private void FAProjekcija_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (projekcije.Count == 0)
            {
                File.Delete("Projekcije");
                File.Delete("brincP");
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}

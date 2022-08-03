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
    public partial class FAKupac : Form
    {
        List<KKupac> kupci = new List<KKupac>();
        int brinc;
        string tel;
        int god1, mes1, dan1;
        int mest;
        string loz;
        int pol;
        Boolean godt;
        DateTime dt;
        public FAKupac()
        {
            InitializeComponent();
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (listBox1.Items.Count != 0)
            {
                List<KKupac> lista;
                BinaryFormatter bf = new BinaryFormatter();
                FileStream fs = File.OpenRead("Kupci");
                lista = bf.Deserialize(fs) as List<KKupac>;
                //--------------Brisanje rezervacije-------------------

                List<KRezervacija> lista1;
                FileStream fs2 = File.OpenRead("Rezervacije");
                lista1 = bf.Deserialize(fs2) as List<KRezervacija>;


                for (int i = 0; i < lista1.Count; i++)
                {
                    KRezervacija p = lista1[i];
                    if (p.Idk == lista[listBox1.SelectedIndex].Id)
                    {
                        lista1.RemoveAt(i);
                        i--;
                    }
                }
                fs2.Dispose();
                FileStream fs4 = File.OpenWrite("Rezervacije");
                bf.Serialize(fs4, lista1);
                fs4.Dispose();
                //-----------------------------------------------------
                lista.RemoveAt(listBox1.SelectedIndex);
                fs.Dispose();
                FileStream fs1 = File.OpenWrite("Kupci");
                bf.Serialize(fs1, lista);
                kupci = lista;
                listBox1.DataSource = kupci;
                fs1.Dispose();
                if (!checkBox1.Checked)
                    MessageBox.Show("Kupac Uspešno obrisan");
            }
            else
                MessageBox.Show("Lista kupaca je prazna");
        }

        private void FAKupac_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (kupci.Count == 0)
            {
                File.Delete("Kupci");
                File.Delete("brincK");
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            if (File.Exists("Kupci") && kupci.Count != 0)
            {
                List<KKupac> lista;
                BinaryFormatter bf = new BinaryFormatter();
                FileStream fs = File.OpenRead("Kupci");
                lista = bf.Deserialize(fs) as List<KKupac>;

                KKupac f1 = lista[listBox1.SelectedIndex];
                textBox1.Text = f1.Loz;
                textBox2.Text = f1.Kor_ime;
                textBox3.Text = f1.Br_tel.Replace("/", "").Replace("-", "");
                textBox4.Text = f1.Dat_rodj.Day.ToString();
                textBox5.Text = f1.Dat_rodj.Month.ToString();
                textBox6.Text = f1.Dat_rodj.Year.ToString();
                textBox8.Text = f1.Ime;
                textBox7.Text = f1.Prezime;

                switch (f1.Pol)
                {
                    case 1:
                        radioButton4.Checked = true;
                        radioButton5.Checked = false;
                        radioButton6.Checked = false;
                        break;
                    case 2:
                        radioButton4.Checked = false;
                        radioButton5.Checked = true;
                        radioButton6.Checked = false;
                        break;
                    case 3:
                        radioButton4.Checked = false;
                        radioButton5.Checked = false;
                        radioButton6.Checked = true;
                        break;
                }    

                fs.Dispose();
            }
            else
            {
                MessageBox.Show("Lista kupaca je prazna");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Boolean unq1 = true;
            DateTime ser;
            int prov8 = 0;
            int prov7 = 0;
            int prov6 = 0;
            int prov5 = 0;
            int prov4 = 0;
            int prov3 = 0;
            int prov2 = 0;
            int prov1 = 0;
            int god1 = 1;
            int mes1 = 1;

            DateTime dns = DateTime.Now;
            
            if (File.Exists("Kupci") && kupci.Count != 0)
            {
                List<KKupac> lista;
                BinaryFormatter bf = new BinaryFormatter();
                FileStream fs = File.OpenRead("Kupci");
                lista = bf.Deserialize(fs) as List<KKupac>;

                fs.Dispose();

                int a1, a2, a3;
                Int32.TryParse(textBox4.Text, out a1);
                Int32.TryParse(textBox5.Text, out a2);
                Int32.TryParse(textBox6.Text, out a3);

                KKupac f1 = lista[listBox1.SelectedIndex];

                int d = f1.Dat_rodj.Day;
                int m = f1.Dat_rodj.Month;
                int g = f1.Dat_rodj.Year;

                if (textBox1.Text.Trim().Length != 0)
                {
                    if (textBox1.Text.Trim().Length > 4)
                    {
                        foreach (char c2 in textBox1.Text)
                        {
                            if ((c2 >= '0' && c2 <= '9') || (c2 >= 'a' && c2 <= 'z') || (c2 >= 'A' && c2 <= 'Z'))
                            {
                                f1.Loz = textBox1.Text;
                            }
                            else
                            {
                                prov2 = 1;
                                break;
                            }
                        }
                    }
                    else
                    {
                        prov2 = 1;
                    }
                }

                if (textBox2.Text.Trim().Length != 0)
                {
                    if (textBox2.Text.Trim().Length > 4)
                    {
                        foreach (char c in textBox2.Text)
                        {
                            if ((c >= '0' && c <= '9') || (c >= 'a' && c <= 'z') || (c >= 'A' && c <= 'Z'))
                            {
                                foreach (KKupac kku in kupci)
                                {
                                    if (kku == kupci[listBox1.SelectedIndex])
                                        continue;
                                    if (kku.Kor_ime == textBox2.Text)
                                    {
                                        unq1 = false;
                                    }
                                }
                                f1.Kor_ime = textBox2.Text;
                            }
                            else
                            {
                                prov1 = 1;
                                break;
                            }
                        }


                    }
                    else
                    {
                        prov1 = 1;
                    }
                }

                if (textBox3.Text.Trim().Length != 0)
                {
                    if (textBox3.Text.Trim().Length == 10)
                    {
                        foreach (char c in textBox3.Text)
                        {
                            if (c >= '0' && c <= '9')
                            {

                            }
                            else
                            {
                                prov8 = 1;
                                break;
                            }
                        }

                        if (textBox3.Text[0] == '0')
                        {
                            if (textBox3.Text[1] == '6')
                            {
                                f1.Br_tel = textBox3.Text;
                            }
                            else
                            {
                                prov8 = 1;
                            }
                        }
                        else
                        {
                            prov8 = 1;
                        }
                    }
                    else
                    {
                        prov8 = 1;
                    }
                    
                }


                if (textBox7.Text.Trim().Length != 0)
                {
                    foreach (char c in textBox7.Text)
                    {
                        if ((c >= 'a' && c <= 'z') || (c >= 'A' && c <= 'Z'))
                        {
                            f1.Prezime = textBox7.Text;
                        }
                        else
                        {
                            prov4 = 1;
                            break;
                        }
                    }

                }

                if (textBox8.Text.Trim().Length != 0)
                {
                    foreach (char c in textBox8.Text)
                    {
                        if ((c >= 'a' && c <= 'z') || (c >= 'A' && c <= 'Z'))
                        {
                            f1.Ime = textBox8.Text;
                        }
                        else
                        {
                            prov3 = 1;
                            break;
                        }
                    }
                    
                }

                //-----------Godina---------------------------------
                if (textBox6.Text.Trim().Length != 0)
                {
                    if (Int32.TryParse(textBox6.Text, out a3) && a3 > 0)
                    {
                        if (textBox6.Text.Trim().Length == 4)
                        {
                            int godI = dns.Year;



                            if (a3 % 4 == 0)
                            {
                                if (a3 % 100 == 0 && a3 % 400 != 0)
                                    godt = false;
                                else
                                    godt = true;
                            }
                            else
                                godt = false;

                            if (a3 <= godI)
                            {
                                if (a3 == godI)
                                {
                                    god1 = 0;
                                }
                                else
                                    god1 = 1;

                                g = a3;
                            }
                            else
                            {
                                prov7 = 1;
                            }
                        }
                        else
                        {
                            prov7 = 1;
                        }
                    }
                    else
                    {
                        prov7 = 1;
                    }
                }

                //-----------Mesec----------------------------------
                if (textBox5.Text.Trim().Length != 0)
                {
                    if (Int32.TryParse(textBox5.Text, out a2) && (textBox5.Text.Length == 1 || textBox5.Text.Length == 2))
                    {
                        int mesI = dns.Month;
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
                                if (a2 <= mesI)
                                {
                                    if (a2 == mesI)
                                        mes1 = 0;
                                    else
                                        mes1 = 1;
                                }
                                else
                                    prov6 = 1;

                            }
                            m = a2;
                        }
                        else
                        {
                            prov6 = 1;
                        }
                    }
                    else
                    {
                        prov6 = 1;
                    }
                }

                //-----------Dan------------------------------------
                if (textBox4.Text.Trim().Length != 0)
                {
                    if (Int32.TryParse(textBox4.Text, out a1))
                    {
                        int danI = dns.Day;
                        if (mest == 1)
                        {
                            if (a1 > 31 || a1 < 1)
                            {
                                prov5 = 1;
                            }
                        }

                        if (mest == 2)
                        {
                            if (a1 > 30 || a1 < 1)
                            {
                                prov5 = 1;
                            }
                        }

                        if (mest == 3 && !godt)
                        {
                            if (a1 > 28 || a1 < 1)
                            {
                                prov5 = 1;
                            }
                        }

                        if (mest == 3 && godt)
                        {
                            if (a1 > 29 || a1 < 1)
                            {
                                prov5 = 1;
                            }
                        }



                        if (mes1 == 0)
                        {

                            if (a1 <= danI)
                            {
                                if (a1 == danI)
                                {
                                    dan1 = 0;
                                }
                                else
                                {
                                    dan1 = 1;
                                }
                            }
                            else
                            {
                                prov5 = 1;
                            }
                        }
                        d = a1;
                    }
                    else
                    {
                        prov5 = 1;
                    }
                }

                if (radioButton4.Checked)
                    f1.Pol = 1;
                if (radioButton5.Checked)
                    f1.Pol = 2;
                if (radioButton6.Checked)
                    f1.Pol = 3;


                ser = new DateTime(g, m, d);
                f1.Dat_rodj = ser;

                lista[listBox1.SelectedIndex] = f1;
                if (unq1 && prov8 == 0 && prov7 == 0 && prov6 == 0 && prov5 == 0 && prov4 == 0 && prov3 == 0 && prov2 == 0 && prov1 == 0)
                {
                    FileStream fs1 = File.OpenWrite("Kupci");
                    bf.Serialize(fs1, lista);
                    fs1.Dispose();
                    kupci = lista;
                    listBox1.DataSource = kupci;

                    textBox1.Clear();
                    textBox2.Clear();
                    textBox3.Clear();
                    textBox4.Clear();
                    textBox5.Clear();
                    textBox6.Clear();
                    textBox7.Clear();
                    textBox8.Clear();


                    if (!checkBox1.Checked)
                        MessageBox.Show("Kupac Uspešno ažuriran");
                }
                else
                {
                    if (prov8 != 0 || prov7 != 0 || prov6 != 0 || prov5 != 0 || prov4 != 0 || prov3 != 0 || prov2 != 0 || prov1 != 0)
                    {
                        MessageBox.Show("Ime i Prezime: " + Environment.NewLine + "     " + " - Ime i prezime mogu sadržati samo slova" + Environment.NewLine + Environment.NewLine + "Dan:" + Environment.NewLine + "     " + "-Dan mora biti broj" + Environment.NewLine + Environment.NewLine + "Mesec: " + Environment.NewLine + "     " + " - Mesec mora biti broj" + Environment.NewLine + Environment.NewLine + "Godina: " + Environment.NewLine + " - Godina mora imati 4 broja i biti manja od trenutne" + Environment.NewLine + "     " +
                        "Trenutan datum: " + DateTime.Now.Day + "." + DateTime.Now.Month + "." + DateTime.Now.Year + Environment.NewLine + Environment.NewLine + "Broj Telefona: " + Environment.NewLine + "     " + "Broj telefona se kuca kao 06########, i ima deset brojeva" + Environment.NewLine + Environment.NewLine + "Korisničko ime i lozinka: " + Environment.NewLine + "     " + "Lozinka i korisičko ime moraju imati minimum 5 karaktera, dozvoljeni karakteri su brojevi, mala i velika slova");
                    }
                    else
                        MessageBox.Show("Već postoji nalog sa tim korisničkim imenom");
                    
                }


            }
            else
            {
                MessageBox.Show("Lista kupaca je prazna");
            }
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox3.Checked)
                txt21_2.PasswordChar = '\0';
            else
                txt21_2.PasswordChar = '*';
        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox4.Checked)
                textBox1.PasswordChar = '\0';
            else
                textBox1.PasswordChar = '*';
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void txt21_7_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void FAKupac_Load(object sender, EventArgs e)
        {
            if (File.Exists("Kupci"))
            {
                BinaryFormatter bf = new BinaryFormatter();
                FileStream fs = File.OpenRead("Kupci");
                kupci = bf.Deserialize(fs) as List<KKupac>;
                fs.Dispose();
                listBox1.DataSource = kupci;
            }
            if (File.Exists("brincK"))
            {
                FileStream fs = File.OpenRead("brincK");
                string str = File.ReadAllText("brincK");
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

        private void btn21_1_Click(object sender, EventArgs e)
        {
            string kori = txt21_1.Text;
            god1 = 1;
            mes1 = 1;
            dan1 = 1;
            int prov2 = 0;
            if (txt21_1.Text.Trim().Length != 0 && txt21_2.Text.Trim().Length != 0 && txt21_3.Text.Trim().Length != 0 && txt21_4.Text.Trim().Length != 0 &&
                txt21_5.Text.Trim().Length != 0 && txt21_6.Text.Trim().Length != 0 && txt21_7.Text.Trim().Length != 0 && txt21_8.Text.Trim().Length != 0)
            {
                foreach (char c in txt21_3.Text) //1--------------------------------------------------------------
                    if ((c >= 'a' && c <= 'z') || (c >= 'A' && c <= 'Z'))
                    {

                    }
                    else
                    {
                        prov2 += 1;
                        break;
                    }



                foreach (char c in txt21_4.Text) //2--------------------------------------------------------------
                    if ((c >= 'a' && c <= 'z') || (c >= 'A' && c <= 'Z'))
                    {

                    }
                    else
                    {
                        prov2 += 2;
                        break;
                    }



                if (txt21_5.Text.Trim().Length == 4) //4--------------------------------------------------------------
                {

                    int prov5 = 0;
                    foreach (char c in txt21_5.Text)
                    {
                        if (c >= '0' && c <= '9')
                        {

                        }
                        else
                        {
                            prov2 += 4; //<-------------------------------------------------------
                            prov5 = 1;
                            break;
                        }
                    }
                    int prv;
                    DateTime godP = DateTime.Now;
                    int godI = godP.Year;
                    Int32.TryParse(txt21_5.Text, out prv);

                    if (prv % 4 == 0)
                    {
                        if (prv % 100 == 0 && prv % 400 != 0)
                            godt = false;
                        else
                            godt = true;
                    }
                    else
                        godt = false;

                    if (prv <= godI && prov5 == 0)
                    {
                        if (prv == godI)
                        {
                            god1 = 0;
                        }
                        else
                            god1 = 1;
                    }
                    else
                    {
                        if (prov5 == 0)
                            god1 = -1;
                    }
                }
                else
                {
                    prov2 += 4;
                }



                if (txt21_6.Text.Trim().Length == 1 || txt21_6.Text.Trim().Length == 2) //8--------------------------------------------------------------
                {
                    int prov6 = 0;
                    foreach (char c in txt21_6.Text)
                    {
                        if (c >= '0' && c <= '9')
                        {

                        }
                        else
                        {
                            prov2 += 8; //<-------------------------------------------------------
                            prov6 = 1;
                            break;
                        }

                    }
                    int prv;
                    DateTime mesP = DateTime.Now;
                    int mesI = mesP.Month;
                    Int32.TryParse(txt21_6.Text, out prv);

                    if (prv > 12 || prv < 1)
                    {
                        if (prov6 != 1)
                        {
                            prov2 += 8;
                            prov6 = 1;
                        }
                    }

                    if (prv == 1 || prv == 3 || prv == 5 || prv == 7 || prv == 8 || prv == 10 || prv == 12)
                        mest = 1;
                    if (prv == 4 || prv == 6 || prv == 9 || prv == 11)
                        mest = 2;
                    if (prv == 2)
                        mest = 3;


                    if (god1 == 0)
                    {
                        if (prv <= mesI && prov6 == 0)
                        {
                            if (prv == mesI)
                            {
                                mes1 = 0;
                            }
                            else
                            {
                                mes1 = 1;
                            }
                        }
                        else
                        {
                            prov2 += 0; //<-------------------------------------------------------
                            if (prov6 == 0)
                            {
                                mes1 = -1;
                            }
                            
                        }
                    }

                }
                else
                {
                    prov2 += 8;
                }



                if (txt21_7.Text.Trim().Length == 1 || txt21_7.Text.Trim().Length == 2) //16--------------------------------------------------------------
                {
                    int prov7 = 0;
                    foreach (char c in txt21_7.Text)
                    {
                        if (c >= '0' && c <= '9')
                        {

                        }
                        else
                        {
                            prov2 += 16; //<-------------------------------------------------------
                            prov7 = 1;
                            break;
                        }
                    }
                    int prv;
                    DateTime danP = DateTime.Now;
                    int danI = danP.Day;
                    Int32.TryParse(txt21_7.Text, out prv);

                    if (mest == 1)
                    {
                        if (prv > 31 || prv < 1)
                        {
                            if (prov7 != 1)
                            {
                                prov2 += 16; //<-------------------------------------------------------
                                prov7 = 1;
                            }
                        }
                    }

                    if (mest == 2)
                    {
                        if (prv > 30 || prv < 1)
                        {
                            prov2 += 16; //<-------------------------------------------------------
                            prov7 = 1;
                        }
                    }

                    if (mest == 3 && !godt)
                    {
                        if (prv > 28 || prv < 1)
                        {
                            prov2 += 16; //<-------------------------------------------------------
                            prov7 = 1;
                        }
                    }

                    if (mest == 3 && godt)
                    {
                        if (prv > 29 || prv < 1)
                        {
                            prov2 += 16; //<-------------------------------------------------------
                            prov7 = 1;
                        }
                    }




                    if (mes1 == 0)
                    {

                        if (prv <= danI && prov7 == 0)
                        {
                            if (prv == danI)
                            {
                                dan1 = 0;
                            }
                            else
                            {
                                dan1 = 1;
                            }
                        }
                        else
                        {
                            prov2 += 0; //<-------------------------------------------------------
                            if(prov7 == 0)
                                dan1 = -1;
                        }
                    }
                }
                else
                {
                    prov2 += 16;
                }



                if (txt21_8.Text.Trim().Length == 10) //32--------------------------------------------------------------
                {
                    int prov8 = 0;
                    foreach (char c in txt21_8.Text)
                    {
                        if (c >= '0' && c <= '9')
                        {

                        }
                        else
                        {
                            prov2 += 32;
                            prov8 = 1;
                            break;
                        }
                    }

                    if (txt21_8.Text[0] == '0' && prov8 == 0)
                    {
                        if (txt21_8.Text[1] == '6')
                        {
                            tel = txt21_8.Text;
                        }
                        else
                        {
                            prov2 += 32;
                        }
                    }
                    else
                    {
                        prov2 += 32;
                    }

                }
                else
                {
                    prov2 += 32;
                }




                if (god1 == -1)
                {
                    //MessageBox.Show("Godina mora biti manja od trenutne" + Environment.NewLine + "Trenutan datum: " + DateTime.Now.Day + "." + DateTime.Now.Month + "." + DateTime.Now.Year);
                    prov2 += 4;
                }

                if (mes1 == -1)
                {
                    //MessageBox.Show("Mesec mora biti manji od trenutnog" + Environment.NewLine + "Trenutan datum: " + DateTime.Now.Day + "." + DateTime.Now.Month + "." + DateTime.Now.Year);
                    prov2 += 8;
                }

                if (dan1 == -1)
                {
                    //MessageBox.Show("Dan mora biti manji od trenutnog" + Environment.NewLine + "Trenutan datum: " + DateTime.Now.Day + "." + DateTime.Now.Month + "." + DateTime.Now.Year);
                    prov2 += 16;
                }

                if (radioButton1.Checked)
                    pol = 1;
                if (radioButton2.Checked)
                    pol = 2;
                if (radioButton3.Checked)
                    pol = 3;

                int provG = 0;
                Boolean unique1 = true;

                if (prov2 == 0)
                {
                    dt = new DateTime(int.Parse(txt21_5.Text), int.Parse(txt21_6.Text), int.Parse(txt21_7.Text));
                    if (txt21_1.Text.Trim().Length > 4)
                    {
                        foreach (char c in txt21_1.Text)
                        {
                            if ((c >= '0' && c <= '9') || (c >= 'a' && c <= 'z') || (c >= 'A' && c <= 'Z'))
                            {
                                foreach (KKupac ku in kupci)
                                {
                                    if (txt21_1.Text == ku.Kor_ime)
                                    {

                                        unique1 = false;
                                        break;
                                    }
                                }
                                
                            }
                            else
                            {
                                provG += 1;
                                break;
                            }
                        }


                    }
                    else
                    {
                        provG += 1;
                    }

                    if (txt21_2.Text.Trim().Length > 4)
                    {
                        foreach (char c2 in txt21_2.Text)
                        {
                            if ((c2 >= '0' && c2 <= '9') || (c2 >= 'a' && c2 <= 'z') || (c2 >= 'A' && c2 <= 'Z'))
                            {
                                loz = txt21_2.Text;
                            }
                            else
                            {
                                provG += 2;
                                break;
                            }
                        }
                    }
                    else
                    {
                        provG += 2;
                    }

                    if (provG == 0 && unique1)
                    {
                        KKupac k = new KKupac(brinc, txt21_3.Text, txt21_4.Text, dt, tel, loz, kori, pol);
                        brinc++;
                        File.WriteAllText("brincK", brinc.ToString());
                        kupci.Add(k);

                        BinaryFormatter bf = new BinaryFormatter();
                        FileStream fs = File.OpenWrite("Kupci");

                        bf.Serialize(fs, kupci);


                        fs.Dispose();

                        List<KKupac> lista;
                        FileStream fs1 = File.OpenRead("Kupci");
                        lista = bf.Deserialize(fs1) as List<KKupac>;
                        listBox1.DataSource = lista;
                        fs1.Dispose();

                        if(!checkBox1.Checked)
                            MessageBox.Show("Uspesno ste dodali kupca");

                        if (checkBox2.Checked)
                        {
                        txt21_1.Clear();
                        txt21_2.Clear();
                        txt21_3.Clear();
                        txt21_4.Clear();
                        txt21_5.Clear();
                        txt21_6.Clear();
                        txt21_7.Clear();
                        txt21_8.Clear();
                        }    

                    }


                }

                switch (provG)
                {
                    case 1:
                        MessageBox.Show("Korisičko ime mora imati minimum 5 karaktera, dozvoljeni karakteri su brojevi, mala i velika slova");
                        break;
                    case 2:
                        MessageBox.Show("Lozinka mora imati minimum 5 karaktera, dozvoljeni karakteri su brojevi, mala i velika slova");
                        break;
                    case 3:
                        MessageBox.Show("Lozinka i korisičko ime moraju imati minimum 5 karaktera, dozvoljeni karakteri su brojevi, mala i velika slova");
                        break;
                }

                if (provG == 0 && !unique1)
                {
                    MessageBox.Show("Već postoji nalog sa tim korisničkim imenom");
                }








            }
            else
            {
                MessageBox.Show("Sva polja moraju biti popunjena");
            }

            switch (prov2) //Switch---Switch---Switch---Switch---Switch---Switch---Switch---Switch---Switch---Switch---Switch---Switch---Switch---Switch---Switch---Switch---Switch---Switch---Switch---Switch
            {
                case 1:
                    MessageBox.Show("-Ime može sadržati samo slova");
                    break;
                case 2:
                    MessageBox.Show("-Prezime može sadržati samo slova");
                    break;
                case 3:
                    MessageBox.Show("-Ime i prezime mogu sadržati samo slova");
                    break;
                case 4:
                    MessageBox.Show("-Godina mora imati 4 broja i biti manja od trenutne" + Environment.NewLine + "Trenutan datum: " + DateTime.Now.Day + "." + DateTime.Now.Month + "." + DateTime.Now.Year);
                    break;
                case 5:
                    MessageBox.Show("Godina:" + Environment.NewLine + "     " + "-Godina mora imati 4 broja i biti manja od trenutne" + Environment.NewLine + "     " +
                        "Trenutan datum: " + DateTime.Now.Day + "." + DateTime.Now.Month + "." + DateTime.Now.Year + Environment.NewLine + Environment.NewLine + "Ime:" + Environment.NewLine + "     " + "-Ime može sadržati samo slova");
                    break;
                case 6:
                    MessageBox.Show("Godina:" + Environment.NewLine + "     " + "-Godina mora imati 4 broja i biti manja od trenutne" + Environment.NewLine + "     " +
                        "Trenutan datum: " + DateTime.Now.Day + "." + DateTime.Now.Month + "." + DateTime.Now.Year + Environment.NewLine + Environment.NewLine + "Prezime:" + Environment.NewLine + "     " + "-Prezime može sadržati samo slova");
                    break;
                case 7:
                    MessageBox.Show("Godina: " + Environment.NewLine + "     " + "-Godina mora imati 4 broja i biti manja od trenutne" + Environment.NewLine + "     " +
                        "Trenutan datum: " + DateTime.Now.Day + "." + DateTime.Now.Month + "." + DateTime.Now.Year + Environment.NewLine + Environment.NewLine + "Ime i Prezime:" + Environment.NewLine + "     " + "-Ime i prezime mogu sadržati samo slova");
                    break;
                case 8:
                    MessageBox.Show("-Mesec mora biti broj");
                    break;
                case 9:
                    MessageBox.Show("Ime:" + Environment.NewLine + "     " + "-Ime može sadržati samo slova" + Environment.NewLine + Environment.NewLine + "Mesec:" + Environment.NewLine + "-Mesec mora biti broj");
                    break;
                case 10:
                    MessageBox.Show("Prezime:" + Environment.NewLine + "     " + "-Prezime može sadržati samo slova" + Environment.NewLine + Environment.NewLine + "Mesec:" + Environment.NewLine + "-Mesec mora biti broj");
                    break;
                case 11:
                    MessageBox.Show("Ime i Prezime:" + Environment.NewLine + "     " + "-Ime i prezime može sadržati samo slova" + Environment.NewLine + Environment.NewLine + "Mesec:" + Environment.NewLine + "-Mesec mora biti broj");
                    break;
                case 12:
                    MessageBox.Show("Mesec:" + Environment.NewLine + "     " + "-Mesec mora biti broj" + Environment.NewLine + Environment.NewLine + "Godina:" + Environment.NewLine + "-Godina mora imati 4 broja i biti manja od trenutne" + Environment.NewLine + "     " +
                        "Trenutan datum: " + DateTime.Now.Day + "." + DateTime.Now.Month + "." + DateTime.Now.Year);
                    break;
                case 13:
                    MessageBox.Show("Ime:" + Environment.NewLine + "     " + "-Ime može sadržati samo slova" + Environment.NewLine + Environment.NewLine + "Mesec:" + Environment.NewLine + "-Mesec mora biti broj" + Environment.NewLine + Environment.NewLine + "Godina:" + Environment.NewLine + "-Godina mora imati 4 broja i biti manja od trenutne" + Environment.NewLine + "     " +
                        "Trenutan datum: " + DateTime.Now.Day + "." + DateTime.Now.Month + "." + DateTime.Now.Year);
                    break;
                case 14:
                    MessageBox.Show("Prezime:" + Environment.NewLine + "     " + "-Prezime može sadržati samo slova" + Environment.NewLine + Environment.NewLine + "Mesec:" + Environment.NewLine + "-Mesec mora biti broj" + Environment.NewLine + Environment.NewLine + "Godina:" + Environment.NewLine + "-Godina mora imati 4 broja i biti manja od trenutne" + Environment.NewLine + "     " +
                        "Trenutan datum: " + DateTime.Now.Day + "." + DateTime.Now.Month + "." + DateTime.Now.Year);
                    break;
                case 15:
                    MessageBox.Show("Ime i Prezime:" + Environment.NewLine + "     " + "-Ime i prezime mogu sadržati samo slova" + Environment.NewLine + Environment.NewLine + "Mesec:" + Environment.NewLine + "-Mesec mora biti broj" + Environment.NewLine + Environment.NewLine + "Godina:" + Environment.NewLine + "-Godina mora imati 4 broja i biti manja od trenutne" + Environment.NewLine + "     " +
                        "Trenutan datum: " + DateTime.Now.Day + "." + DateTime.Now.Month + "." + DateTime.Now.Year);
                    break;
                case 16:
                    MessageBox.Show("Dan mora biti broj");
                    break;
                case 17:
                    MessageBox.Show("Ime:" + Environment.NewLine + "     " + "-Ime može sadržati samo slova" + Environment.NewLine + Environment.NewLine + "Dan:" + Environment.NewLine + "     " + "-Dan mora biti broj");
                    break;
                case 18:
                    MessageBox.Show("Prezime:" + Environment.NewLine + "     " + "-Prezime može sadržati samo slova" + Environment.NewLine + Environment.NewLine + "Dan:" + Environment.NewLine + "     " + "-Dan mora biti broj");
                    break;
                case 19:
                    MessageBox.Show("Ime i Prezime:" + Environment.NewLine + "     " + "-Ime i prezime mogu sadržati samo slova" + Environment.NewLine + Environment.NewLine + "Dan:" + Environment.NewLine + "     " + "-Dan mora biti broj");
                    break;
                case 20:
                    MessageBox.Show("Dan:" + Environment.NewLine + "     " + "-Dan mora biti broj" + Environment.NewLine + Environment.NewLine + "Godina:" + Environment.NewLine + "     " + "-Godina mora imati 4 broja i biti manja od trenutne" + Environment.NewLine + "Trenutan datum: " + DateTime.Now.Day + "." + DateTime.Now.Month + "." + DateTime.Now.Year);
                    break;
                case 21:
                    MessageBox.Show("Ime:" + Environment.NewLine + "     " + "-Ime može sadržati samo slova" + Environment.NewLine + Environment.NewLine + "Dan:" + Environment.NewLine + "     " + "-Dan mora biti broj" + Environment.NewLine + Environment.NewLine + "Godina:" + Environment.NewLine + "-Godina mora imati 4 broja i biti manja od trenutne" + Environment.NewLine + "     " +
                        "Trenutan datum: " + DateTime.Now.Day + "." + DateTime.Now.Month + "." + DateTime.Now.Year);
                    break;
                case 22:
                    MessageBox.Show("Prezime:" + Environment.NewLine + "     " + "-Prezime može sadržati samo slova" + Environment.NewLine + Environment.NewLine + "Dan:" + Environment.NewLine + "     " + "-Dan mora biti broj" + Environment.NewLine + Environment.NewLine + "Godina:" + Environment.NewLine + "-Godina mora imati 4 broja i biti manja od trenutne" + Environment.NewLine + "     " +
                        "Trenutan datum: " + DateTime.Now.Day + "." + DateTime.Now.Month + "." + DateTime.Now.Year);
                    break;
                case 23:
                    MessageBox.Show("Ime i Prezime:" + Environment.NewLine + "     " + "-Ime i prezime mogu sadržati samo slova" + Environment.NewLine + Environment.NewLine + "Dan:" + Environment.NewLine + "     " + "-Dan mora biti broj" + Environment.NewLine + Environment.NewLine + "Godina:" + Environment.NewLine + "-Godina mora imati 4 broja i biti manja od trenutne" + Environment.NewLine + "     " +
                        "Trenutan datum: " + DateTime.Now.Day + "." + DateTime.Now.Month + "." + DateTime.Now.Year);
                    break;
                case 24:
                    MessageBox.Show("Dan:" + Environment.NewLine + "     " + "-Dan mora biti broj" + Environment.NewLine + Environment.NewLine + "Mesec:" + Environment.NewLine + "     " + "-Mesec mora biti broj");
                    break;
                case 25:
                    MessageBox.Show("Ime: " + Environment.NewLine + "     " + "-Ime može sadržati samo slova" + Environment.NewLine + Environment.NewLine + "Dan:" + Environment.NewLine + "     " + "-Dan mora biti broj" + Environment.NewLine + Environment.NewLine + "Mesec: " + Environment.NewLine + " - Mesec mora biti broj");
                    break;
                case 26:
                    MessageBox.Show("Prezime:" + Environment.NewLine + "     " + "-Prezime može sadržati samo slova" + Environment.NewLine + Environment.NewLine + "Dan:" + Environment.NewLine + "     " + "-Dan mora biti broj" + Environment.NewLine + Environment.NewLine + "Mesec:" + Environment.NewLine + "-Mesec mora biti broj");
                    break;
                case 27:
                    MessageBox.Show("Ime i Prezime:" + Environment.NewLine + "     " + "-Ime i prezime mogu sadržati samo slova" + Environment.NewLine + Environment.NewLine + "Dan:" + Environment.NewLine + "     " + "-Dan mora biti broj" + Environment.NewLine + Environment.NewLine + "Mesec:" + Environment.NewLine + "-Mesec mora biti broj");
                    break;
                case 28:
                    MessageBox.Show("Dan:" + Environment.NewLine + "     " + "-Dan mora biti broj" + Environment.NewLine + Environment.NewLine + "Mesec: " + Environment.NewLine + "     " + " - Mesec mora biti broj" + Environment.NewLine + Environment.NewLine + "Godina: " + Environment.NewLine + " - Godina mora imati 4 broja i biti manja od trenutne" + Environment.NewLine + "     " +
                        "Trenutan datum: " + DateTime.Now.Day + "." + DateTime.Now.Month + "." + DateTime.Now.Year);
                    break;
                case 29:
                    MessageBox.Show("Ime:" + Environment.NewLine + "     " + "-Ime može sadržati samo slova" + Environment.NewLine + Environment.NewLine + "Dan: " + Environment.NewLine + "     " + " - Dan mora biti broj" + Environment.NewLine + Environment.NewLine + "Mesec: " + Environment.NewLine + "     " + " - Mesec mora biti broj" + Environment.NewLine + Environment.NewLine + "Godina: " + Environment.NewLine + " - Godina mora imati 4 broja i biti manja od trenutne" + Environment.NewLine + "     " +
                        "Trenutan datum: " + DateTime.Now.Day + "." + DateTime.Now.Month + "." + DateTime.Now.Year);
                    break;
                case 30:
                    MessageBox.Show("Prezime:" + Environment.NewLine + "     " + "-Prezime može sadržati samo slova" + Environment.NewLine + Environment.NewLine + "Dan: " + Environment.NewLine + "     " + " - Dan mora biti broj" + Environment.NewLine + Environment.NewLine + "Mesec: " + Environment.NewLine + "     " + " - Mesec mora biti broj" + Environment.NewLine + Environment.NewLine + "Godina: " + Environment.NewLine + " - Godina mora imati 4 broja i biti manja od trenutne" + Environment.NewLine + "     " +
                        "Trenutan datum: " + DateTime.Now.Day + "." + DateTime.Now.Month + "." + DateTime.Now.Year);
                    break;
                case 31:
                    MessageBox.Show("Ime i Prezime:" + Environment.NewLine + "     " + "-Ime i prezime mogu sadržati samo slova" + Environment.NewLine + Environment.NewLine + "Dan: " + Environment.NewLine + "     " + " - Dan mora biti broj" + Environment.NewLine + Environment.NewLine + "Mesec: " + Environment.NewLine + "     " + " - Mesec mora biti broj" + Environment.NewLine + Environment.NewLine + "Godina: " + Environment.NewLine + " - Godina mora imati 4 broja i biti manja od trenutne" + Environment.NewLine + "     " +
                        "Trenutan datum: " + DateTime.Now.Day + "." + DateTime.Now.Month + "." + DateTime.Now.Year);
                    break;
                case 32:
                    MessageBox.Show("Broj telefona se kuca kao 06########, i ima deset brojeva");
                    break;
                case 33:
                    MessageBox.Show("Ime: " + Environment.NewLine + "     " + "-Ime može sadržati samo slova" + Environment.NewLine + Environment.NewLine + "Broj Telefona:" + Environment.NewLine + "     " + "Broj telefona se kuca kao 06########, i ima deset brojeva");
                    break;
                case 34:
                    MessageBox.Show("Prezime: " + Environment.NewLine + "     " + "-Prezime može sadržati samo slova" + Environment.NewLine + Environment.NewLine + "Broj Telefona:" + Environment.NewLine + "     " + "Broj telefona se kuca kao 06########, i ima deset brojeva");
                    break;
                case 35:
                    MessageBox.Show("Ime i Prezime: " + Environment.NewLine + "     " + "-Ime i prezime mogu sadržati samo slova" + Environment.NewLine + Environment.NewLine + "Broj Telefona:" + Environment.NewLine + "     " + "Broj telefona se kuca kao 06########, i ima deset brojeva");
                    break;
                case 36:
                    MessageBox.Show("Godina: " + Environment.NewLine + "     " + " - Godina mora imati 4 broja i biti manja od trenutne" + Environment.NewLine + "     " +
                        "Trenutan datum: " + DateTime.Now.Day + "." + DateTime.Now.Month + "." + DateTime.Now.Year + Environment.NewLine + Environment.NewLine + "Broj Telefona:" + Environment.NewLine + "     " + "Broj telefona se kuca kao 06########, i ima deset brojeva");
                    break;
                case 37:
                    MessageBox.Show("Ime: " + Environment.NewLine + "     " + "-Ime može sadržati samo slova" + Environment.NewLine + Environment.NewLine + "Godina: " + Environment.NewLine + "     " + " - Godina mora imati 4 broja i biti manja od trenutne" + Environment.NewLine + "     " +
                        "Trenutan datum: " + DateTime.Now.Day + "." + DateTime.Now.Month + "." + DateTime.Now.Year + Environment.NewLine + Environment.NewLine + "Broj Telefona:" + Environment.NewLine + "     " + "Broj telefona se kuca kao 06########, i ima deset brojeva");
                    break;
                case 38:
                    MessageBox.Show("Prezime: " + Environment.NewLine + "     " + "-Prezime može sadržati samo slova" + Environment.NewLine + Environment.NewLine + "Godina: " + Environment.NewLine + "     " + " - Godina mora imati 4 broja i biti manja od trenutne" + Environment.NewLine + "     " +
                        "Trenutan datum: " + DateTime.Now.Day + "." + DateTime.Now.Month + "." + DateTime.Now.Year + Environment.NewLine + Environment.NewLine + "Broj Telefona:" + Environment.NewLine + "     " + "Broj telefona se kuca kao 06########, i ima deset brojeva");
                    break;
                case 39:
                    MessageBox.Show("Ime i Prezime: " + Environment.NewLine + "     " + " - Ime i prezime mogu sadržati samo slova" + Environment.NewLine + Environment.NewLine + "Godina: " + Environment.NewLine + "     " + " - Godina mora imati 4 broja i biti manja od trenutne" + Environment.NewLine + "     " +
                        "Trenutan datum: " + DateTime.Now.Day + "." + DateTime.Now.Month + "." + DateTime.Now.Year + Environment.NewLine + Environment.NewLine + "Broj Telefona:" + Environment.NewLine + "     " + "Broj telefona se kuca kao 06########, i ima deset brojeva");
                    break;
                case 40:
                    MessageBox.Show("Mesec: " + Environment.NewLine + "     " + " - Mesec mora biti broj" + Environment.NewLine + Environment.NewLine + "Broj Telefona:" + Environment.NewLine + "     " + "Broj telefona se kuca kao 06########, i ima deset brojeva");
                    break;
                case 41:
                    MessageBox.Show("Ime: " + Environment.NewLine + "     " + "-Ime može sadržati samo slova" + Environment.NewLine + Environment.NewLine + "Mesec: " + Environment.NewLine + "     " + " - Mesec mora biti broj" + Environment.NewLine + Environment.NewLine + "Broj Telefona: " + Environment.NewLine + "     " + "Broj telefona se kuca kao 06########, i ima deset brojeva");
                    break;
                case 42:
                    MessageBox.Show("Prezime: " + Environment.NewLine + "     " + "-Prezime može sadržati samo slova" + Environment.NewLine + Environment.NewLine + "Mesec: " + Environment.NewLine + "     " + " - Mesec mora biti broj" + Environment.NewLine + Environment.NewLine + "Broj Telefona:" + Environment.NewLine + "     " + "Broj telefona se kuca kao 06########, i ima deset brojeva");
                    break;
                case 43:
                    MessageBox.Show("Ime i Prezime: " + Environment.NewLine + "     " + " - Ime i prezime mogu sadržati samo slova" + Environment.NewLine + Environment.NewLine + "Mesec: " + Environment.NewLine + "     " + " - Mesec mora biti broj" + Environment.NewLine + Environment.NewLine + "Broj Telefona:" + Environment.NewLine + "     " + "Broj telefona se kuca kao 06########, i ima deset brojeva");
                    break;
                case 44:
                    MessageBox.Show("Mesec: " + Environment.NewLine + "     " + " - Mesec mora biti broj" + Environment.NewLine + Environment.NewLine + "Godina:" + Environment.NewLine + "     " + "-Godina mora imati 4 broja i biti manja od trenutne" + Environment.NewLine + "     " +
                        "Trenutan datum: " + DateTime.Now.Day + "." + DateTime.Now.Month + "." + DateTime.Now.Year + Environment.NewLine + Environment.NewLine + "Broj Telefona:" + Environment.NewLine + "     " + "Broj telefona se kuca kao 06########, i ima deset brojeva");
                    break;
                case 45:
                    MessageBox.Show("Ime: " + Environment.NewLine + "     " + "-Ime može sadržati samo slova" + Environment.NewLine + Environment.NewLine + "Mesec: " + Environment.NewLine + "     " + " - Mesec mora biti broj" + Environment.NewLine + Environment.NewLine + "Godina:" + Environment.NewLine + "     " + "-Godina mora imati 4 broja i biti manja od trenutne" + Environment.NewLine + "     " +
                        "Trenutan datum: " + DateTime.Now.Day + "." + DateTime.Now.Month + "." + DateTime.Now.Year + Environment.NewLine + Environment.NewLine + "Broj Telefona:" + Environment.NewLine + "     " + "Broj telefona se kuca kao 06########, i ima deset brojeva");
                    break;
                case 46:
                    MessageBox.Show("Prezime: " + Environment.NewLine + "     " + "-Prezime može sadržati samo slova" + Environment.NewLine + Environment.NewLine + "Mesec: " + Environment.NewLine + "     " + " - Mesec mora biti broj" + Environment.NewLine + Environment.NewLine + "Godina:" + Environment.NewLine + "     " + "-Godina mora imati 4 broja i biti manja od trenutne" + Environment.NewLine + "     " +
                        "Trenutan datum: " + DateTime.Now.Day + "." + DateTime.Now.Month + "." + DateTime.Now.Year + Environment.NewLine + Environment.NewLine + "Broj Telefona:" + Environment.NewLine + "     " + "Broj telefona se kuca kao 06########, i ima deset brojeva");
                    break;
                case 47:
                    MessageBox.Show("Ime i Prezime: " + Environment.NewLine + "     " + " - Ime i prezime mogu sadržati samo slova" + Environment.NewLine + Environment.NewLine + "Mesec: " + Environment.NewLine + "     " + " - Mesec mora biti broj" + Environment.NewLine + Environment.NewLine + "Godina:" + Environment.NewLine + "     " + "-Godina mora imati 4 broja i biti manja od trenutne" + Environment.NewLine + "     " +
                        "Trenutan datum: " + DateTime.Now.Day + "." + DateTime.Now.Month + "." + DateTime.Now.Year + Environment.NewLine + Environment.NewLine + "Broj Telefona:" + Environment.NewLine + "     " + "Broj telefona se kuca kao 06########, i ima deset brojeva");
                    break;
                case 48:
                    MessageBox.Show("Dan:" + Environment.NewLine + "     " + "-Dan mora biti broj" + Environment.NewLine + Environment.NewLine + "Broj Telefona:" + Environment.NewLine + "     " + "Broj telefona se kuca kao 06########, i ima deset brojeva");
                    break;
                case 49:
                    MessageBox.Show("Ime: " + Environment.NewLine + "     " + "-Ime može sadržati samo slova" + Environment.NewLine + Environment.NewLine + "Dan:" + Environment.NewLine + "     " + "-Dan mora biti broj" + Environment.NewLine + Environment.NewLine + "Broj Telefona:" + Environment.NewLine + "     " + "Broj telefona se kuca kao 06########, i ima deset brojeva");
                    break;
                case 50:
                    MessageBox.Show("Prezime: " + Environment.NewLine + "     " + "-Prezime može sadržati samo slova" + Environment.NewLine + Environment.NewLine + "Dan:" + Environment.NewLine + "     " + "-Dan mora biti broj" + Environment.NewLine + Environment.NewLine + "Broj Telefona:" + Environment.NewLine + "     " + "Broj telefona se kuca kao 06########, i ima deset brojeva");
                    break;
                case 51:
                    MessageBox.Show("Ime i Prezime: " + Environment.NewLine + "     " + " - Ime i prezime mogu sadržati samo slova" + Environment.NewLine + Environment.NewLine + "Dan:" + Environment.NewLine + "     " + "-Dan mora biti broj" + Environment.NewLine + Environment.NewLine + "Broj Telefona:" + Environment.NewLine + "     " + "Broj telefona se kuca kao 06########, i ima deset brojeva");
                    break;
                case 52:
                    MessageBox.Show("Dan: " + Environment.NewLine + "     " + " - Dan mora biti broj" + Environment.NewLine + Environment.NewLine + "Godina:" + Environment.NewLine + "     " + "-Godina mora imati 4 broja i biti manja od trenutne" + Environment.NewLine + "     " +
                        "Trenutan datum: " + DateTime.Now.Day + "." + DateTime.Now.Month + "." + DateTime.Now.Year + Environment.NewLine + Environment.NewLine + "Broj Telefona: " + Environment.NewLine + "     " + "Broj telefona se kuca kao 06########, i ima deset brojeva");
                    break;
                case 53:
                    MessageBox.Show("Ime: " + Environment.NewLine + "     " + "-Ime može sadržati samo slova" + Environment.NewLine + Environment.NewLine + "Dan: " + Environment.NewLine + "     " + " - Dan mora biti broj" + Environment.NewLine + Environment.NewLine + "Godina:" + Environment.NewLine + "     " + "-Godina mora imati 4 broja i biti manja od trenutne" + Environment.NewLine + "     " +
                        "Trenutan datum: " + DateTime.Now.Day + "." + DateTime.Now.Month + "." + DateTime.Now.Year + Environment.NewLine + Environment.NewLine + "Broj Telefona: " + Environment.NewLine + "     " + "Broj telefona se kuca kao 06########, i ima deset brojeva");
                    break;
                case 54:
                    MessageBox.Show("Prezime: " + Environment.NewLine + "     " + "-Prezime može sadržati samo slova" + Environment.NewLine + Environment.NewLine + "Dan: " + Environment.NewLine + "     " + " - Dan mora biti broj" + Environment.NewLine + Environment.NewLine + "Godina:" + Environment.NewLine + "     " + "-Godina mora imati 4 broja i biti manja od trenutne" + Environment.NewLine + "     " +
                        "Trenutan datum: " + DateTime.Now.Day + "." + DateTime.Now.Month + "." + DateTime.Now.Year + Environment.NewLine + Environment.NewLine + "Broj Telefona: " + Environment.NewLine + "     " + "Broj telefona se kuca kao 06########, i ima deset brojeva");
                    break;
                case 55:
                    MessageBox.Show("Ime i Prezime: " + Environment.NewLine + "     " + " - Ime i prezime mogu sadržati samo slova" + Environment.NewLine + Environment.NewLine + "Dan: " + Environment.NewLine + "     " + " - Dan mora biti broj" + Environment.NewLine + Environment.NewLine + "Godina:" + Environment.NewLine + "     " + "-Godina mora imati 4 broja i biti manja od trenutne" + Environment.NewLine + "     " +
                        "Trenutan datum: " + DateTime.Now.Day + "." + DateTime.Now.Month + "." + DateTime.Now.Year + Environment.NewLine + Environment.NewLine + "Broj Telefona: " + Environment.NewLine + "     " + "Broj telefona se kuca kao 06########, i ima deset brojeva");
                    break;
                case 56:
                    MessageBox.Show("Dan: " + Environment.NewLine + "     " + " - Dan mora biti broj" + Environment.NewLine + Environment.NewLine + "Mesec: " + Environment.NewLine + "     " + " - Mesec mora biti broj" + Environment.NewLine + Environment.NewLine + "Broj Telefona: " + Environment.NewLine + "     " + "Broj telefona se kuca kao 06########, i ima deset brojeva");
                    break;
                case 57:
                    MessageBox.Show("Ime: " + Environment.NewLine + "     " + "-Ime može sadržati samo slova" + Environment.NewLine + Environment.NewLine + "Dan: " + Environment.NewLine + "     " + " - Dan mora biti broj" + Environment.NewLine + Environment.NewLine + "Mesec: " + Environment.NewLine + "     " + " - Mesec mora biti broj" + Environment.NewLine + Environment.NewLine + "Broj Telefona: " + Environment.NewLine + "     " + "Broj telefona se kuca kao 06########, i ima deset brojev");
                    break;
                case 58:
                    MessageBox.Show("Prezime: " + Environment.NewLine + "     " + "-Prezime može sadržati samo slova" + Environment.NewLine + Environment.NewLine + "Dan: " + Environment.NewLine + "     " + " - Dan mora biti broj" + Environment.NewLine + Environment.NewLine + "Mesec: " + Environment.NewLine + "     " + " - Mesec mora biti broj" + Environment.NewLine + Environment.NewLine + "Broj Telefona: " + Environment.NewLine + "     " + "Broj telefona se kuca kao 06########, i ima deset brojeva");
                    break;
                case 59:
                    MessageBox.Show("Ime i Prezime: " + Environment.NewLine + "     " + " - Ime i prezime mogu sadržati samo slova" + Environment.NewLine + Environment.NewLine + "Dan: " + Environment.NewLine + "     " + " - Dan mora biti broj" + Environment.NewLine + Environment.NewLine + "Mesec: " + Environment.NewLine + "     " + " - Mesec mora biti broj" + Environment.NewLine + Environment.NewLine + "Broj Telefona: " + Environment.NewLine + "     " + "Broj telefona se kuca kao 06########, i ima deset brojeva");
                    break;
                case 60:
                    MessageBox.Show("Dan:" + Environment.NewLine + "     " + "-Dan mora biti broj" + Environment.NewLine + Environment.NewLine + "Mesec: " + Environment.NewLine + "     " + " - Mesec mora biti broj" + Environment.NewLine + Environment.NewLine + "Godina: " + Environment.NewLine + " - Godina mora imati 4 broja i biti manja od trenutne" + Environment.NewLine + "     " +
                        "Trenutan datum: " + DateTime.Now.Day + "." + DateTime.Now.Month + "." + DateTime.Now.Year + Environment.NewLine + Environment.NewLine + "Broj Telefona: " + Environment.NewLine + "     " + "Broj telefona se kuca kao 06########, i ima deset brojeva");
                    break;
                case 61:
                    MessageBox.Show("Ime: " + Environment.NewLine + "     " + "-Ime može sadržati samo slova" + Environment.NewLine + Environment.NewLine + "Dan:" + Environment.NewLine + "     " + "-Dan mora biti broj" + Environment.NewLine + Environment.NewLine + "Mesec: " + Environment.NewLine + "     " + " - Mesec mora biti broj" + Environment.NewLine + Environment.NewLine + "Godina: " + Environment.NewLine + " - Godina mora imati 4 broja i biti manja od trenutne" + Environment.NewLine + "     " +
                        "Trenutan datum: " + DateTime.Now.Day + "." + DateTime.Now.Month + "." + DateTime.Now.Year + Environment.NewLine + Environment.NewLine + "Broj Telefona: " + Environment.NewLine + "     " + "Broj telefona se kuca kao 06########, i ima deset brojeva");
                    break;
                case 62:
                    MessageBox.Show("Prezime: " + Environment.NewLine + "     " + "-Prezime može sadržati samo slova" + Environment.NewLine + Environment.NewLine + "Dan:" + Environment.NewLine + "     " + "-Dan mora biti broj" + Environment.NewLine + Environment.NewLine + "Mesec: " + Environment.NewLine + "     " + " - Mesec mora biti broj" + Environment.NewLine + Environment.NewLine + "Godina: " + Environment.NewLine + " - Godina mora imati 4 broja i biti manja od trenutne" + Environment.NewLine + "     " +
                        "Trenutan datum: " + DateTime.Now.Day + "." + DateTime.Now.Month + "." + DateTime.Now.Year + Environment.NewLine + Environment.NewLine + "Broj Telefona: " + Environment.NewLine + "     " + "Broj telefona se kuca kao 06########, i ima deset brojeva");
                    break;
                case 63:
                    MessageBox.Show("Ime i Prezime: " + Environment.NewLine + "     " + " - Ime i prezime mogu sadržati samo slova" + Environment.NewLine + Environment.NewLine + "Dan:" + Environment.NewLine + "     " + "-Dan mora biti broj" + Environment.NewLine + Environment.NewLine + "Mesec: " + Environment.NewLine + "     " + " - Mesec mora biti broj" + Environment.NewLine + Environment.NewLine + "Godina: " + Environment.NewLine + " - Godina mora imati 4 broja i biti manja od trenutne" + Environment.NewLine + "     " +
                        "Trenutan datum: " + DateTime.Now.Day + "." + DateTime.Now.Month + "." + DateTime.Now.Year + Environment.NewLine + Environment.NewLine + "Broj Telefona: " + Environment.NewLine + "     " + "Broj telefona se kuca kao 06########, i ima deset brojeva");
                    break;
            }
        }
    }
}

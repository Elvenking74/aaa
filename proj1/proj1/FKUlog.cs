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
    public partial class FKUlog : Form
    {
        List<KKupac> kupci = new List<KKupac>();
        int god1, mes1, dan1;
        Boolean godt;
        int mest;
        string loz;
        int pol;
        int brinc;
        string tel;
        DateTime dt;

        public delegate void posaljiK(KKupac kup);
        public posaljiK posalji;

        private void FKUlog_Load(object sender, EventArgs e)
        {
            if (File.Exists("Kupci"))
            {
                BinaryFormatter bf = new BinaryFormatter();
                FileStream fs = File.OpenRead("Kupci");
                kupci = bf.Deserialize(fs) as List<KKupac>;
                fs.Dispose();
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

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox3.Checked)
                txt21_2.PasswordChar = '\0';
            else
                txt21_2.PasswordChar = '*';
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {

        }

        public FKUlog()
        {
            InitializeComponent();
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
                            if (prov7 == 0)
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
                        fs1.Dispose();

                        int br = 0;

                        foreach (KKupac ku in kupci)
                        {
                            if (k.Kor_ime == ku.Kor_ime && k.Loz == ku.Loz)
                            {
                                break;
                            }
                            br++;
                        }
                       
                        MessageBox.Show("Uspesno ste se prijavili");
                        FKPocetna f = new FKPocetna();
                        Hide();
                        f.Location = this.Location;
                        this.posalji = new posaljiK(f.KKorisnik);
                        posalji(kupci[br]);
                        f.ShowDialog();

                        Show();
                        Close();


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

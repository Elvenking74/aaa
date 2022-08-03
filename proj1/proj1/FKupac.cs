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
    public partial class FKupac : Form
    {
        BinaryFormatter bf = new BinaryFormatter();
        List<KKupac> kupci;
        public delegate void posaljiK(KKupac kup);
        public posaljiK posalji;
        public FKupac()
        {
            InitializeComponent();
        }

        private void FKupac_Load(object sender, EventArgs e)
        {
            if (File.Exists("Kupci"))
            {
                FileStream fs = File.OpenRead("Kupci");
                kupci = bf.Deserialize(fs) as List<KKupac>;
                fs.Dispose();
            }
        }

        private void btn21_1_Click(object sender, EventArgs e)
        {
            FKUlog f = new FKUlog();
            Hide();
            f.Location = this.Location;
            f.ShowDialog();
            Show();
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox3.Checked)
                txt21_2.PasswordChar = '\0';
            else
                txt21_2.PasswordChar = '*';
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int prov = 2;
            int br = 0;

            if (File.Exists("Kupci"))
            {
                foreach (KKupac k in kupci)
                {
                    if (k.Kor_ime == txt21_1.Text)
                    {
                        prov = 1;
                        if (k.Loz == txt21_2.Text)
                        {
                            prov = 0;
                            break;
                        }
                    }
                    br++;
                }
            }

            if (prov == 0)
            {
                MessageBox.Show("Uspešno ste se ulogovali");
                FKPocetna f = new FKPocetna();
                Hide();
                f.Location = this.Location;
                this.posalji = new posaljiK(f.KKorisnik);
                posalji(kupci[br]);
                f.ShowDialog();
                
                Show();
                Close();
            }
            else
            {
                if (prov == 1)
                {
                    MessageBox.Show("Pogrešili ste lozinku, pokušajte ponovo");
                    txt21_2.Clear();
                    txt21_2.Focus();
                }


                if (prov == 2)
                {
                    MessageBox.Show("Korisničko ime ne postoji u listi korisnika");
                    txt21_1.Clear();
                    txt21_2.Clear();
                    txt21_1.Focus();
                }
                    
            }


        }
    }
}

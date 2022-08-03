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
    public partial class FKRUpdt : Form
    {
        int rez;
        int idRez;
        KKupac korisnik;
        BinaryFormatter bf = new BinaryFormatter();
        List<KProjekcija> proj;
        public FKRUpdt()
        {
            InitializeComponent();
        }

        private void FKRUpdt_Load(object sender, EventArgs e)
        {
            //----------Projekcije------------------------------------------
            if (File.Exists("Projekcije"))
            {
                FileStream fs = File.OpenRead("Projekcije");
                proj = bf.Deserialize(fs) as List<KProjekcija>;
                fs.Dispose();

                comboBox2.DataSource = proj;

                int i = Convert.ToInt32(numericUpDown1.Value);
                rez = i * proj[comboBox2.SelectedIndex].Cena;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FileStream fs = File.OpenRead("Rezervacije");
            List<KRezervacija> lst1;
            lst1 = bf.Deserialize(fs) as List<KRezervacija>;
            fs.Dispose();

            int br = 0;
            int kk = 0;
            for (int i = 0; i <= lst1.Count; i++)
            {
                if (lst1[i].Idk == korisnik.Id)
                {
                    if (br == idRez)
                    {
                        kk = i;
                        break;
                    }
                    else
                        br++;
                } 
            }

            lst1[kk].Idp = proj[comboBox2.SelectedIndex].Id;
            lst1[kk].Omest = Convert.ToInt32(numericUpDown1.Value);
            lst1[kk].Uc = Int32.Parse(textBox1.Text);

            FileStream fs1 = File.OpenWrite("Rezervacije");
            bf.Serialize(fs1, lst1);
            fs1.Dispose();

            Close();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            int i = Convert.ToInt32(numericUpDown1.Value);
            rez = i * proj[comboBox2.SelectedIndex].Cena;
            textBox1.Text = rez.ToString();
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            int i = Convert.ToInt32(numericUpDown1.Value);
            rez = i * proj[comboBox2.SelectedIndex].Cena;
            textBox1.Text = rez.ToString();
        }

        public void KKorisnik(KKupac k)
        {
            korisnik = k;
        }

        public void IDRez(int id)
        {
            idRez = id;
        }
    }
}

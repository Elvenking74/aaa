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
    public partial class FASala : Form
    {
        List<KSala> sale = new List<KSala>();
        int brincS;
        public FASala()
        {
            InitializeComponent();
        }

        private void FASala_Load(object sender, EventArgs e)
        {
            if (File.Exists("Sale"))
            {
                BinaryFormatter bf = new BinaryFormatter();
                FileStream fs = File.OpenRead("Sale");
                sale = bf.Deserialize(fs) as List<KSala>;
                fs.Dispose();
                listBox1.DataSource = sale;

            }
            if (File.Exists("brincS"))
            {
                FileStream fs = File.OpenRead("brincS");
                string str = File.ReadAllText("brincS");
                if (Int32.TryParse(str, out brincS))
                {

                }
                else
                {
                    brincS = 1;
                }
                fs.Dispose();
            }
            else brincS = 1;
        }

        private void btn4_1_Click(object sender, EventArgs e)
        {
            int prov1 = 0;
            int br_sale, br_sedista = 0;
            if (txt4_1.Text.Trim().Length != 0 && txt4_2.Text.Trim().Length != 0)
            {
                int prov2 = 0;
                if (Int32.TryParse(txt4_1.Text, out br_sale) && br_sale >= 0 && Int32.TryParse(txt4_2.Text, out br_sedista) && br_sedista > 0)
                {
                    KSala f = new KSala(brincS, br_sale, br_sedista);
                    brincS++;
                    File.WriteAllText("brincS", brincS.ToString());
                    sale.Add(f);

                    BinaryFormatter bf = new BinaryFormatter();
                    FileStream fs = File.OpenWrite("Sale");

                    bf.Serialize(fs, sale);

                    fs.Dispose();

                    List<KSala> lista;
                    FileStream fs1 = File.OpenRead("Sale");
                    lista = bf.Deserialize(fs1) as List<KSala>;
                    listBox1.DataSource = lista;
                    fs1.Dispose();
                    if(!checkBox1.Checked)
                        MessageBox.Show("Uspesno ste dodali salu");
                    if (cb4_1.Checked)
                    {
                        txt4_1.Clear();
                        txt4_2.Clear();
                    }
                }

                if (br_sale < 0)
                {
                    prov2 += 1;
                }
                if (br_sedista <= 0)
                {
                    prov2 += 2;
                }

                switch (prov2)
                {
                    case 1:
                        MessageBox.Show("Broj sale ne moze biti negativan");
                        break;
                    case 2:
                        MessageBox.Show("Broj sedišta u sali mora biti pozitivan broj");
                        break;
                    case 3:
                        MessageBox.Show("Broj sale i Broj sedista trebaju da budu pozitivni brojevi");
                        break;
                }


            }
            else
            {
                if (txt4_1.Text.Trim().Length == 0)
                    prov1 += 1;
                if (txt4_2.Text.Trim().Length == 0)
                    prov1 += 2;

                switch (prov1)
                {
                    case 1:
                        MessageBox.Show("Niste uneli broj sale");
                        break;
                    case 2:
                        MessageBox.Show("Niste uneli broj sedišta sale");
                        break;
                    case 3:
                        MessageBox.Show("Niste uneli nijedan podatak");
                        break;
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (sale.Count != 0)
            {
                List<KSala> lista;
                BinaryFormatter bf = new BinaryFormatter();
                FileStream fs = File.OpenRead("Sale");
                lista = bf.Deserialize(fs) as List<KSala>;
                lista.RemoveAt(listBox1.SelectedIndex);
                fs.Dispose();
                FileStream fs1 = File.OpenWrite("Sale");
                bf.Serialize(fs1, lista);
                sale = lista;
                listBox1.DataSource = sale;

                fs1.Dispose();

                if (!checkBox1.Checked)
                    MessageBox.Show("Uspesno ste obrisali salu");
            }
            else
                MessageBox.Show("Lista sala je prazna");
        }
        private void button2_Click(object sender, EventArgs e)
        {
            if (File.Exists("Sale") && sale.Count != 0)
            {
                List<KSala> lista;
                BinaryFormatter bf = new BinaryFormatter();
                FileStream fs = File.OpenRead("Sale");
                lista = bf.Deserialize(fs) as List<KSala>;

                KSala f1 = lista[listBox1.SelectedIndex];
                textBox2.Text = f1.Br_sale.ToString();
                textBox1.Text = f1.Br_sed.ToString();

                fs.Dispose();
            }
            else
            {
                MessageBox.Show("Lista sala je prazna");
            }

        }


        private void button3_Click(object sender, EventArgs e)
        {
            int ad = 0;
            if (File.Exists("Sale") && sale.Count != 0)
            {
                List<KSala> lista;
                BinaryFormatter bf = new BinaryFormatter();
                FileStream fs = File.OpenRead("Sale");
                lista = bf.Deserialize(fs) as List<KSala>;

                fs.Dispose();

                int a1, a2;
                Int32.TryParse(textBox2.Text, out a1);
                Int32.TryParse(textBox1.Text, out a2);

                KSala f1 = lista[listBox1.SelectedIndex];
                if (textBox2.Text.Trim().Length != 0)
                {
                    if (Int32.TryParse(textBox2.Text, out a1) && a1 >= 0)
                    {
                        f1.Br_sale = a1;
                    }
                    else
                    {
                        MessageBox.Show("Broj Sale ne može da dude negativan broj");
                        ad += 1;
                    }

                    
                    
                }
                if (textBox1.Text.Trim().Length != 0)
                {
                   if (Int32.TryParse(textBox1.Text, out a1) && a1 > 0)
                   {
                        f1.Br_sed = a1;
                   }
                   else
                    {
                        MessageBox.Show("Broj sedišta mora da bude pozitivan broj");
                        ad += 2;
                    }
                }
            
                lista[listBox1.SelectedIndex] = f1;

                if (ad == 0)
                {
                    FileStream fs1 = File.OpenWrite("Sale");
                    bf.Serialize(fs1, lista);
                    fs1.Dispose();
                    sale = lista;
                    listBox1.DataSource = sale;

                    textBox1.Clear();
                    textBox2.Clear();

                    if (!checkBox1.Checked)
                        MessageBox.Show("Sala Uspešno ažurirana");
                }
            }
            else
            {
                MessageBox.Show("Lista sala je prazna");
            }



            
        }

        private void FASala_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (sale.Count == 0)
            {
                File.Delete("Sale");
                File.Delete("brincS");
            }
        }
    }
}

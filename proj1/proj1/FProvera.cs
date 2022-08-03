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
    public partial class FProvera : Form
    {
        public FProvera()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (File.Exists("Filmovi"))
            {
                List<KFilm> lista;
                BinaryFormatter bf = new BinaryFormatter();
                FileStream fs = File.OpenRead("Filmovi");
                lista = bf.Deserialize(fs) as List<KFilm>;
                listBox1.DataSource = lista;
                fs.Dispose();
                if(listBox1.Items.Count == 0)
                    MessageBox.Show("Lista filmova je prazna");
            }
            else
            {
                MessageBox.Show("Lista filmova je prazna");
            }
            
        }

        private void FProvera_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (File.Exists("Sale"))
            {
                List<KSala> lista;
                BinaryFormatter bf = new BinaryFormatter();
                FileStream fs = File.OpenRead("Sale");
                lista = bf.Deserialize(fs) as List<KSala>;
                listBox1.DataSource = lista;
                fs.Dispose();
                if (listBox1.Items.Count == 0)
                    MessageBox.Show("Lista filmova je prazna");
            }
            else
            {
                MessageBox.Show("Lista sala je prazna");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (File.Exists("Kupci"))
            {
                List<KKupac> lista;
                BinaryFormatter bf = new BinaryFormatter();
                FileStream fs = File.OpenRead("Kupci");
                lista = bf.Deserialize(fs) as List<KKupac>;
                listBox1.DataSource = lista;
                fs.Dispose();
                if (listBox1.Items.Count == 0)
                    MessageBox.Show("Lista filmova je prazna");
            }
            else
            {
                MessageBox.Show("Lista kupaca je prazna");
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            
            if (File.Exists("Filmovi"))
            {
                if (listBox1.Items.Count != 0)
                {
                    List<KFilm> lista;
                    BinaryFormatter bf = new BinaryFormatter();
                    FileStream fs = File.OpenRead("Filmovi");
                    lista = bf.Deserialize(fs) as List<KFilm>;
                    lista.RemoveAt(listBox1.SelectedIndex);
                    listBox1.DataSource = lista;
                    fs.Dispose();
                    FileStream fs1 = File.OpenWrite("Filmovi");
                    bf.Serialize(fs1, lista);
                    fs1.Dispose();
                }
                else
                    MessageBox.Show("Lista filmova je prazna");
            }
            else
            {
                MessageBox.Show("Lista filmova je prazna");
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            
            if (File.Exists("Sale"))
            {
                if (listBox1.Items.Count != 0)
                {
                    List<KSala> lista = new List<KSala>();
                    BinaryFormatter bf = new BinaryFormatter();
                    FileStream fs = File.OpenRead("Sale");
                    lista = bf.Deserialize(fs) as List<KSala>;
                    lista.RemoveAt(listBox1.SelectedIndex);
                    listBox1.DataSource = lista;
                    fs.Dispose();
                    FileStream fs1 = File.OpenWrite("Sale");
                    bf.Serialize(fs1, lista);
                    fs1.Dispose();
                }
                else
                    MessageBox.Show("Lista sala je prazna");
            }
            else
            {
                MessageBox.Show("Lista sala je prazna");
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            
            if (File.Exists("Kupci"))
            {
                if (listBox1.Items.Count != 0)
                {
                    List<KKupac> lista = new List<KKupac>();
                    BinaryFormatter bf = new BinaryFormatter();
                    FileStream fs = File.OpenRead("Kupci");
                    lista = bf.Deserialize(fs) as List<KKupac>;
                    lista.RemoveAt(listBox1.SelectedIndex);
                    listBox1.DataSource = lista;
                    fs.Dispose();
                    FileStream fs1 = File.OpenWrite("Kupci");
                    bf.Serialize(fs1, lista);
                    fs1.Dispose();
                }
                else
                    MessageBox.Show("Lista kupaca je prazna");
            }
            else
            {
                MessageBox.Show("Lista kupaca je prazna");
            }
        }
    }
}

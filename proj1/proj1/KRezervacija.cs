using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;

namespace proj1
{
    [Serializable()]
    public class KRezervacija
    {
        private int idk, idp, omest, uc;
        private List<KProjekcija> proj = new List<KProjekcija>();
        private List<KRezervacija> rez = new List<KRezervacija>();
        private List<KKupac> kup = new List<KKupac>();



        public KRezervacija(int idk, int idp, int omest, int uc)
        {
            this.idk = idk;
            this.idp = idp;
            this.omest = omest;
            this.uc = uc;
        }

        public int Idk { get => idk; set => idk = value; }
        public int Idp { get => idp; set => idp = value; }
        public int Omest { get => omest; set => omest = value; }
        public int Uc { get => uc; set => uc = value; }

        public override string ToString()
        {
            BinaryFormatter bf = new BinaryFormatter();

            ////--------------Kupac---------------------------------------
            //if (File.Exists("Kupci"))
            //{
            //    FileStream fs = File.OpenRead("Kupci");
            //    kup = bf.Deserialize(fs) as List<KKupac>;
            //    fs.Dispose();
            //}

            ////--------------Indeks--------------------------------------
            //int j = 0;
            //foreach (KKupac k in kup)
            //{
            //    if (k.Id == this.idk)
            //        break;
            //    else
            //        j++;
            //}

            //--------------Projekcija----------------------------------
            if (File.Exists("Projekcije"))
            {
                FileStream fs1 = File.OpenRead("Projekcije");
                proj = bf.Deserialize(fs1) as List<KProjekcija>;
                fs1.Dispose();
            }

            //--------------indeks--------------------------------------

            int i = 0;
            foreach (KProjekcija p in proj)
            {
                if (p.Id == this.idp)
                    break;
                else
                    i++;
            }

            ////--------------Rezervacije---------------------------------
            //if (File.Exists("Rezervacije"))
            //{
            //    FileStream fs2 = File.OpenRead("Rezervacije");
            //    rez = bf.Deserialize(fs2) as List<KRezervacija>;
            //    fs2.Dispose();
            //}

            ////--------------indeks--------------------------------------

            //int j = proj[i].Sala.Br_sed;
            //foreach (KRezervacija p in rez)
            //{
            //    if (p.Idp == this.idp)
            //        j -= p.Omest;
            //}


            return "\'" + proj[i].Film.Naziv + "\'" + proj[i].Film.Duzina + " min, Sala " + proj[i].Sala.Br_sale + ", Datum i Vreme: " + proj[i].Datum.ToString("yyyy-MM-dd") + " " + proj[i].Vreme.ToString("t") + ", Broj Sedišta: " + Omest + ", Ukupna cena: " + Uc;
        }
    }
}

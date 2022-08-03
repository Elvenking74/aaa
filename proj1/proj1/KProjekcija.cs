using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;

namespace proj1
{
    [Serializable()]
    class KProjekcija
    {
        int id;
        DateTime datum;
        KSala sala;
        int cena;
        DateTime vreme;
        KFilm film;

        public KProjekcija(int id, DateTime datum, KSala sala, int cena, DateTime vreme, KFilm film)
        {
            this.id = id;
            this.datum = datum;
            this.sala = sala;
            this.cena = cena;
            this.vreme = vreme;
            this.film = film;
        }

        public int Id { get => id; set => id = value; }
        public DateTime Datum { get => datum; set => datum = value; }
        public int Cena { get => cena; set => cena = value; }
        public DateTime Vreme { get => vreme; set => vreme = value; }
        internal KSala Sala { get => sala; set => sala = value; }
        internal KFilm Film { get => film; set => film = value; }

        public override string ToString()
        {
            BinaryFormatter bf = new BinaryFormatter();
            List<KRezervacija> rez = new List<KRezervacija>();
            //--------------Rezervacije---------------------------------
            if (File.Exists("Rezervacije"))
            {
                FileStream fs2 = File.OpenRead("Rezervacije");
                rez = bf.Deserialize(fs2) as List<KRezervacija>;
                fs2.Dispose();
            }

            //--------------indeks--------------------------------------
            int j = sala.Br_sed;
            foreach (KRezervacija p in rez)
            {
                if (p.Idp == this.id)
                    j -= p.Omest;
            }

            return "\"" + film.Naziv + "\"" + film.Duzina + " Min, Cena Karte: " + cena + ",00 RSD, Datum i Vreme: " + datum.ToString("yyyy-MM-dd") + ".-" + vreme.ToString("t") + ", Sala " + sala.Br_sale + " ,Broj dostupnih sedišta: " + j;
        }
    }
}

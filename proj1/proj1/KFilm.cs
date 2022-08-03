using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace proj1
{
    [Serializable()]
    class KFilm
    {
        private int id;
        private int granica, duzina;
        private string naziv, zanr;

        public KFilm(string naziv, string zanr, int duzina, int granica)
        {
            this.granica = granica;
            this.duzina = duzina;
            this.naziv = naziv;
            this.zanr = zanr;
        }

        public KFilm(int id, string naziv, string zanr, int duzina, int granica)
        {
            this.id = id;
            this.granica = granica;
            this.duzina = duzina;
            this.naziv = naziv;
            this.zanr = zanr;
        }

        public int Id { get => id; set => id = value; }
        public int Granica { get => granica; set => granica = value; }
        public int Duzina { get => duzina; set => duzina = value; }
        public string Naziv { get => naziv; set => naziv = value; }
        public string Zanr { get => zanr; set => zanr = value; }

        public override string ToString()
        {
            return naziv + ", " + duzina + " min";
        }


    }
}

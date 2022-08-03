using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace proj1
{
    [Serializable()]
    public class KKorisnik
    {
        private int id;
        private string prezime;
        private DateTime dat_rodj;
        private string br_tel;
        private string ime;
        private int pol;

        public int Id { get => id; set => id = value; }
        public string Prezime { get => prezime; set => prezime = value; }
        public DateTime Dat_rodj { get => dat_rodj; set => dat_rodj = value; }
        public string Br_tel { get => br_tel; set => br_tel = value; }
        public string Ime { get => ime; set => ime = value; }
        public int Pol { get => pol; set => pol = value; }

        public KKorisnik(int id, string ime, string prezime, DateTime dat_rodj, string br_tel)
        {
            this.id = id;
            this.br_tel = br_tel;
            this.ime = ime;
            this.prezime = prezime;
            this.dat_rodj = dat_rodj;
        }


    }
}

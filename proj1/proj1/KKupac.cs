using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace proj1
{
    [Serializable()]
    public class KKupac : KKorisnik
    {
        string loz;
        string kor_ime;
        public KKupac(int id, string ime, string prezime, DateTime dat_rodj, string br_tel, string loz, string kor_ime, int pol) : base(id, ime, prezime, dat_rodj, br_tel)
        {
            this.Id = id;
            this.Ime = ime;
            this.Prezime = prezime;
            this.Dat_rodj = dat_rodj;
            this.Br_tel = br_tel;
            this.loz = loz;
            this.kor_ime = kor_ime;
            this.Pol = pol;
        }

        public string Loz { get => loz; set => loz = value; }
        public string Kor_ime { get => kor_ime; set => kor_ime = value; }
        

        public override string ToString()
        {
            return Ime + " " + Prezime;
        }


    }
}

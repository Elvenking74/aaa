using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace proj1
{
    [Serializable()]
    class KSala
    {
        private int id, br_sale, br_sed;

        public KSala(int id, int br_sale, int br_sed)
        {
            this.id = id;
            this.br_sale = br_sale;
            this.br_sed = br_sed;
        }

        public int Id { get => id; set => id = value; }
        public int Br_sale { get => br_sale; set => br_sale = value; }
        public int Br_sed { get => br_sed; set => br_sed = value; }

        public override string ToString()
        {
            return "Sala " + br_sale;
        }


    }
}

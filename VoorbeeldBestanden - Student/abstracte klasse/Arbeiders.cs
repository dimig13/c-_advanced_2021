using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace abstracte_klasse
{
    public class Arbeiders : medewerker
    {
        private double rsz, belastbaar, bruto, bv;

        public Arbeiders(string firstName, string familyName, double hourlyWage, double hours) : 
            base(firstName, familyName,hourlyWage,hours)
        {
            bruto = Bruto();
        }

        public override double BV()
        {
            belastbaar = bruto - RSZ();

            if (belastbaar <= 50000)
            {
                bv = belastbaar * 0.45f;
            }
            else
            {
                bv = (bruto - 50000) * 0.5f + (50000 * 0.45f);
            }
            return bv;
        }

        public override double Netto() => belastbaar - bv;
        public override double RSZ()
        {
            rsz = bruto * 1.08 * 0.1307;
            return rsz;
        }
    }
}

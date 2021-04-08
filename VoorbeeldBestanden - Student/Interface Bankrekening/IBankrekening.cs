using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interface_Bankrekening
{
    public interface IBankrekening
    {
        //Eigenschappen.
        double Saldo { get; }
        string Naam { get; set; }
        string Rekeningnummer { get; }

        //Methodes.
        void Storting(double bedrag);
        void Opname(double bedrag);

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Interface_Bankrekening
{
    public class Bankrekening : IBankrekening
    {
        private string naam;

        //constructor.
        public Bankrekening(string nummer, string naam)
        {
            Saldo = 0;
            Rekeningnummer = nummer;
            this.naam = naam;
        }

        //Methodes.
        public void Storting(double waarde)
        {
            if(waarde > 2500)
            {
                throw new BankException($"{naam}\r\n\r\nStorting op {Rekeningnummer}\r\nKan maximaal 2500 bedragen!");
            }
            Saldo += waarde;
        }

        public void Opname(double waarde)
        {
            if(Saldo - waarde < 0)
            {
                throw new BankException($"{naam}\r\n\r\nJe saldo is ontoereikend\r\nHuidig saldo: {Saldo:c}");
            }
            Saldo -= waarde;
        }

        //property.
        public double Saldo { get; private set; }
        public string Rekeningnummer { get; }
        double IBankrekening.Saldo => Saldo;
        string IBankrekening.Naam { get; set; }
    }
}

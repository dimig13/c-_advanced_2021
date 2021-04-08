using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace toep17AbstracteKLasse
{
    public abstract class Bankrekening
    {
        // protected is binnen de klasse en afgeleide klasse beschikbaar
        protected double saldo;
        // Contructor
        public Bankrekening(double opening, string name, string address)
        {
            saldo = opening;
            Naam = name;
            Adres = address;
        }
        // ==== Eigenschap ====
        public double HuidigSaldo => saldo; // enkel get
        public string Naam { get; set; }
        public string Adres { get; set; }

        // ==== Methodes ====
        public void DebetSaldo(int value)
        {
            saldo += value;
        }
        public virtual void CreditSaldo(int value)
        {
            saldo -= value;
        }
        public abstract double BerekenRente();
    }
}

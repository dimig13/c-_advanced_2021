using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace abstracte_klasse
{
    public abstract class medewerker
    {
        private double bruto;

        //De klasse werknemer is een abstracte klasse.
        public string Voornaam { get; set; }
        public string Naam { get; set; }
        public double Uurloon { get; set; }

        public double UrenGewerkt { get; set; }

        public double Bruto() => bruto;

        //Constructor.

        public medewerker(string firstName, string familyName, double salary)
        {
            Voornaam = firstName;
            Naam = familyName;
            bruto = salary;
        }

        public medewerker(string firstName, string familyName, double hourlyWage, double hours)
        {
            Voornaam = firstName;
            Naam = familyName;
            bruto = hourlyWage * hours;
        }

        //abstracte methode.
        public abstract double RSZ();
        public abstract double BV();
        public abstract double Netto();
    }
}

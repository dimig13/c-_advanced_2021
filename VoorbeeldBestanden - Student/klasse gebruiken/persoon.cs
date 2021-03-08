using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace klasse_gebruiken
{
    class persoon
    {
        public string Naam { get; set; }

        public string Voornaam { get; set; }


        public string ToonNaam() => $"Persoon = {Voornaam} {Naam.ToUpper()}";

        public persoon()
        {
            Naam = "onbekend";
        }

        public persoon(string firstname, string name)
        {
            Naam = name;
            Voornaam = firstname;
        }

       

    }
}

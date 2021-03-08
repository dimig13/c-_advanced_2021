using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace klasse_gebruiken
{
    public class Gebruiker
    {
        private string familienaam;


        public string Voornaam { get; set; }

        //nieuwe manier 
        public string Naam
        {
            get
            {
                return familienaam;
            }
            set
            {
                familienaam = value.Trim();
            }
        }

        //oude manier.

        public string Gegevens
        {
            get
            {
                return $"{Voornaam} {Naam.ToUpper()}";
            }
        }



        //Functie method TOONNAAM.
        public string ToonNaam()
        {
            return $"Lector {Voornaam} {Naam.ToUpper()}";
        }

        //constructor zonder parameters.

        public Gebruiker()
        {

        }

        //constructor met parameters.
        public Gebruiker(string name, string famillyname)
        {
            familienaam = famillyname;
            Voornaam = name;
        }

       
    }
}

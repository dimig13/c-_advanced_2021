using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Klassepersoneel
{
    class personeel
    {

        public string Geslacht { get; set; }

        public string Naam { get; set; } 
        public int Startjaar { get; set; }

        public string Voornaam { get; set; }

        // === READ AND WRITE PROPERTY ==== PROPFULL.

        private int cijfer;
        public int Beoordelingscijfer
        {
            get //geeft terug
            {
                if (cijfer < 0) { return 0; }
                else if (cijfer> 10) { return 10; }
                else { return cijfer; }
            }
            set { cijfer = value; } // ontvangt 
        }

        // read-only eigenschappen.
        public int Dienstjaren => DateTime.Today.Year - Startjaar;
        public string GeslachtTekst => (Geslacht == "V") ? "Vrouwelijk" : "Mannelijk";
        public float Premie => BerekenPremie();
        private float BerekenPremie()
        {
            float premie = 500 + (20 * Dienstjaren);
            if (Beoordelingscijfer<5 ) { premie /= 2; }
            else if ( Beoordelingscijfer == 7 ||Beoordelingscijfer == 8) { premie *= 1.5f; }
            else if( Beoordelingscijfer == 9 || Beoordelingscijfer == 10 ) { premie *= 2f; }
            return premie;
        }

        public void VerhoogBeoordeling()
        {
            Beoordelingscijfer++;
        }

        public void VerlaagBeoordeling()
        {
            Beoordelingscijfer--;
        }

        public string ToonInfo()
        {
            return $"Personeelslid {Voornaam} {Naam}" +
                $"\n Geslacht          : {GeslachtTekst}" +
                $"\nAantal dienstjaren : {Dienstjaren}" +
                $"\nBeoordelingscijfer : {Beoordelingscijfer}" +
                $"\nPremie: {Premie:c}";
        }

        public personeel()
        {
            Startjaar = DateTime.Today.Year;
            Geslacht = "V";
        }

        public personeel(string familyname, string firstname, string gender, int rated, int startingyear) 
        {
            Naam = familyname;
            Voornaam = firstname;
            Geslacht = gender;
            Beoordelingscijfer = rated;
            Startjaar = startingyear;
        }
    }
}

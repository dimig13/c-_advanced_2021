using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfacebegin
{
    public class Persoon : IOuderdom
    {
        //Instantievariabelen.
        private int geboortejaar;
        private string voornaam;
        private string naam;

        //constructor.
        public Persoon(string firstName, string familyName, int 
            yearofBirth)
        {
            voornaam = firstName;
            naam = familyName;
            geboortejaar = yearofBirth;
        }

        //Property ouderdom - implementatie van interface
        public int Ouderdom => DateTime.Now.Year - geboortejaar;

        public string Naam => voornaam + " " + naam;
    }
}

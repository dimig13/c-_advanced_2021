using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace klasse_gebruiken
{
    class verjaardag
    {
        private int maand;

        public int AantalCadeaus { get; set; }

        public bool IsFeest { get; set; }

        private string boodschap; 

        public string Mijnboodschap
        {
            get { return boodschap; }
            set { boodschap = GeeftBericht(value); }
        }

        private string GeeftBericht(string persoon)
        {
            string bericht;
            
            if (IsFeest)
            {
                bericht = $"Gelukkige verjaardag! { persoon}" +
                    $"\nAantal cadeaus = {AantalCadeaus}" +
                    $"\nGeniet van het verjaardagsfeestje!";
            }
            else
            {
                bericht = $"Jammer, {persoon} geen verjaardagsfeest!";
            }

            return bericht;
        }

        public verjaardag()
        {
        //    AantalCadeaus = 1;
        }

        public verjaardag(string name, DateTime birthday)
        {
            maand = birthday.Month;
            AantalCadeaus = 5;
            if (maand == DateTime.Today.Month) IsFeest = true;
            Mijnboodschap = name;
        }
    }
}

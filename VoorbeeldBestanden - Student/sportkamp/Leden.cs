using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sportkamp
{
    public class Leden
    {
        private int kampnr;

        private static string[,] kampen = sportkampen.InlezenKamp();

        public string Naam { get; set; }
        public string Voornaam { get; set; }
        public int Weeknr { get; set; }
        public int Kampvolgnr { get; set; }


        private string kampcode;

        public string Kampcode
        {
            get
            {
                return kampcode;
            }
            set
            {
                kampcode = value;
                for (int i = 0; i <= kampen.GetUpperBound(0); i++)
                {
                    if (kampcode == kampen[i, 0]) kampnr = i;
                }
            }
        }

        // EIGENSCHAPPEN READ-ONLY.

        public string NaamVolledig => $"{Voornaam} {Naam}";
        public string SportNaam => kampen[kampnr, 1];

        public float Kampprijs => float.Parse(kampen[kampnr, 2]);

        public float TeBetalen
        {
            get
            {
                if (kampnr >= 5)
                {
                    return Kampprijs * 0.9f;
                }
                else if (kampnr >= 2)
                {
                    return Kampprijs * 0.2f;
                }
                else return Kampprijs;
            }
        }

        //METHODS
        public string InformatieVolledig() => $"{NaamVolledig,-25}{SportNaam,-15}" +
            $"{Kampprijs:c} - {Kampvolgnr} - {TeBetalen:c}";

        //Gebruikt bij wegschrijven naar tekstbestand.
        public string RecordVorm() => $"{Naam,-30}{Voornaam,-30}" +
            $"{Weeknr}{kampcode}{Kampvolgnr}";


    }
}

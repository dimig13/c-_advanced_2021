using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Threading.Tasks;

namespace voorbeeldovererving
{
   public class Persoon
    {
        public string Voornaam { get; set; }
        public string Naam { get; set; }
        public string Postcode { get; set; }
        public string Straat { get; set; }
        public DateTime Geboortedatum { get; set; }
        public string Email { get; set; }
        // Read­only eigenschap
        public virtual string Gegevens => $"{VolledigeNaam()}\r\nGeboortedatum: {Geboortedatum.ToLongDateString()}";
              // void method
        public virtual void Info(string tekst)
          {
             tekst = $"Naam: {Voornaam} {Naam}\r\nAdres: {Straat} {Postcode}\r\nGeboortedatum: { Geboortedatum.ToLongDateString()}" +
                $"\r\nE­mail: { Email} ";
         
            string info = $"Uw persoonlijke gegevens: \r\n\r\n";
            MessageBox.Show(info + tekst, "Info Klasse Persoon",
             MessageBoxButton.OK, MessageBoxImage.Information);
          }
        public virtual string VolledigeNaam() => Voornaam + " " + Naam;
        public Persoon()
          {
             Voornaam = "Patricia";
             Naam = "Briers";
             Straat = "Elfde­Liniestraat 26";
             Postcode = "3500";
            Geboortedatum = DateTime.Parse("3/10/1988");
          }

        // public virtual string VolledigeNaam()
        //{
        // return Voornaam + " " + Naam;
        //}
        // Virtual geeft aan dat de eigenschap in de afgeleide klasse overschreven kan worden.
        //public virtual string Gegevens
        //{
        // get
        // {
        // return Voornaam + " " + Naam + "\r\n" + "Geboortedatum: " + Geboortedatum.ToLongDateString();
        // }
        //}
    }
}

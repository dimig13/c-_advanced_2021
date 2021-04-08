using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace voorbeeldovererving
{
    public static class Bestandsbewerking
    {
        public static List<Student> LeesStudenten()
        {
            string pad = @"..\..\Studenten (1).csv";
            // List van studenten
            List<Student> StudieLijst = new List<Student>();

            string[] rij;

            //Instantie van klasse aanmaken.
            Student std;

            // als de map niet bestaat, wordt het aangemaakt.
            if (File.Exists(pad))
            {
                using (StreamReader sr = new StreamReader(pad))
                {
                    while (!sr.EndOfStream)
                    {
                        rij = sr.ReadLine().Split(';');

                        //Instantie van klasse student.
                        std = new Student();
                        std.Naam = rij[0].Trim();
                        std.Voornaam = rij[1].Trim();
                        std.Straat = rij[2].Trim();
                        std.Postcode = rij[3].Trim();
                        std.Betaald =Convert.ToChar(rij[4]);
                        std.Opleiding = rij[5].Trim();
                        std.TypeStudent= rij[6].Trim();

                        if(Equals(std.TypeStudent, "I"))
                        {
                            std.Studiepunten = int.Parse(rij[7]);
                        }

                        //toevoegen aan de list van objecten.
                        StudieLijst.Add(std);

                    }
                }
            }
            return StudieLijst;
        }

        public static List<Lector> LeesLectoren()
        {
            string pad = @"..\..\Lectoren.csv";

            List<Lector> lectlijst = new List<Lector>();

            string[] rij;

            //Instantie van klasse aanmaken.
            Lector lectr;

            if (File.Exists(pad))
            {
                using(StreamReader sr= new StreamReader(pad))
                {
                    while (!sr.EndOfStream)
                    {
                        rij = sr.ReadLine().Split(';');

                        lectr = new Lector();
                        lectr.Naam = rij[0].Trim();
                        lectr.Voornaam= rij[1].Trim();
                        lectr.Geboortedatum = Convert.ToDateTime(rij[2].Trim());
                        lectr.Straat = rij[3].Trim();
                        lectr.Postcode = rij[4].Trim();
                        lectr.Statuut = rij[5].Trim();
                        lectr.Afdeling = rij[6].Trim();
                        lectr.Indienst = Convert.ToDateTime(rij[7].Trim());

                        lectlijst.Add(lectr);
                    }
                }
            }
            return lectlijst;
        }
    }
}

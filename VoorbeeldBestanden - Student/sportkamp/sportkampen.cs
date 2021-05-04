using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows;

namespace sportkamp
{
    public class sportkampen
    {
        
        public static string[,] InlezenKamp()
        {
           
            //string pad = System.IO.Path.GetFullPath(@"..\..\Tekstbestanden");
            //string bestand = System.IO.Path.Combine(pad, "Sporten.txt");

            string bestand = @"..\..\Tekstbestanden\Sporten.txt";

            int aantal = File.ReadAllLines(bestand).Length;

            string[,] spkamp = new string[aantal, 3];
            string[] velden;
            int i = 0;


            if (File.Exists(bestand))
            {
                using(StreamReader sr = new StreamReader(bestand))
                {
                    while (!sr.EndOfStream)
                    {
                        velden = sr.ReadLine().Split(';');
                        spkamp[i, 0] = velden[0].Replace("\"", "");
                        spkamp[i, 1] = velden[1].Replace("\"", "");
                        spkamp[i, 2] = velden[2].Replace("\"", "");
                        i++;
                    }
                }
            }
            else
            {
                MessageBox.Show("Kan bestand Sporten.txt niet vinden", "Foutmelding");
            }
            return spkamp;

        }

    }
}

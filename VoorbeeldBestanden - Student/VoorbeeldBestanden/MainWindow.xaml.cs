using System;
using System.IO;
using System.Windows;

namespace VoorbeeldBestanden
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void BtnStreamWiterReader_Click(object sender, RoutedEventArgs e)
        {
            // schrijven//
            string pad = @"..\..\Bestanden\Testbestand.txt";
            StreamWriter sw = new StreamWriter(pad);

            //Naar tekstbestand schrijven.
            sw.WriteLine("Volgorde van getallen: ");
            for (int i = 1; i <= 10; i++)
            {
                sw.Write($"{i * 100} -");
            }

            sw.WriteLine();
            sw.Write("Einde");

            //sluiten van bestand.
            sw.Close();

            //=== Lezen ===
            StreamReader sr = new StreamReader(pad);

            // inlezen van bestand per record.
            while (!sr.EndOfStream)
            {
                TxtResultaat.Text += $"{sr.ReadLine()}\n";
            }

            //Volledig bestand inlezen.
            //TxtResultaat.Text = sr.ReadToEnd();

            sr.Close();
        }

        private void BtnFileStream_Click(object sender, RoutedEventArgs e)
        {
            // pad instellen.
            string pad = @"..\..\Bestanden\klas.txt";

            TxtResultaat.Clear();

            // === USING- statement === 
            using (FileStream fs = new FileStream(pad, FileMode.Open, FileAccess.Read))
            {
                using (StreamReader sr = new StreamReader(fs))
                {
                    //bestand lezen naar Textbox.
                    TxtResultaat.Text = sr.ReadToEnd();
                }
            }


        }

        private void BtnFileStreamWriter_Click(object sender, RoutedEventArgs e)
        {
            //Pad instellen.
            string schijfpad = @"..\..\Bestanden\klaswrite.txt";
            string leespad = @"..\..\Bestanden\klas.txt";

            //Tekstbestand schrijven vanuit tekstbestand. 
            using (FileStream fs = new FileStream(schijfpad, FileMode.Create, FileAccess.Write))
            {
                using (StreamWriter sw = new StreamWriter(fs))
                {
                    using (StreamReader sr = new StreamReader(leespad))
                    {
                        string naam = string.Empty;

                        //            schrijven en lezen per regel.
                                        while (!sr.EndOfStream)
                                    {
                                        naam = sr.ReadLine();

                                        LbxNamen.Items.Add(naam);
                                    }

                                }
                            }
                        }

                    }

        private void BtnKlasseFile_Click(object sender, RoutedEventArgs e)
        {
            string pad = @"..\..\Bestanden\vakken.txt";
            TxtResultaat.Clear();

            if (!File.Exists(pad))
            {
                using (StreamWriter sw = File.CreateText(pad))
                {
                    sw.WriteLine("Programmeren - Lector: p.Briers | K.Palmaers");
                    sw.WriteLine("web - Lector: p.Briers | p.Janssen");
                    sw.WriteLine("it- organisation - Lector: p.Briers | K.Palmaers");
                }
            }

            // (1) === Dadelijk inlezen ===.
            TxtResultaat.Text = File.ReadAllText(pad);

            //// (2)Opent het bestand om te lezen. 
            //using(StreamReader sr = File.OpenText(pad))
            //{
            //    string s = string.Empty;
            //    while(!sr.EndOfStream)
            //    {
            //        TxtResultaat.AppendText($"{sr.ReadLine()}\n");
            //    }
            //}

            //// (3)=== OF dadelijk in array inlezen === 
            //string[] gegevens = File.ReadAllLines(pad);
            //TxtResultaat.Text = string.Join("\n", gegevens);

            //foreach(string item in gegevens)
            //{
            //    LbxNamen.Items.Add(item);
            //}

        }

        private void BtnWriteAllText_Click(object sender, RoutedEventArgs e)
        {
            string pad = @"..\..\Bestanden\TestNamenfile.txt";

            if (!File.Exists(pad))
            {
                using (StreamWriter sw = new StreamWriter(pad))
                {
                    sw.WriteLine("Klas: 1PRO A+B - dagopleiding ");
                    sw.WriteLine("Klas: 1PRO C+D - dagopleiding ");
                    sw.WriteLine("Klas: 1PRO E+F - dagopleiding ");
                    sw.WriteLine("Klas: 1PRO G+H - dagopleiding ");
                    sw.WriteLine("Klas: 1PRW A+B - avondopleiding");
                }



                // of je gebruikt dit en dan heb je geen streamwriter nodig.
                //string lijn = $"OPLEIDINGSONDERDEEL: C# ADVANCED \n";
                //File.WriteAllText(pad, lijn);

                //// vermits je met file maar 1x een writealltext kan gebruiken moet je de daaropvol

                //File.AppendAllText(pad, "Klas: 1PRO A+B - dagopleiding  \n");
                //File.AppendAllText(pad, "Klas: 1PRO C+D - dagopleiding  \n");
                //File.AppendAllText(pad, "Klas: 1PRO E+F - dagopleiding  \n");
                //File.AppendAllText(pad, "Klas: 1PRO G+H - dagopleiding  \n");
                //File.AppendAllText(pad, "\n");
                //File.AppendAllText(pad, "Klas: 1PRW A+B - avondopleiding  \n");
            }

            //Bestand openen.
            TxtResultaat.Clear();
            TxtResultaat.Text = File.ReadAllText(pad);
        }

        private void BtnWriteCsv_Click(object sender, RoutedEventArgs e)
        {
            string[] velden;
            TxtResultaat.Clear();

            using (StreamReader sr = new StreamReader(@"..\..\Bestanden\klasCsv.txt"))
            {
                while (!sr.EndOfStream)
                {
                    velden = sr.ReadLine().Split(';');
                    TxtResultaat.Text += $"Naam: {velden[0],-15} Voornaam:{velden[1]}\n";
                }
            }
        }

        private void BtnFixRead_Click(object sender, RoutedEventArgs e)
        {
            TxtResultaat.Clear();


            using (StreamReader sr = new StreamReader(@"..\..\Bestanden\klasVast.txt"))
            {
                while (!sr.EndOfStream)
                {
                    string lijn = sr.ReadLine();
                    string veld1 = lijn.Substring(0, 19).Trim();
                    string veld2 = lijn.Substring(20, 9).Trim();

                    TxtResultaat.Text += $"{veld1} {veld2}\n";

                }



            }
        }
    }
}

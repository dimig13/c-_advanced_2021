using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;

namespace sportkamp
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

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //declaratie bd klasse leden.
            Leden leden = new Leden();

            string[] code = { "ATL", "VOE", "ZWE", "KAY", "TEN", "PAA", "VOL" };
            float[,] overzichtWeek = new float[10, 2];
            float[,] overzichtSport = new float[7, 2];

            StringBuilder sbDetail = new StringBuilder();
            StringBuilder sbOverzichtWeek = new StringBuilder();
            StringBuilder sbOverzichtSport = new StringBuilder();

            string bestand = @"..\..\Tekstbestanden\LedenSportkampen.txt";



            if (File.Exists(bestand))
            {
                using (StreamReader sr = new StreamReader(bestand))
                {
                    while (!sr.EndOfStream)
                    {
                        string lijn = sr.ReadLine();

                        leden.Naam = lijn.Substring(0, 29).Trim();
                        leden.Voornaam = lijn.Substring(30, 29).Trim();
                        leden.Weeknr = int.Parse(lijn.Substring(60, 1));
                        leden.Kampcode = lijn.Substring(61,3);
                        leden.Kampvolgnr = int.Parse(lijn.Substring(64,1));

                        sbDetail.Append(leden.InformatieVolledig()).AppendLine();

                        //OVERZICHT PER week berekenen.
                        overzichtWeek[leden.Weeknr, 0]++;
                        overzichtWeek[leden.Weeknr, 1] += leden.TeBetalen;

                        //OVERZICHT PER SPORTTAK.
                        for(int i =0;i <= code.GetUpperBound(0); i++)
                        {
                            if(leden.Kampcode == code[i])
                            {
                                overzichtSport[i, 0]++;
                                overzichtSport[i, 1] += leden.TeBetalen;
                            }
                        }
                       
                    }
                }
                // AFDRUK txtOverzichtweek .
                TxtDetails.Text = sbOverzichtWeek.ToString();

                // AFDRUK txtoverzichtSport.
                sbOverzichtSport.Append("Overzicht per sporttak \n");

                for (int i = 0; i <= overzichtSport.GetUpperBound(0); i++)
                {
                    leden.Kampcode = code[i].ToString();
                    sbOverzichtSport.Append($"{leden.SportNaam,-11} - {overzichtSport[i, 0]}" +
                        $"inschrijvingen: {overzichtSport[i, 1]:c}").AppendLine();
                }

                TxtOverzichtSporttak.Text = sbOverzichtSport.ToString();
            }
            else
            {
                MessageBox.Show("Bestand Ledensportkamp is niet beschikbaar en er " +
                    "kunnen geen gegevens ingelezen worden.", "foutmelding");
            }

           
        } 

    }
}

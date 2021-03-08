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
using Microsoft.Win32;
using System.Windows.Threading;


namespace Zonnepanelen
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
        private Random rnd = new Random();
        private int vorigekleur= 0;
        private void MnuDetails_Click(object sender, RoutedEventArgs e)
        {
            string bestand = @"..\..\Bestanden\zonnepanelen.txt";
            if (File.Exists(bestand))
            {
                using (StreamReader sr = File.OpenText(bestand))
                {
                    TxtResultaat.Text = sr.ReadToEnd();
                }
            }
            else
            {
                MessageBox.Show("kan bestand niet vinden.", "Onverwachte fout",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void MnuSamenvatting_Click(object sender, RoutedEventArgs e)
        {
            float[,] metingen = new float[13, 2];
            int aantalmetingen = 0;
            float totproductie = 0;
            List<string> maanden = new List<string>() { "Januari", "Februari", "Maart", "April", "Mei", "Juni", "Juli", "Augustus", "September", "Oktober", "November", "December" };
            try
            {
                string bestand = @"..\..\Bestanden\zonnepanelen.txt";
                using(StreamReader sr = File.OpenText(bestand))
                {
                    string[] velden = new string[2];
                    while (!sr.EndOfStream)
                    {
                        //scheidingsteken opgeven.
                        velden = sr.ReadLine().Split('-');

                        //-- verwerken bestand ---
                        int maandIndex = int.Parse(velden[0].Substring(3, 2));
                        metingen[maandIndex, 0] ++;
                        metingen[maandIndex, 1] += float.Parse(velden[1]);
                        aantalmetingen++;
                    }

                }
                // --afdruk 
                StringBuilder sb = new StringBuilder();
                sb.Append("samenvatting van de metingen: \n\n");

                for(int i= 1; i<= metingen.GetUpperBound(0); i++)
                {
                    totproductie += metingen[i, 1];
                    sb.Append($"{maanden[i - 1],-14} - {metingen[i, 0],5} metingen " +
                        $"- Gemiddelde productie per dag: {metingen[i, 1] / metingen[i, 0],6:n2}\n");
                }
                totproductie /= aantalmetingen;
                sb.Append($"\n {"Algemeen",-14} - {aantalmetingen,5} metingen  "
                    + $"- Gemiddelde productie per dag: {totproductie,6:n2}");

                TxtResultaat.Text = sb.ToString();

            }
            catch(FileNotFoundException ex)
            {
                MessageBox.Show("Geef een nieuwe naam!\n\n" + ex.Message, "Foutmelding",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            catch (Exception)
            {
                MessageBox.Show("Kan bestand niet vinden.", "Onverwachte fout",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void MnuDatum_Click(object sender, RoutedEventArgs e)
        {
            if(MnuDatum.IsChecked == true)
            {
                TextBlockDateTime.Visibility = Visibility.Visible;
            }
            else
            {
                TextBlockDateTime.Visibility = Visibility.Hidden;
            }
        }

        private void MnuAchtergrond_Click(object sender, RoutedEventArgs e)
        {
            int kleur = rnd.Next(1, 6);
            // voorkomen dat dezelfde kleur opnieuw gekozen wordt.
            while(kleur == vorigekleur)
            {
                kleur = rnd.Next(1, 6);
            }
            vorigekleur = kleur;

            switch (kleur)
            {
                case 1:
                    Background = Brushes.Gold;
                    break;
                case 2:
                    Background = Brushes.Red;
                    break;
                case 3:
                    Background = Brushes.Silver;
                    break;
                case 4:
                    Background = Brushes.Yellow;
                    break;
                case 5:
                    Background = Brushes.MediumBlue;
                    break;
            }
        }
        

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            // Installeren van timer dmv de klasse aan te spreken.
            DispatcherTimer wekker = new DispatcherTimer();
            // Timer laten aflopen om de seconde.
            wekker.Tick += new EventHandler(DispatcherTimer_Tick);
            wekker.Interval = new TimeSpan(0, 0, 1); //uren, minuten, seconden
                                                     // Timer laten starten
            wekker.Start();
            // TIJD instellen.
            TextBlockDateTime.Text = $"{DateTime.Now.ToLongDateString()} {DateTime.Now.ToLongTimeString()}";


            // --- Afbeelding installeren. ---- 

            string seizoenafb = seizoen(DateTime.Today.Month); //huidige datum

            string bestand = System.IO.Path.Combine(@"..\..\Bestanden", seizoenafb);
            //bepaal of seizoensafb bestaat.
            if (File.Exists(bestand))
            {
                ImgSeizoen.Source = new BitmapImage(new Uri(bestand, UriKind.RelativeOrAbsolute));
            }
            else
            {
                MessageBox.Show("Kan afbeelding niet inladen!", "Ongeldig bestand"
                    , MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void DispatcherTimer_Tick(object sender, EventArgs e)
        {
            TextBlockDateTime.Text = $"{DateTime.Now.ToLongDateString()} {DateTime.Now.ToLongTimeString()}";
        }

        private string seizoen(int maand)
        {
            string afb = "winter.jpg";
            switch (maand)
            {
                case 3:
                case 4:
                case 5:
                    afb = "lente.jpg";
                    break;
                case 6:
                case 7:
                case 8:
                    afb = "zomer.jpg";
                    break;
                case 9:
                case 10:
                case 11:
                    afb = "herfst.jpg";
                    break;
            }
            return afb;
        }
    }
}

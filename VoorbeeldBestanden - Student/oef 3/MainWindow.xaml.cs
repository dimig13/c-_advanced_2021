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

namespace oef_3
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

        private Dictionary<string, string> dicGeg = new Dictionary<string, string>();
        private string bestandnaam;
        
        private void btninlezen_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder sb = new StringBuilder();

            OpenFileDialog ofd = new OpenFileDialog()
            {
                Filter = "Tekstbestanden (*.txt) |*.txt|Alle bestanden (*.*)|*.*",
                InitialDirectory = System.IO.Path.GetFullPath(@"..\..\Bestanden"), //enviroment.currentdirection
                Title = "Bestand openen",
                AddExtension = true,
                DefaultExt = "txt",
                FileName = "Punten.txt"
            };

            //Bestand lezen
            if (ofd.ShowDialog() == true)
            {
                bestandnaam = ofd.FileName;

                //Aantal rijen berekenen en grootte van aray definiëren
                //aantal = file.readalllined(bestandnaam).Length;
                //geg = new string[aantal,2]

                using (StreamReader sr = File.OpenText(bestandnaam))
                {
                    string lijn, veld1, veld2, veld3, veld4;

                    while (!sr.EndOfStream)
                    {
                        //scheidingsteken opgeven,geeft array terug gescheiden door opgegeven karakter
                        lijn = sr.ReadLine();
                        veld1 = lijn.Substring(0, 18).Trim(); //naam
                        veld2 = lijn.Substring(19, 20).Trim(); //email
                        veld3 = lijn.Substring(40, 1); //geslacht
                        veld4 = lijn.Substring(48, 6).Trim(); //punten

                        sb.Append($"{veld1, -22}{veld2,10}{veld3,5}{veld4,10}").AppendLine();

                        //velden 1 en 4 in DICTIONARY
                        dicGeg.Add(veld1, veld4);
                    }
                }

               btnverwerken.IsEnabled = true;
                txtresultaat.Text = sb.ToString();

            }


        }

        private void btnverwerken_Click(object sender, RoutedEventArgs e)
        {
            float resultaat;
            StringBuilder sb = new StringBuilder();

            SaveFileDialog sfd = new SaveFileDialog()
            {
                Filter = "Alle bestanden (*.*)|*.*|Tekstbestanden (*.text) | *.txt",
                FilterIndex = 2,
                Title = "Geef een bestandsnaam op",
                OverwritePrompt = true,  // Bevestiging wordt gevraagd bij overschrijven ve bestand.
                AddExtension = true, //extensie wordt toegevoegd.
                DefaultExt = "txt",
                FileName = "verwerkt.txt",
                InitialDirectory = System.IO.Path.GetFullPath(@"..\..\Bestanden"),
               
            };
            //bewaren voor afdruk

            sfd.ShowDialog();

            using(StreamWriter sw = File.CreateText(sfd.FileName))
            {
                //gegevens wegschrijven 
                foreach (var item in dicGeg)
                {
                    //rechts opvullen met nullen.
                    sb.Append($"{item.Key,-24}");

                    //percentage berekenen.
                    resultaat = float.Parse(item.Value.Substring(0, 3)) / float.Parse(item.Value.Substring(3, 3));
                    sb.Append($"{resultaat,-10:p}");

                    if (resultaat >= 0.85)
                    {
                        sb.Append($"{"Geslaagd",-20}").AppendLine();
                    }
                    else
                    {
                        sb.Append($"{"niet geslaagd",-20}").AppendLine();
                    }

                    ////geslaagd of niet geslaagd.
                    //sb.Append((resultaat >= 0.85) ? $"{"geslaagd",-20}" : $"{"niet geslaagd",-20}").AppendLine();
                }

                //Gegevens wegschrijven.
                sw.WriteLine(sb);
            }
            btnnalezen.IsEnabled = true;

        }

        private void btnnalezen_Click(object sender, RoutedEventArgs e)
        {
           
            OpenFileDialog ofd = new OpenFileDialog()
            {
                Filter = "Alle bestanden (*.*)|*.*|Tekstbestanden (*.txt) |*.txt",
                FilterIndex = 2,
                InitialDirectory = System.IO.Path.GetFullPath(@"..\..\Bestanden"), //enviroment.currentdirection
                Title = "Bestand openen",
                FileName = "verwerkt.txt"
            };

            //tekstvak leegmaken.
            txtresultaat.Clear();
            if(ofd.ShowDialog() == true)
            {
                txtresultaat.Text = File.ReadAllText(ofd.FileName);
            }
            else
            {
                MessageBox.Show("De resultaten zij niet verwerkt", "Resultaten", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void btnsluiten_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}

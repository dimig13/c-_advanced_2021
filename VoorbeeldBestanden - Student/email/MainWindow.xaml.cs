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


namespace email
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
        private StringBuilder InlezenBestand(string file)
        {
            StringBuilder sb = new StringBuilder();
            string[] velden;


            try
            {
                using (StreamReader sr = new StreamReader(file))
                {
                    int i = 1;
                    while (!sr.EndOfStream)
                    {
                        // Scheidingsteken opgeven
                        velden = sr.ReadLine().Split(',');
                        if (velden.Length != 2) // lege regel, geen ',' tussen velden of een veld ontbreekt
                        {
                            MessageBox.Show($"Onvolledige gegevens bij lijn {i}");
                        }
                        else
                        {
                            sb.Append($"{velden[0].Replace("\"", ""),-20} :" +
                                      $"{velden[1].Replace("\"", "")}").AppendLine();
                        }
                        i++;
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Probleem met het inlezen van het bestand.", "Foutmelding", MessageBoxButton.OK, MessageBoxImage.Warning);
                throw;
            }

            return sb;

        }

        private void BtnInlezen_Click(object sender, RoutedEventArgs e)
        {
            //Functie inlezenbestand dat een stringbuilder teruggeeft.
            StringBuilder sb = InlezenBestand("email.txt");

            if(sb.Length != 0)
            {
                TxtResultaat.Text = sb.ToString();
            }
        }

        private void BtnInlezenDialog_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog
            {
                Filter = "Alle bestanden (*.*)|*.*|Tekstbestanden (*.text) | *.txt",
                FilterIndex = 2,
                FileName = "email.txt",
                InitialDirectory = Environment.CurrentDirectory // onder ..\debug
            };

            if (ofd.ShowDialog() == true)
            {
                StringBuilder sb = InlezenBestand(ofd.FileName);

                if(sb.Length != 0)
                {
                    TxtResultaat.Text = sb.ToString();
                }
            }

        }

        private void BtnInlezenDictionary_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder sb = new StringBuilder();
            string[] velden;


            try
            {
                using (StreamReader sr = new StreamReader("email.txt"))
                {
                    int i = 1;
                    while (!sr.EndOfStream)
                    {
                        // Scheidingsteken opgeven
                        velden = sr.ReadLine().Split(',');
                        if (velden.Length != 2) // lege regel, geen ',' tussen velden of een veld ontbreekt
                        {
                            MessageBox.Show($"Onvolledige gegevens bij lijn {i}");
                        }
                        else
                        {
                            dicGeg.Add(velden[0].Replace("\"", ""), velden[1].Replace("\"", ""));
                        }
                        i++;
                    }
                }
                foreach (var item in dicGeg)
                {
                    TxtResultaat.Text += $"{item.Key,-20}: {item.Value}\n";
                }
                BtnWegschrijven.IsEnabled = true;

            }
            catch (FileNotFoundException ex)
            {
                MessageBox.Show("Geef nieuwe naam!\n\n" + ex.Message, "Foutmelding"
                , MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            catch (Exception)
            {
                MessageBox.Show("Probleem met het inlezen van het bestand.", "Foutmelding", MessageBoxButton.OK, MessageBoxImage.Warning);
                throw;
            }
            
        }

        private void BtnWegschrijven_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                using(StreamWriter sw= File.CreateText("Adressen.txt"))
                {
                    foreach(var item in dicGeg)
                    {
                        sw.WriteLine(item.Value);
                    }
                }
                MessageBox.Show(@"E-mailadressen weggeschreven in ..\Adressen.txt.", "Info",
                    MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception)
            {
                MessageBox.Show("Kan bestand niet wegschrijven.", "Foutmelding", MessageBoxButton.OK, MessageBoxImage.Warning);

            }
        }

        private void BtnSluiten_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog()
            {
                Filter = "Alle bestanden (*.*)|*.*|Tekstbestanden (*.text) | *.txt",
                FilterIndex = 2,
                Title = "Geef een bestandsnaam op",
                OverwritePrompt = true,
                AddExtension = true,
                DefaultExt = "txt",
                FileName = "email.txt",
                InitialDirectory = Environment.CurrentDirectory // onder ..\debug
            };
            sfd.ShowDialog(); 

            //toevoegen aan bestand.



        }
    }
}

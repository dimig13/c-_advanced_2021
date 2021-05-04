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
using System.Windows.Threading;


namespace woordenboektab
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

        // Declaratie
        private int index;
        private Random willekeurig = new Random();
        private List<string> ICTEngels = new List<string>();
        private List<string> ICTNed = new List<string>();

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            // User in statusbalk afdrukken.
            TextBlockUser.Text = $"Gebruiker: {Wachtwoorden.user}";

            // ===== BESTAND INLADEN =====
            string[] velden;
            string pad = @"..\..\bestanden\ICTTermen.txt";
            if (File.Exists(pad))
            {
                using (StreamReader sr = File.OpenText(pad))
                {
                    while (!sr.EndOfStream)
                    {
                        velden = sr.ReadLine().Split('|');

                        ICTEngels.Add(velden[0]);
                        ICTNed.Add(velden[1]);
                        LbxTermen.Items.Add($"{velden[0]} - {velden[1]}");
                    }
                }
            }
            else
            {
                MessageBox.Show("Bestand bestaat niet", "Foutmelding",
               MessageBoxButton.OK, MessageBoxImage.Error);
            }
            // ==== TIMER INSTALLEREN =====
            // Installeren van timer dmv de klasse aan te spreken.
            DispatcherTimer wekker = new DispatcherTimer();
            // Timer laten aflopen om de seconde.
            wekker.Tick += new EventHandler(DispatcherTimer_Tick);
            wekker.Interval = new TimeSpan(0, 0, 1); //uren, minuten, seconden
                                                     // Timer laten starten
            wekker.Start();
            // TIJD instellen.
            TextBlockDatumTijd.Text = $"{DateTime.Now.ToLongDateString()} { DateTime.Now.ToLongTimeString()} ";

        }
        private void DispatcherTimer_Tick(object sender, EventArgs e)
        {
            TextBlockDatumTijd.Text = $"{DateTime.Now.ToLongDateString()} { DateTime.Now.ToLongTimeString()} ";

        }
        private void Window_Closing(object sender,
      System.ComponentModel.CancelEventArgs e)
        {
            string pad = @"..\..\bestanden\ICTTermen.txt";
            if (File.Exists(pad))
            {
                // Creëert een bestand om naar te schrijven. 
                using (StreamWriter sw = File.CreateText(pad))
                {
                    for (int i = 0; i < ICTEngels.Count; i++)
                    {
                        sw.WriteLine($"{ICTEngels[i]}|{ICTNed[i]}");
                    }
                }
            }
            else
            {
                MessageBox.Show("Bestand bestaat niet","Foutmelding",MessageBoxButton.OK,MessageBoxImage.Error);
            }
            // Sluit alle vensters
            Environment.Exit(0);
        }
        private void BtnVerwijderen_Click(object sender, RoutedEventArgs e)
        {
            // woord verwijderen uit List ICTEngels en List ICTNed
            if (LbxTermen.SelectedIndex != -1)
            {
                ICTEngels.RemoveAt(LbxTermen.SelectedIndex);
                ICTNed.RemoveAt(LbxTermen.SelectedIndex);
                // woord verwijderen uit listbox.
                LbxTermen.Items.Remove(LbxTermen.SelectedItem);
            }
            else
            {
                MessageBox.Show("Selecteer eerst item om te verwijderen.");
            }
        }
        private void BtnControle_Click(object sender, RoutedEventArgs e)
        {
            if (!string.Equals(TxtNedTerm.Text, ICTNed[index]))
            {
                MessageBox.Show($"De vertaling is verkeerd ({ICTNed[index]})", "Fout"
                , MessageBoxButton.OK, MessageBoxImage.Warning);
                TxtNederlands.Focus();
                TxtNederlands.SelectAll();
            }
            else
            {
                MessageBox.Show($"De vertaling is goed ({ICTNed[index]})", "Prima vertaling"
                , MessageBoxButton.OK);
            }
        }
        private void TabControl_SelectionChanged(object sender,
       System.Windows.Controls.SelectionChangedEventArgs e)
        {
            if (TbcWoordenboek.SelectedIndex == 1)
            {
                TxtEngTerm.Clear();
                TxtNedTerm.Clear();
            }
        }
        private void MnuToevoegen_Click(object sender, RoutedEventArgs e)
        {
            // Focus plaatsen op tweede tabblad.
            TbcWoordenboek.SelectedIndex = 0;
            TxtEngels.Focus();
        }
        private void MnuSluiten_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
        private void BtnZoeken_Click(object sender, RoutedEventArgs e)
        {
            index = willekeurig.Next(0, ICTEngels.Count);
            TxtEngTerm.Text = ICTEngels[index];
            TxtNedTerm.Clear();
        }
        private void BtnToevoegen_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(TxtEngels.Text) ||
           string.IsNullOrEmpty(TxtNederlands.Text))
            {
                MessageBox.Show("Alle gegevens invullen aub", "Ontbrekende gegevens");
            }
            else
            {
                ICTEngels.Add(TxtEngels.Text);
                ICTNed.Add(TxtNederlands.Text);
                LbxTermen.Items.Add($"{TxtEngels.Text} - {TxtNederlands.Text}");
            }
            TxtEngTerm.Clear();
            TxtNedTerm.Clear();
            TxtEngTerm.Focus();
        }


    }
}
    

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

namespace Klassepersoneel
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


        private personeel mdwrk = new personeel();

        private void BtnVerhoog_Click(object sender, RoutedEventArgs e)
        {
            mdwrk.VerhoogBeoordeling();
            TxtResultaat.Text = mdwrk.ToonInfo();
        }

        private void BtnVerlaag_Click(object sender, RoutedEventArgs e)
        {
            mdwrk.VerlaagBeoordeling();
            TxtResultaat.Text = mdwrk.ToonInfo();
        }
        

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            MessageBoxResult antwoord = MessageBox.Show("starten met ingevulde waarden?", "start", MessageBoxButton.YesNo);

            if(antwoord == MessageBoxResult.Yes)
            {
                mdwrk = new personeel("cuppens", "Helena", "V", 7, 1993);

                // ==== gegevens van klasse personeel toekennen aan tekstvakken.
                TxtVoornaam.Text = mdwrk.Voornaam;
                TxtNaam.Text = mdwrk.Naam;
                TxtStartjaar.Text = mdwrk.Startjaar.ToString();
                CboGeslacht.Text = mdwrk.Geslacht;
                TxtResultaat.Text = mdwrk.ToonInfo();
            }
            else
            {
                TxtStartjaar.Text = mdwrk.Startjaar.ToString();
                
            }
        }

        private void TxtVoornaam_TextChanged(object sender, TextChangedEventArgs e)
        {
            mdwrk.Voornaam = TxtVoornaam.Text;
            TxtResultaat.Text = mdwrk.ToonInfo();
        }

        private void TxtNaam_TextChanged(object sender, TextChangedEventArgs e)
        {
            mdwrk.Naam = TxtNaam.Text;
            TxtResultaat.Text = mdwrk.ToonInfo();
        }

        private void TxtStartjaar_TextChanged(object sender, TextChangedEventArgs e)
        {
            // controle is leeg
            mdwrk.Startjaar = int.Parse(TxtStartjaar.Text);
            TxtResultaat.Text = mdwrk.ToonInfo();
        }

        private void CboGeslacht_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            mdwrk.Geslacht = ((ComboBoxItem)CboGeslacht.SelectedItem).Content.ToString();
            TxtResultaat.Text = mdwrk.ToonInfo();
        }
    }
}

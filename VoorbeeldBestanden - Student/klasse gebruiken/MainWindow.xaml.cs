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

namespace klasse_gebruiken
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

        private void btnleeg_Click(object sender, RoutedEventArgs e)
        {
            // oproepen van constr zonder param.
            Gebruiker gb = new Gebruiker();

            gb.Voornaam = txtvoornaam.Text;
            gb.Naam = txtnaam.Text;

            //klasse gebruiken.
            txtresultaat.Text = $"Voornaam: {gb.Voornaam}\n";
            txtresultaat.Text += $"Gegevens {gb.Gegevens}";


            //functie van klasse oproepen.
            txtresultaat.Text += $"\n\nNaam van gebruiker : {gb.ToonNaam()}";
        }

        private void btnpersoon_Click(object sender, RoutedEventArgs e)
        {
            //Lege klasse.
            persoon prsoon = new persoon();

            txtresultaat.Text = $"Naam: {prsoon.Naam}\n";
            txtresultaat.Text += prsoon.ToonNaam();

            //klasse met parameters.
            prsoon = new persoon("dimi", "giannakos");
            txtresultaat.Text += $"\n\nNaam: {prsoon.Naam}\n";
            txtresultaat.Text += prsoon.ToonNaam();
        }

        private void btnparameter_Click(object sender, RoutedEventArgs e)
        {
            Gebruiker naam = new Gebruiker("Dimi", "Giannakos");

            //klasse gebruiken.
            txtresultaat.Text = $"Voornaam: {naam.Voornaam}\n";
            txtresultaat.Text += $"Gegevens: {naam.Gegevens}";

            //Functie van klasse oproepen.
            txtresultaat.Text += $"\n\n Naam van gebruiker: {naam.ToonNaam()}";
        }

        private void btnverjaardag_Click(object sender, RoutedEventArgs e)
        {
            //lege constructor.
            verjaardag verj = new verjaardag
            {
                IsFeest = true,
                AantalCadeaus = 2,
                Mijnboodschap = "Dimitri"
            };
            MessageBox.Show(verj.Mijnboodschap);

            // constructor met parameters.
            verj = new verjaardag(txtvoornaam.Text, DateTime.Parse("1999-05-30"));
            MessageBox.Show(verj.Mijnboodschap, txtvoornaam.Text + " " + txtnaam.Text);
        }
    }
}

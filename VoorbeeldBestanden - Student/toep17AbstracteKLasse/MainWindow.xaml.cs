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

namespace toep17AbstracteKLasse
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
   
        public partial class MainWindow : Window 
        {
            public MainWindow()
            {
                InitializeComponent();
                // Roept op

                Initialize();
            }
            private Bankrekening zRek;
            private Bankrekening sRek;
            private void Initialize()
            {
                // Zichtrekening initialiseren.
                zRek = new Zichtrekening(2000, "PXL Digital | Campus PXL Hasselt"
                , "Elfde­Liniestraat 26, 3500 Hasselt");
                TxbZichtrekening.Text = zRek.Naam + ", " + zRek.Adres;
                TxbSaldoZichtrekening.Text = $"{zRek.HuidigSaldo:c}";
                TxbRenteZichtrekening.Text = $"{zRek.BerekenRente():c}";
                // Spaarrekening initialiseren.
                sRek = new Spaarrekening(9500, zRek.Naam, zRek.Adres);
                TxbSpaarrekening.Text = sRek.Naam + ", " + sRek.Adres;
                TxbSaldoSpaarrekening.Text = $"{sRek.HuidigSaldo:c}";
                TxbRenteSpaarrekening.Text = $"{sRek.BerekenRente():c}";
            }
            
            private void BtnAfsluiten_Click_1(object sender, RoutedEventArgs e)
            {
                Close();
            }
            


           

        private void BtnSaldo_Click_1(object sender, RoutedEventArgs e)
        {
            int bedrag = 0;

            bedrag = int.Parse(TxtBedrag.Text);
            try
            {
                if (bedrag < 0)
                {
                    zRek.CreditSaldo(-bedrag); // vb. ­(­500) wordt 500
                    sRek.CreditSaldo(-bedrag);
                }
                else
                {
                    sRek.DebetSaldo(bedrag);
                    zRek.DebetSaldo(bedrag);
                }
            }
            catch (BankException ex) // Foutmelding bij saldo < 0
            {
                MessageBox.Show(ex.Message, "Foutmelding", MessageBoxButton.OK
                , MessageBoxImage.Stop);
            }
            TxbSaldoZichtrekening.Text = $"{zRek.HuidigSaldo:c}";
            TxbSaldoSpaarrekening.Text = $"{sRek.HuidigSaldo:c}";
        }

        private void BtnRente_Click_1(object sender, RoutedEventArgs e)
        {
            TxbRenteZichtrekening.Text = $"{zRek.BerekenRente():c}";
            TxbRenteSpaarrekening.Text = $"{sRek.BerekenRente():c}";
        }
    }
    }


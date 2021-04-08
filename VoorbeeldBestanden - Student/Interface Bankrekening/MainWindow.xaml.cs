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

namespace Interface_Bankrekening
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Initialize();

        }

        private Bankrekening bnkrek;
        private void Initialize()
        {
            bnkrek = new Bankrekening(TxtRekeningnummer.Text, TxtNaam.Text);
        }



        private void BtnBerekenen_Click(object sender, RoutedEventArgs e)
        {
            float bedrag = float.Parse(TxtBedrag.Text);
            
            try
            {
                if(bedrag <0 )
                {
                    bnkrek.Opname(-bedrag);
                }
                else
                {
                    bnkrek.Storting(bedrag);
                }
                TxtSaldo.Text = Convert.ToString(bnkrek.Saldo);
            }
            catch (BankException ex)
            {
                MessageBox.Show(ex.Message, "FOUT", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        
    }
}

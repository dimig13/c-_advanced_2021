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

namespace Interfacebegin
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

        private void BtnLeefdtijd_Click(object sender, RoutedEventArgs e)
        {
            Persoon persoon = new Persoon(TxtVoornaam.Text, TxtNaam.Text, int.Parse(TxtGeboortjaar.Text));
            BerekenOuderdom(persoon);
        }

        private void BtnOuderdom_Click(object sender, RoutedEventArgs e)
        {
            Boom boom = new Boom(TxtSoort.Text, int.Parse(TxtPlantjaar.Text));
            BerekenOuderdom(boom);
        }

        private void BerekenOuderdom(IOuderdom pb)
        {
            MessageBox.Show("Ouderdom: " + pb.Ouderdom, pb.Naam, MessageBoxButton.OK, MessageBoxImage
                .Information);
        }
    }
}

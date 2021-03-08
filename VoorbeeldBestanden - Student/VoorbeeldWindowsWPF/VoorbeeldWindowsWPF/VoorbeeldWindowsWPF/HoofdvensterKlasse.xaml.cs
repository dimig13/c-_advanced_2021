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
using System.Windows.Shapes;

namespace VoorbeeldWindowsWPF
{
    /// <summary>
    /// Interaction logic for HoofdvensterKlasse.xaml
    /// </summary>
    public partial class HoofdvensterKlasse : Window
    {
        public HoofdvensterKlasse()
        {
            InitializeComponent();

            // Dadelijk inhoud van TxtResultaat toekennen aan KLasse DataTxt. Kan ook bij Form_Load.
            DataTxt.Tekst = TxtResultaat.Text;
        }

        private void BtnWijzigen_Click(object sender, RoutedEventArgs e)
        {
            
            KeuzevensterKlasse keuzevenster = new KeuzevensterKlasse();
            keuzevenster.Show();
        }


        private void Window_Activated(object sender, EventArgs e)
        {
            // Windows actief bij Load en terug visible.
            TxtResultaat.Text = DataTxt.Tekst;
        }

        private void BtnInfo_Click(object sender, RoutedEventArgs e)
        {
            Info infovenster = new Info();
            infovenster.ShowDialog();
        }
    }
}

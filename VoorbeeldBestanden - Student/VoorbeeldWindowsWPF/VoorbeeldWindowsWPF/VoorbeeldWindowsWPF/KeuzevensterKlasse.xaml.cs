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
    /// Interaction logic for KeuzevensterKlasse.xaml
    /// </summary>
    public partial class KeuzevensterKlasse : Window
    {
        public KeuzevensterKlasse()
        {
            InitializeComponent();
        }

        private void BtnOk_Click(object sender, RoutedEventArgs e)
        {
            // === Via Var.Tekst  doorgegeven ===

            if (RadUpper.IsChecked == true)
            {
                DataTxt.Tekst = DataTxt.Tekst.ToUpper();
            }
            else
            {
                DataTxt.Tekst = DataTxt.Tekst.ToLower();
            }

            //Formulier verbergen zodat HoofdvensterKlasse terug actief (Window_Activated) wordt.
            Hide();
        }

        private void BtnCancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}

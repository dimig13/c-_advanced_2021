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
    /// Interaction logic for HoofdvensterTxt.xaml
    /// </summary>
    public partial class HoofdvensterTxt : Window
    {
        public HoofdvensterTxt()
        {
            InitializeComponent();
        }

        private void BtnWijzigen_Click(object sender, RoutedEventArgs e)
        {
            KeuzevensterTxt keuzevenster = new KeuzevensterTxt(TxtResultaat);

            //modal form oproepen
            keuzevenster.ShowDialog();

            if (keuzevenster.DialogResult.HasValue && keuzevenster.DialogResult.Value)
            {
                MessageBox.Show("Knop Ok gedrukt.");
            }
            else
            {
                MessageBox.Show("Knop Cancel/Sluiten gedrukt.");
            }
        }

        private void BtnInfo_Click(object sender, RoutedEventArgs e)
        {
            Info infovenster = new Info();
            infovenster.ShowDialog();
        }
    }
}

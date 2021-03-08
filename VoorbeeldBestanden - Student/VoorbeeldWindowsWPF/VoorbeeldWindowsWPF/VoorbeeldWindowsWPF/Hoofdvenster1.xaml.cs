using System.Windows;
using System.Windows.Controls;

namespace VoorbeeldWindowsWPF
{
    /// <summary>
    /// Interaction logic for Hoofdvenster1.xaml
    /// </summary>
    public partial class Hoofdvenster1 : Window
    {
        public Hoofdvenster1()
        {
            InitializeComponent();
        }

        // Klasseniveau - public !!!!
        public static TextBox txtWijzig = new TextBox();
        private void BtnWijzigen_Click(object sender, RoutedEventArgs e)
        {
            // Objecten worden aan elkaar doorgegeven.
            txtWijzig = TxtResultaat;

            Keuzevenster1 windowKeuze = new Keuzevenster1();

            // Modal form als dialoogvenster oproepen
            windowKeuze.ShowDialog();


            //ShowDialog == True als DialogResult.Ok en False als DialogResult.Cancel.
            if (windowKeuze.DialogResult.HasValue && windowKeuze.DialogResult.Value) 
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

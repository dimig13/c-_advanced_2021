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
using System.IO;

namespace woordenboekoef
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();
        }

        private int index;
        private readonly Random rnd = new Random();

        private void BtnZoeken_Click_(object sender, RoutedEventArgs e)
        {
            index = rnd.Next(0, Lexicon.ICTEngels.Count);
            TxtEngels.Text = Lexicon.ICTEngels[index];
        }

        private void BtnControle_Click(object sender, RoutedEventArgs e)
        {
            if(!string.Equals(TxtNederlands.Text, Lexicon.ICTNed[index]))
            {
                MessageBox.Show($"De vertaling is verkeerd.\n het juiste antwoord was" +
                    $"{Lexicon.ICTNed[index].ToUpper()}", "Fout", MessageBoxButton.OK,
                    MessageBoxImage.Warning);
                TxtNederlands.Focus()
;               TxtNederlands.SelectAll();
            }
            else
            {
                MessageBox.Show("De vertaling is goed", "Prima vertaling", MessageBoxButton.OK);
            }
        }

        private void MnuAfsluiten_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void MnuVorigVenster_Click(object sender, RoutedEventArgs e)
        {
            Hide();

            TxtEngels.Clear();
        }

        
    }
}

using System.Windows;
using System.Windows.Controls;

namespace VoorbeeldWindowsWPF
{
    /// <summary>
    /// Interaction logic for KeuzevensterTxt.xaml
    /// </summary>
    public partial class KeuzevensterTxt : Window
    {
        // Declaratie van TextBox.
        private TextBox tb;
        public KeuzevensterTxt(TextBox txtResult)
        {
            InitializeComponent();
            
            // Hier binnen het tekstvak definieren en de 2 objecten worden aan elkaar gekoppeld.
            tb = txtResult;
        }

        private void BtnOk_Click(object sender, RoutedEventArgs e)
        {
            // === Via TextBox  doorgegeven ===

            if (RadUpper.IsChecked== true)
            {
                tb.Text = tb.Text.ToUpper();
                tb.Background = System.Windows.Media.Brushes.BurlyWood;
                tb.FontWeight = FontWeights.Bold; 
             }
            else
            {
                tb.Text = tb.Text.ToLower();
            }

            // Doorgeven op OK geklikt.
            DialogResult = true;
        }

        private void BtnCancel_Click(object sender, RoutedEventArgs e)
        {
            // Doorgeven op CANCEL geklikt.
            DialogResult = false;
        }
    }
}

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

namespace VoorbeeldWindowsWPF
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

        private void BtnShow_Click(object sender, RoutedEventArgs e)
        {
            //// Declaratie van het tweede venster.
            Window2 w2 = new Window2();

            // Oproepen in niet-modale status.
            w2.Show();
        }

        private void BtnShowDialog_Click(object sender, RoutedEventArgs e)
        {
            Window2 w2 = new Window2();
            w2.ShowDialog();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Windows wordt geladen.");
        }

       
        private void Window_Closed(object sender, EventArgs e)
        {
            MessageBox.Show("Windows is gesloten.");
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            MessageBox.Show("Windows gaat sluiten.");
        }

        
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

       
    }
}

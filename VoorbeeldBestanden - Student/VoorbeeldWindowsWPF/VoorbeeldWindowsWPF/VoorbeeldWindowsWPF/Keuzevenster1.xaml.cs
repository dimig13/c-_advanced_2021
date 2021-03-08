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
    /// Interaction logic for Keuzevenster1.xaml
    /// </summary>
    public partial class Keuzevenster1 : Window
    {
        public Keuzevenster1()
        {
            InitializeComponent();
        }

        private void BtnOk_Click(object sender, RoutedEventArgs e)
        {
            string wijzigLetter = Hoofdvenster1.txtWijzig.Text;

            if (radUpper.IsChecked==true)
            {
                wijzigLetter = wijzigLetter.ToUpper();
            }
            else
            {
                wijzigLetter = wijzigLetter.ToLower();
            }

            Hoofdvenster1.txtWijzig.Text = wijzigLetter;

            // doorgeven op OK geklikt
            DialogResult = true;
        }

        private void BtnCancel_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }
    }
}

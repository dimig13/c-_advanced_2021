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

namespace voorbeeldovererving
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

        private Student stud = new Student();
        private Persoon persn = new Persoon();
        private Lector lct = new Lector();

        private void Button_Click_2(object sender, RoutedEventArgs e) // button persoon 
        {
            Persoon prs = new Persoon();
            // Alle gegevens van de persoon zitten in de constructor maar
            //enkel het e­mailadres moet uit het tekstvak opgehaald worden.
            // Controle
            if (Validator.IsPresent(TxtEmail) == true && Validator.IsValidEmail
            (TxtEmail) == true)
            {
                prs.Email = TxtEmail.Text;
                // Afdruk van gegevens.
                prs.Info(" ");
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e) // button lector
        {
            List<Lector> lctLijst = Bestandsbewerking.LeesLectoren();
            // === Afdruk ====
            LbxInfo.Items.Clear();
            foreach (Lector item in lctLijst)
            {
                LbxInfo.Items.Add(item.Gegevens);
                // === OF ==
                LbxInfo.Items.Add($"{ item.VolledigeNaam()} { item.ToString()} ");
            // === OF ==
           //LbxInfo.Items.Add($"{ item.AfdrukIndienst()}");
           // === OF ==
             //LbxInfo.Items.Add($"{ item.AfdrukAdres()}");
        }
        // === OF ==
        lct.Info(lctLijst[32].AfdrukIndienst());
        }

        private void Button_Click(object sender, RoutedEventArgs e)  // button student
        {
            List<Student> studLijst = Bestandsbewerking.LeesStudenten();
            // === Afdruk ====
            LbxInfo.Items.Clear();

            foreach (Student item in studLijst)
            {
                //LbxInfo.Items.Add(item.Gegevens);
                // === OF ==
                LbxInfo.Items.Add($"{ item.VolledigeNaam()} { item.ToString()}");

                // === OF ==
                //LbxInfo.Items.Add($"{ item.AfdrukStartdatum()}");
                // === OF ==
                //LbxInfo.Items.Add($"{ item.AfdrukAdres()}");
        }
             // === OF ==
                stud.Info(studLijst[8].VolledigeNaam());
        }
    }
}

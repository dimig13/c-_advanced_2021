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
using System.Data;
using System.IO;
using Microsoft.Win32;

namespace toep_23
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

        DataSet ds = new DataSet();
        DataTable dt = new DataTable("Medewerkers");

        private void MaakTabellen()
        {
           

            //kolommen aanmaken.
            DataColumn dcMnr = new DataColumn("Mnr", typeof(int));
            DataColumn dcNaam = new DataColumn("Naam", typeof(string));
            DataColumn dcVoornaam = new DataColumn("Voornaam", typeof(string));
            DataColumn dcFunctie = new DataColumn("Functie", typeof(string));
            DataColumn dcChef = new DataColumn("Chef", typeof(string));
            DataColumn dcGbdatum = new DataColumn("Gbdatum", typeof(DateTime));
            DataColumn dcMaandsal = new DataColumn("Maandsal", typeof(float));
            DataColumn dcComm = new DataColumn("Comm", typeof(float));
            DataColumn dcAfd = new DataColumn("Afd", typeof(int));

            //specifieke eigenschappen toekennen aan null-kolommen
            dcComm.AllowDBNull = true;
            dcChef.AllowDBNull = true;
            // kolommen toevoegen aan Datacolumncollection.
            dt.Columns.Add(dcMnr);
            dt.Columns.Add(dcNaam);
            dt.Columns.Add(dcVoornaam);
            dt.Columns.Add(dcFunctie);
            dt.Columns.Add(dcChef);
            dt.Columns.Add(dcGbdatum);
            dt.Columns.Add(dcMaandsal);
            dt.Columns.Add(dcComm);
            dt.Columns.Add(dcAfd);

            //primary key toekennen.
            DataColumn[] sleutel = { dcMnr };
            dt.PrimaryKey = sleutel;
            //Datatable toevoegen aan dataset.
            ds.Tables.Add(dt);

        }

        private void VulTabellen()
        {
            ds.Clear();

            //rijen toevoegen aan tabel 
            dt.Rows.Add(new object[] { 1, "PALMAERS", "KRISTOF", "TRAINER", 5, "17/12/1985", 2800, null, 20 });
            dt.Rows.Add(new object[] { 2, "DOX", "PAUL", "TRAINER", 5, "17/11/1972", 3500, null, 20 });
            dt.Rows.Add(new object[] { 3, "VOS", "FRANCIS", "DEPARTEMENTSHOOFD", DBNull.Value, "3/12/1989", 5800.55, null, 10 });
            dt.Rows.Add(new object[] { 4, "BRIERS", "PATRICIA", "TRAINER", 5, "22/2/1972", 2250, 3000.99, 20 });
            dt.Rows.Add(new object[] { 5, "BRUGGEN", "NATACHA", "COORDINATOR", 3, "16/5/1984", 2250, 2950, 30 });

           
           
        }

        private void AfdrukDataGrid()
        {
            DataView dv = ds.Tables["Medewerkers"].DefaultView;
            DataGrid.ItemsSource = dv;
        }

        private void BtnToevoegen_Click(object sender, RoutedEventArgs e)
        {
            MaakTabellen();
            VulTabellen();
            AfdrukDataGrid();
            
        }

       

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog
            {
                Filter = "Alle bestanden (*.*)|*.*|Tekstbestanden (*.txt) |*.txt",
                FilterIndex = 2,
                FileName = "medewerkers.txt",
                InitialDirectory = System.IO.Path.GetFullPath(@"..\..\bestand")
            };

            if(ofd.ShowDialog() == true)
            {
                //dataset leegmaken voor nieuwe gegevens.
                ds.Clear();
                string bestand = ofd.FileName;
                string[] lijnen = File.ReadAllLines(bestand);
                for(int rij = 0; rij < lijnen.Length; rij++)
                {
                    VoegMedewerkerToe(lijnen[rij].Split(';'));
                }
                AfdrukDataGrid();
            }
        }

       
        private void VoegMedewerkerToe(string[] kolomwaarden)
        {
            DataRow dr = dt.NewRow();
            try
            {
                dr["Mnr"] = int.Parse(kolomwaarden[0]);
                dr["Naam"] = kolomwaarden[1];
                dr["Voornaam"] = kolomwaarden[2];
                dr["Functie"] = kolomwaarden[3];
                dr["Chef"] = (kolomwaarden[4] != "") ? kolomwaarden[4] : null;
                dr["Gbdatum"] = Convert.ToDateTime(kolomwaarden[5]);

                if (kolomwaarden[6] != "")
                    dr["Maandsal"] = float.Parse(kolomwaarden[6]);
                else
                    dr["Maandsal"] = 0;


                dr["Comm"] = (kolomwaarden[7] != "") ? float.Parse(kolomwaarden[7]) : 0;
                dr["Afd"] = (kolomwaarden[8] != "") ? int.Parse(kolomwaarden[8]) : 0;
                dt.Rows.Add(dr);

            } 
            catch (Exception ex)
            {
                MessageBox.Show("error: " + ex.Message);
            }
        }
            

        }
    }


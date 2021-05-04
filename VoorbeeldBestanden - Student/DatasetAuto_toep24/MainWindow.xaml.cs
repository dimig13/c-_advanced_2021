using System;
using System.Collections.Generic;
using System.Data;
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


namespace DatasetAuto_toep24
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

        private DataSet dsAuto; // bevat Datattable Verkoper en dataTable Artikel
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            dsAuto = new DataSet("Verkoop");
            DataTable dtVrkpr = dsAuto.Tables.Add("Verkoper");
            dtVrkpr.Columns.Add("VerkoperId", typeof(int));
            dtVrkpr.Columns.Add("Naam", typeof(string));
            dtVrkpr.Columns.Add("Straat", typeof(string));
            dtVrkpr.Columns.Add("Nr", typeof(string));
            dtVrkpr.Columns.Add("Postcode", typeof(string));
            dtVrkpr.Columns.Add("Woonplaats", typeof(string));
            dtVrkpr.Columns.Add("Land", typeof(string));
            dtVrkpr.Columns.Add("Afdeling", typeof(string));
            dtVrkpr.PrimaryKey = new DataColumn[] { dtVrkpr.Columns["VerkoperId"] };

            DataTable dtArt = dsAuto.Tables.Add("Artikel");
            dtArt.Columns.Add("ArtId", typeof(int));
            dtArt.Columns.Add("VerkoperId", typeof(int));
            dtArt.Columns.Add("Code", typeof(string));
            dtArt.Columns.Add("Beschrijving", typeof(string));
            dtArt.Columns.Add("Aankoopprijs", typeof(decimal));
            dtArt.Columns.Add("Verkoopprijs", typeof(decimal));
            dtArt.PrimaryKey = new DataColumn[] { dtArt.Columns["ArtId"] };

            //relatie tussen tabellen leggen.
            DataRelation VerkoperArtikel_FK = dsAuto.Relations.Add("VerkoperArtikel", dtVrkpr.Columns["VerkoperId"], dtArt.Columns["VerkoperId"]);
            dsAuto.EnforceConstraints = false; //Alle constraints uitschakelen om toe te voegen.

            //Gegevens Toevoegen voor verkoper.
            DataRow drVerkoper = dtVrkpr.NewRow();
            drVerkoper["VerkoperId"] = 10;
            drVerkoper["Naam"] = "Elon Musk";
            drVerkoper["Straat"] = "Herkenrodesingel";
            drVerkoper["Nr"] = "77";
            drVerkoper["Postcode"] = "3500";
            drVerkoper["Woonplaats"] = "Hasselt";
            drVerkoper["Land"] = "België";
            drVerkoper["Afdeling"] = "West-Europa";
            dtVrkpr.Rows.Add(drVerkoper);
            drVerkoper = dtVrkpr.NewRow();
            drVerkoper["VerkoperId"] = 20;
            drVerkoper["Naam"] = "Clotilde Delbos";
            drVerkoper["Straat"] = "Gouverneur Roppesingel";
            drVerkoper["Nr"] = "2";
            drVerkoper["Postcode"] = "3500";
            drVerkoper["Woonplaats"] = "Hasselt";
            drVerkoper["Land"] = "België";
            drVerkoper["Afdeling"] = "Azië";
            dtVrkpr.Rows.Add(drVerkoper);

            //Gegevens toevoegen aan artikel.
            DataRow drArtikel = dtArt.NewRow();
            drArtikel["ArtId"] = 1;
            drArtikel["VerkoperId"] = 10;
            drArtikel["Code"] = "Tesla";
            drArtikel["Beschrijving"] = "Tesla Model S";
            drArtikel["Aankoopprijs"] = 65000.0;
            drArtikel["Verkoopprijs"] = 75500.0;
            dtArt.Rows.Add(drArtikel);
            drArtikel = dtArt.NewRow();
            drArtikel["ArtId"] = 2;
            drArtikel["VerkoperId"] = 10;
            drArtikel["Code"] = "Tesla";
            drArtikel["Beschrijving"] = "Tesla Model S 85KWh (dual motor)";
            drArtikel["Aankoopprijs"] = 88400.0;
            drArtikel["Verkoopprijs"] = 96250.0;
            dtArt.Rows.Add(drArtikel);
            drArtikel = dtArt.NewRow();
            drArtikel["ArtId"] = 3;
            drArtikel["VerkoperId"] = 20;
            drArtikel["Code"] = "Renault";
            drArtikel["Beschrijving"] = "Renault Kadjar";
            drArtikel["Aankoopprijs"] = 14000;
            drArtikel["Verkoopprijs"] = 18650.0;
            dtArt.Rows.Add(drArtikel);
            dsAuto.EnforceConstraints = true; // alle constraint inschakelen.

            //Afdruk in Datagrid verkoper.
            DataView dv1 = dsAuto.Tables["Verkoper"].DefaultView;
            dgdVerkoper.ItemsSource = dv1;

            // Afdruk in Datagrid Artikel.
            DataView dv2 = dsAuto.Tables["Artikel"].DefaultView;
            dgdArtikel.ItemsSource = dv2;




        }

        private void BtnListing_Click(object sender, RoutedEventArgs e)
        {

            DataTableReader dtr = dsAuto.CreateDataReader();
            LstArtikel.Items.Add("LIJST VAN VERKOPERS");
            while (dtr.Read())
            {
                LstArtikel.Items.Add(dtr["Naam"]);
            }
            //Naar volgende tabel.
            dtr.NextResult();
            LstArtikel.Items.Add("");
            LstArtikel.Items.Add("LIJST VAN AUTO'S");
            while (dtr.Read())
            {
                LstArtikel.Items.Add(dtr["Beschrijving"]);
            }
        }


    }
}

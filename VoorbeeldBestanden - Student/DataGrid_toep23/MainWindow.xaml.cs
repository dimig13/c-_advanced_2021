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

namespace DataGrid_toep23
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

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            DataSet ds = new DataSet();
            DataTable dt = new DataTable("Stud");

            // Kolommen declareren 
            DataColumn dcStudId = new DataColumn("StudId", typeof(int));
            DataColumn dcNaam = new DataColumn("Naam", typeof(string));
            DataColumn dcOpleiding = new DataColumn("Opleiding", typeof(string));
            DataColumn dcGbDatum = new DataColumn("GbDatum", typeof(DateTime));
            // Kolommen toevoegen aan DataColumnCollection.
            dt.Columns.Add(dcStudId);
            dt.Columns.Add(dcNaam);
            dt.Columns.Add(dcOpleiding);
            dt.Columns.Add(dcGbDatum);
            // Extra kolom met verschillende kenmerken.
            DataColumn dcTel;
            dcTel = new DataColumn();
            dcTel.ColumnName = "Telefoon";
            dcTel.DataType = typeof(string);
            dcTel.Unique = true;
            dcTel.ReadOnly = false;
            dt.Columns.Add(dcTel);
            // Primaire sleutel aanduiden.
            DataColumn[] sleutel = { dcStudId }; // kunnen meerdere kolommen zijn => dus type array 
            dt.PrimaryKey = sleutel;
            // Unieke constraint voor naam toepassen.
            UniqueConstraint uniek = new UniqueConstraint(dcNaam);
            // Rijen toevoegen aan DataTable
            dt.Rows.Add(new object[] { 1, "Kristof Palmaers", "Graduaat Programmeren","17/08/1980","011775100" });
            dt.Rows.Add(new object[] { 2, "Paul Dox", "Graduaat Digitale vormgeving","17/03/1972","011775101" });
            dt.Rows.Add(new object[] { 3, "Patricia Briers", "Graduaat Systemen en netwerken","17/10/1971", "011775102" });
            // Rij toevoegen met DataRow
            DataRow rij = dt.NewRow();
            rij[dcStudId] = 4;
            rij[dcNaam] = "Ann Das";
            rij[dcOpleiding] = "Graduaat Systemen en netwerken";
            rij[dcGbDatum] = "1990/12/15 18:35:10";
            rij[dcTel] = "011775103";
            dt.Rows.Add(rij);
            // Tabel toevoegen aan dataset
            ds.Tables.Add(dt);
            // Afdruk in component DataGrid
            DataView dv = ds.Tables["Stud"].DefaultView;
            DataGridStud.ItemsSource = dv;

        }
    }
}

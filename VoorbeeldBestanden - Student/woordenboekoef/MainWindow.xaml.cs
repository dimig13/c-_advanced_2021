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
using System.IO;

namespace woordenboekoef
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

        private bool wijzigingen = false;
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            string[] velden;
            string bestand = @"..\..\Bestanden\woordenboek.txt";
            if (File.Exists(bestand))
            {
                using (StreamReader sr = File.OpenText(bestand))
                {
                    while (!sr.EndOfStream)
                    {
                        velden = sr.ReadLine().Split('|');

                        Lexicon.ICTEngels.Add(velden[0]);
                        Lexicon.ICTNed.Add(velden[1]);

                        LbxTermen.Items.Add($"{velden[0]} - {velden[1]}");
                    }
                }
            }
        }
        private void BtnToevoegen_Click(object sender, RoutedEventArgs e)
        {
            Lexicon.ICTEngels.Add(TxtEngels.Text);
            Lexicon.ICTNed.Add(TxtNederlands.Text);

            LbxTermen.Items.Add($"{TxtEngels.Text}- {TxtNederlands.Text}");
            TxtEngels.Clear();
            TxtNederlands.Clear();
            TxtEngels.Focus();

            wijzigingen = true;
        }

        private void BtnVerwijderen_Click(object sender, RoutedEventArgs e)
        {
            //=====List versie====
            //woord verwijderen uit list ICTEngels en List ICTNed
            if (LbxTermen.SelectedIndex != -1)
            {
                Lexicon.ICTEngels.RemoveAt(LbxTermen.SelectedIndex);
                Lexicon.ICTNed.RemoveAt(LbxTermen.SelectedIndex);

                // woord wijzigen uit listbox.
                LbxTermen.Items.Remove(LbxTermen.SelectedItems);

                wijzigingen = true;

            }
            else
            {
                MessageBox.Show("Selecteer een item om te verwijderen.");
            }
        }

        private void MnuAfsluiten_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

    

        private void MnuZoekvenster_Click(object sender, RoutedEventArgs e)
        {
            Window1 zwin = new Window1();

            zwin.ShowDialog();
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            AboutBox1 info = new AboutBox1();

            info.ShowDialog();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            string pad = @"..\..\Bestanden\woordenboek.txt";

            if(File.Exists(pad) && wijzigingen == true)
            {
                using (StreamWriter sw = File.CreateText(pad))
                {
                    for(int i =0; i< Lexicon.ICTEngels.Count; i++)
                    {
                        sw.WriteLine($"{Lexicon.ICTEngels[i]}|{Lexicon.ICTNed[i]}");
                    }
                }
                MessageBox.Show("Bestand werd bijgewerkt!", "Info afsluiten"
                    , MessageBoxButton.OK, MessageBoxImage.Information);
            }
            //app volledig afsluiten.
            Environment.Exit(0);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace voorbeeldovererving
{
    public static class Validator
    {
        public static string Title { get; set; } = "Foutmelding";

        public static bool IsPresent(TextBox txtvak)
        {
            if(txtvak.Text == string.Empty)
            {
                System.Windows.MessageBox.Show(txtvak.Tag + "moet ingevuld worden!", Title);
                txtvak.Focus();
                return false;
            }
            return true;
        }

        public static bool IsValidEmail(TextBox txtvak)
        {
            if (txtvak.Text.IndexOf("@") == -1 || txtvak.Text.IndexOf(".") == -1)// -1 is niet aanwezig.
            {
                System.Windows.MessageBox.Show(txtvak.Tag + "moet een geldige e-mailadres zijn",
                    Title);
                txtvak.Focus();
                return false;
            }
            else
            {
                return true;
            }
         
        }
    }
}

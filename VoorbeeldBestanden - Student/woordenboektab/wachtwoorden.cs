using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace woordenboektab
{
   public static class Wachtwoorden
    {
        public static string user = null;

        public static Dictionary<string, string> dicusers = new Dictionary<string, string>()
        {
            {"BrPt" , "Patricia Briers" }
            ,{"PaKr" , "Kristof Palmaers"}
            ,{"DoPa", "Paul Dox"}
            ,{"PXLd", "PXL Digital"}
        };
    }
}

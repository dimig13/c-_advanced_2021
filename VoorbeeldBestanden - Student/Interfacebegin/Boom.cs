using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfacebegin
{
    public class Boom : IOuderdom
    {
        private int ringen;
        private string soort;

        //constructor.
        public Boom(string type, int plantjaar)
        {
            ringen = plantjaar;
            soort = type;
        }

        public int Ouderdom => DateTime.Now.Year - ringen;
        public string Naam => "Boom" + soort;
    }
}

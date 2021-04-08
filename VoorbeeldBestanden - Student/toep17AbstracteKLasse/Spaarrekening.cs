using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace toep17AbstracteKLasse
{
     public class Spaarrekening : Bankrekening
    {
        public Spaarrekening(double opening, string name, string address)
                 : base(opening, name, address)
        { 
        }
        public override double BerekenRente()
        {
            return saldo * 0.015 - 100;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace toep17AbstracteKLasse
{
     public class Zichtrekening : Bankrekening
    {
        public Zichtrekening(double opening, string name, string address)
               : base(opening, name, address)
        { }
        public override void CreditSaldo(int value)
        {
            if ((HuidigSaldo - value) < 0)  // vb. 2000 ­ 500 < 0
{
                throw new BankException("Zichtrekening: saldo ontoereikend!");
            }
            base.CreditSaldo(value);
        }
        public override double BerekenRente()
        {
            return HuidigSaldo * 0.005;
        }
    }
}

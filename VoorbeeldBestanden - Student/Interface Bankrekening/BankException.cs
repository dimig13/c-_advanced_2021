using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interface_Bankrekening
{
     public class BankException : ApplicationException
    {
        public BankException(string message) : base(message)
        {

        }
    }
}

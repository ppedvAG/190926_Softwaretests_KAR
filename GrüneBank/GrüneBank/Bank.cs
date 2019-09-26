using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrüneBank
{
    public class Bank
    {
        private decimal v;

        public Bank()
        {
        }

        public Bank(decimal v)
        {
            this.v = v;
        }

        public decimal Balance { get; set; }

        public void Deposit(decimal v)
        {
            throw new NotImplementedException();
        }

        public void Withdraw(decimal withdrawValue)
        {
            throw new NotImplementedException();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrüneBank
{
    public class Bank
    {
        public Bank() : this(0){} // Standardwert: 0

        public Bank(decimal startBalance)
        {
            if (startBalance < 0)
                throw new ArgumentException();
            Balance = startBalance;
        }

        public decimal Balance { get; private set; }

        public void Deposit(decimal value)
        {
            if (value <= 0)
                throw new ArgumentException();
            Balance += value;
        }

        public void Withdraw(decimal value)
        {
            if (value <= 0 || Balance - value < 0)
                throw new ArgumentException();
            Balance -= value;
        }
    }
}

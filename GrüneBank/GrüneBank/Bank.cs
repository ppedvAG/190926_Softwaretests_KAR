using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrüneBank
{
    public enum Wealth { Debt,Zero,Poor,Ok,Rich,FilthyRich,FirstPercent}

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
        public Wealth Wealth 
        {
            get
            {
                switch (Balance)
                {
                    case 0:
                        return Wealth.Zero;
                    case decimal b when b < 0: // if(b < 0) ... else if .... else if ....
                        return Wealth.Debt;
                    case decimal b when b < 100:
                        return Wealth.Poor;
                    case decimal b when b < 1000:
                        return Wealth.Ok;
                    case decimal b when b < 10_000:
                        return Wealth.Rich;
                    case decimal b when b < 1_000_000:
                        return Wealth.FilthyRich;
                    default:
                        return Wealth.FirstPercent;
                }
            }
        }

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

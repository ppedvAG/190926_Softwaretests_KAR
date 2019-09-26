using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GrüneBank.Tests
{
    [TestClass]
    public class BankTests
    {
        [TestMethod]
        public void Bank_can_create_instance()
        {
            Bank b1 = new Bank();
            Assert.IsNotNull(b1);
            Assert.AreEqual(0, b1.Balance);
        }

        [TestMethod]
        public void Bank_constructor_with_valid_value_sets_balance()
        {
            Bank b1 = new Bank(10_000m);

            Assert.AreEqual(10_000m, b1.Balance);
        }

        [TestMethod]
        public void Bank_constructor_with_invalid_value_throws_ArgumentException()
        {
            Assert.ThrowsException<ArgumentException>(() =>
           {
               Bank b1 = new Bank(-10_000m);
           });
        }

        [TestMethod]
        [DataRow(2_000)]
        [DataRow(20_000)]
        [DataRow(200_000)]
        public void Deposit_with_valid_value_sets_Balance(int depositValue)
        {
            Bank b1 = new Bank();

            Assert.AreEqual(0, b1.Balance);
            b1.Deposit(depositValue);
            Assert.AreEqual(depositValue, b1.Balance);
        }

        [TestMethod]
        [DataRow(0)]
        [DataRow(-50)]
        public void Deposit_with_invalid_value_throws_ArgumentException(int depositValue)
        {
            Bank b1 = new Bank();

            Assert.ThrowsException<ArgumentException>(() =>
            {
                b1.Deposit(depositValue);
            });
        }

        [TestMethod]
        [DataRow(10_000,2_000)]
        [DataRow(20_000,20_000)] // Auf exakt 0 abheben
        [DataRow(300_000,200_000)]
        public void Withdraw_with_valid_value_sets_Balance(int startBalance,int withdrawValue)
        {
            Bank b1 = new Bank(startBalance);

            b1.Withdraw(withdrawValue);
            Assert.AreEqual(startBalance - withdrawValue, b1.Balance);
        }

        [TestMethod]
        [DataRow(10_000, -2_000)]
        [DataRow(20_000, 0)] 
        public void Withdraw_with_invalid_value_throws_ArgumentException(int startBalance, int withdrawValue)
        {
            Bank b1 = new Bank(startBalance);

            Assert.ThrowsException<ArgumentException>(() =>
            {
                b1.Withdraw(withdrawValue);
            });
        }

        [TestMethod]
        [DataRow(10_000, 100_000)]
        [DataRow(20_000, 200_000)]
        public void Withdraw_more_than_Balance_throws_ArgumentException(int startBalance, int withdrawValue)
        {
            Bank b1 = new Bank(startBalance);

            Assert.ThrowsException<ArgumentException>(() =>
            {
                b1.Withdraw(withdrawValue);
            });
        }


    }
}

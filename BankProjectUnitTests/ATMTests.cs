using BankProject;
using BankProjectUnitTests.Mocks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BankProjectUnitTests
{
    [TestClass]
    public class ATMTests
    {
        [TestMethod]
        public void DepositTest()
        {
            ATM atm = new ATM();
            MockBank mockBank = new MockBank();

            atm.BankInstance = mockBank;
            atm.Deposit(0);
            Assert.AreEqual(0, mockBank.AmountDeposited);
            atm.Deposit(10);
            Assert.AreEqual(10, mockBank.AmountDeposited);
        }

        [TestMethod]
        public void WithdrawTest()
        {
            ATM atm = new ATM();
            MockBank mockBank = new MockBank();

            atm.BankInstance = mockBank;
            atm.Withdraw(0);
            Assert.AreEqual(0, mockBank.AmountWithdrawn);
            atm.Withdraw(30);
            Assert.AreEqual(30, mockBank.AmountWithdrawn);
        }
    }
}

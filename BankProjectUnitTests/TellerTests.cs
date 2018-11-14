using BankProject;
using BankProjectUnitTests.Mocks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BankProjectUnitTests
{
    [TestClass]
    public class TellerTests
    {
        [TestMethod]
        public void DepositTest()
        {
            Teller teller = new Teller();
            MockBank mockBank = new MockBank();

            teller.BankInstance = mockBank;
            teller.Deposit(0);
            Assert.AreEqual(0, mockBank.AmountDeposited);
            teller.Deposit(50);
            Assert.AreEqual(50, mockBank.AmountDeposited);
        }

        [TestMethod]
        public void WithdrawTest()
        {
            Teller teller = new Teller();
            MockBank mockBank = new MockBank();

            teller.BankInstance = mockBank;
            teller.Withdraw(0);
            Assert.AreEqual(0, mockBank.AmountWithdrawn);
            teller.Withdraw(20);
            Assert.AreEqual(20, mockBank.AmountWithdrawn);
        }
    }
}

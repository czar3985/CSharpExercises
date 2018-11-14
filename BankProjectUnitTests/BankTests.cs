using BankProject;
using BankProjectUnitTests.Mocks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BankProjectUnitTests
{
    [TestClass]
    public class BankTests
    {
        private Bank _bank;
        private MockAccessor _mockAccessor;
        private MockNotificationSystem _mockNotificationSystem;

        [TestInitialize]
        public void Initialize() {
            Bank.ClearInstance();
            _bank = Bank.Instance;
            _mockAccessor = new MockAccessor();
            _mockNotificationSystem = new MockNotificationSystem();
            _bank.NotificationSystem = _mockNotificationSystem;
        }

        [TestMethod]
        public void InitialValueTest()
        {
            Assert.AreEqual(0, _bank.Balance);
        }

        [TestMethod]
        public void DepositTest()
        {
            _bank.Deposit(0, _mockAccessor);
            Assert.AreEqual(0, _bank.Balance);

            _bank.Deposit(100, _mockAccessor);
            Assert.AreEqual(100, _bank.Balance);

            _bank.Deposit(9999.99, _mockAccessor);
            Assert.AreEqual(9999.99 + 100, _bank.Balance);
        }

        [TestMethod]
        public void DepositAndWithdrawTest()
        {
            _bank.Deposit(500, _mockAccessor);
            _bank.Withdraw(100, _mockAccessor);
            Assert.AreEqual(400, _bank.Balance);

            _bank.Withdraw(200.50, _mockAccessor);
            Assert.AreEqual(400 - 200.50, _bank.Balance);
        }

        [TestMethod]
        public void NotEnoughFundsTest()
        {
            _bank.Deposit(3500, _mockAccessor);
            _bank.Withdraw(3500, _mockAccessor);
            Assert.AreEqual(0, _bank.Balance);

            _bank.Withdraw(1000, _mockAccessor);
            Assert.AreEqual(0, _bank.Balance);
        }

        [TestMethod]
        public void NotificationSytemTest()
        {
            _bank.Deposit(495, _mockAccessor);
            Assert.AreEqual(
                $"Deposit of 495 to Mock Accessor was successful. Balance is {_bank.Balance}.",
                _mockNotificationSystem.MessageReceived);

            _bank.Withdraw(125, _mockAccessor);
            Assert.AreEqual(
                $"Withdrawal of 125 from Mock Accessor was successful. Balance is {_bank.Balance}.",
                _mockNotificationSystem.MessageReceived);

            _bank.Withdraw(371, _mockAccessor);
            Assert.AreEqual(
                $"Withdrawal of 371 from Mock Accessor failed. There wasn't enough funds. Balance is {_bank.Balance}.",
                _mockNotificationSystem.MessageReceived);
        }
    }
}

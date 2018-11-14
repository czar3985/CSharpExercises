using BankProject;

namespace BankProjectUnitTests.Mocks
{
    class MockBank : IBank
    {
        public double AmountDeposited { get; private set; }
        public double AmountWithdrawn { get; private set; }

        public void Deposit(double amount, IBankAccessor accessor)
        {
            AmountDeposited = amount;
        }

        public void Withdraw(double amount, IBankAccessor accessor)
        {
            AmountWithdrawn = amount;
        }
    }
}

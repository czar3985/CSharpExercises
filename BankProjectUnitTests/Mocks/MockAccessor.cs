using BankProject;
using System;
using System.Collections.Generic;
using System.Text;

namespace BankProjectUnitTests.Mocks
{
    class MockAccessor : IBankAccessor
    {
        public string AccessorType => "Mock Accessor";

        public void Deposit(double amount)
        {
            throw new NotImplementedException();
        }

        public void Withdraw(double amount)
        {
            throw new NotImplementedException();
        }
    }
}

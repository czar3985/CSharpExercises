using BankProject;
using System;
using System.Collections.Generic;
using System.Text;

namespace BankProjectUnitTests.Mocks
{
    public class MockNotifier : INotifier
    {
        public string MessageReceived { get; private set; }

        public void NotifyTransactionResult(string resultMessage)
        {
            MessageReceived = resultMessage;
        }
    }
}

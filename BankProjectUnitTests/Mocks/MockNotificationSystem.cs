using BankProject;
using System;
using System.Collections.Generic;
using System.Text;

namespace BankProjectUnitTests.Mocks
{
    class MockNotificationSystem : INotificationSystem
    {
        public string MessageReceived { get; private set; }

        public void NotifyTransactionResult(string resultMessage)
        {
            MessageReceived = resultMessage;
        }
    }
}

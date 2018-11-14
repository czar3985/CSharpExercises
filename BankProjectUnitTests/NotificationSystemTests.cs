using BankProject;
using BankProjectUnitTests.Mocks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BankProjectUnitTests
{
    [TestClass]
    public class NotificationSystemTests
    {
        [TestMethod]
        public void NotifierTest()
        {
            NotificationSystem notificationSystem = new NotificationSystem();
            MockNotifier mockSmsNotifier = new MockNotifier();
            MockNotifier mockEmailNotifier = new MockNotifier();

            notificationSystem.SMSNotifier = mockSmsNotifier;
            notificationSystem.EmailNotifier = mockEmailNotifier;

            notificationSystem.NotifyTransactionResult("Test Message");
            Assert.AreEqual("Test Message", mockSmsNotifier.MessageReceived);
            Assert.AreEqual("Test Message", mockEmailNotifier.MessageReceived);
        }
    }
}

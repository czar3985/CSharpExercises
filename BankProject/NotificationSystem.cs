using System;
using System.Collections.Generic;
using System.Text;

namespace BankProject
{
    interface INotificationSystem
    {
        void NotifyTransactionResult(string resultMessage);
    }

    class NotificationSystem : INotificationSystem
    {
        private SMSNotifier _smsNotifier;
        private EmailNotifier _emailNotifier;

        public NotificationSystem()
        {
            _smsNotifier = new SMSNotifier();
            _emailNotifier = new EmailNotifier();
        }

        public void NotifyTransactionResult(string resultMessage)
        {
            Console.WriteLine(resultMessage);
            _smsNotifier.NotifyTransactionResult(resultMessage);
            _emailNotifier.NotifyTransactionResult(resultMessage);
        }
    }

    interface INotifier
    {
        void NotifyTransactionResult(string resultMessage);
    }

    class SMSNotifier : INotifier
    {
        public void NotifyTransactionResult(string resultMessage)
        {
            Console.WriteLine($"SMS message: {resultMessage}");
        }
    }

    class EmailNotifier : INotifier
    {
        public void NotifyTransactionResult(string resultMessage)
        {
            Console.WriteLine($"Email message: {resultMessage}");
        }
    }
}

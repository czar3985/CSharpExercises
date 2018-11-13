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
        public void NotifyTransactionResult(string resultMessage)
        {
            Console.WriteLine(resultMessage);
        }
    }

    class SMSNotifier
    {

    }

    class EmailNotifier
    {

    }
}

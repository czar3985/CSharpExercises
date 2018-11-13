using System;
using System.Collections.Generic;
using System.Text;

namespace BankProject
{
    interface IBank
    {
        void Deposit(double amount);
        void Withdraw(double amount);
    }

    class Bank: IBank
    {
        public INotificationSystem NotificationSystem { get; set; }

        private Bank()
        {
            NotificationSystem = new NotificationSystem();
        }

        private static Bank _instance;
        public static Bank Instance {
            get {
                if (_instance == null)
                    _instance = new Bank();
                return _instance;
            }
        }

        public double Balance { get; private set; }

        public void Deposit(double amount)
        {
            string resultMessage = "";

            Balance += amount;

            resultMessage = $"Deposit of {amount} was successful. Balance is {Balance}.";
            NotificationSystem.NotifyTransactionResult(resultMessage);

        }

        public void Withdraw(double amount)
        {
            string resultMessage = "";

            if (Balance < amount)
            {
                resultMessage = $"Withdrawal of {amount} failed. There wasn't enough funds. Balance is {Balance}.";
                NotificationSystem.NotifyTransactionResult(resultMessage);
            }
            else
            {
                Balance -= amount;

                resultMessage = $"Withdrawal of {amount} was successful. Balance is {Balance}.";
                NotificationSystem.NotifyTransactionResult(resultMessage);
            }
        }
    }
}

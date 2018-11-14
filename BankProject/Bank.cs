namespace BankProject
{
    public interface IBank
    {
        void Deposit(double amount, IBankAccessor accessor);
        void Withdraw(double amount, IBankAccessor accessor);
    }

    public class Bank: IBank
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

        public void Deposit(double amount, IBankAccessor accessor)
        {
            string resultMessage = "";

            Balance += amount;

            resultMessage = $"Deposit of {amount} to {accessor.AccessorType} was successful. " +
                $"Balance is {Balance}.";
            NotificationSystem.NotifyTransactionResult(resultMessage);

        }

        public void Withdraw(double amount, IBankAccessor accessor)
        {
            string resultMessage = "";

            if (Balance < amount)
            {
                resultMessage = $"Withdrawal of {amount} from {accessor.AccessorType} failed. " +
                    $"There wasn't enough funds. Balance is {Balance}.";
                NotificationSystem.NotifyTransactionResult(resultMessage);
            }
            else
            {
                Balance -= amount;

                resultMessage = $"Withdrawal of {amount} from {accessor.AccessorType} was successful. " +
                    $"Balance is {Balance}.";
                NotificationSystem.NotifyTransactionResult(resultMessage);
            }
        }

        public static void ClearInstance()
        {
            // to be used only for unit testing
            _instance = null;
        }
    }
}

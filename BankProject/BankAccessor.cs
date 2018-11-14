namespace BankProject
{
    public interface IBankAccessor
    {
        string AccessorType { get; }

        void Deposit(double amount);
        void Withdraw(double amount);
    }

    public class Teller: IBankAccessor
    {
        private IBank _bankInstance;

        public IBank BankInstance {
            get {
                if (_bankInstance == null)
                    _bankInstance = Bank.Instance;
                return _bankInstance;
            }
            set {
                _bankInstance = value;
            }
        }

        public Teller()
        {
            BankInstance = Bank.Instance;
        }

        public string AccessorType => "Teller";

        public void Deposit(double amount)
        {
            BankInstance.Deposit(amount, this);

        }

        public void Withdraw(double amount)
        {
            BankInstance.Withdraw(amount, this);
        }
    }

    public class ATM : IBankAccessor
    {
        private IBank _bankInstance;
        public IBank BankInstance {
            get {
                if (_bankInstance == null)
                    _bankInstance = Bank.Instance;
                return _bankInstance;
            }
            set {
                _bankInstance = value;
            }
        }

        public ATM()
        {
            BankInstance = Bank.Instance;
        }

        public string AccessorType => "ATM";

        public void Deposit(double amount)
        {
            BankInstance.Deposit(amount, this);
        }

        public void Withdraw(double amount)
        {
            BankInstance.Withdraw(amount, this);
        }
    }
}

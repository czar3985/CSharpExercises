namespace BankProject
{
    interface IBankAccessor
    {
        string AccessorType { get; }

        void Deposit(double amount);
        void Withdraw(double amount);
    }

    class Teller: IBankAccessor
    {
        private IBank _bank;
        //public IBank BankInterface {
        //    get {
        //        if (_bank == null)
        //            _bank = Bank.Instance;
        //        return _bank;
        //    }
        //    set {
        //        _bank = value;
        //    }
        //}

        public Teller()
        {
            _bank = Bank.Instance;
        }

        public string AccessorType => "Teller";

        public void Deposit(double amount)
        {
            _bank.Deposit(amount, this);

        }

        public void Withdraw(double amount)
        {
            _bank.Withdraw(amount, this);
        }
    }

    class ATM : IBankAccessor
    {
        private IBank _bank;
        //public IBank BankInterface {
        //    get {
        //        if (_bank == null)
        //            _bank = Bank.Instance;
        //        return _bank;
        //    }
        //    set {
        //        _bank = value;
        //    }
        //}

        public ATM()
        {
            _bank = Bank.Instance;
        }

        public string AccessorType => "ATM";

        public void Deposit(double amount)
        {
            _bank.Deposit(amount, this);
        }

        public void Withdraw(double amount)
        {
            _bank.Withdraw(amount, this);
        }
    }
}

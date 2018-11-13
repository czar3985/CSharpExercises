using System;
using System.Collections.Generic;
using System.Text;

namespace BankProject
{
    interface IBankAccessor
    {
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

        public void Deposit(double amount)
        {
            _bank.Deposit(amount);

        }

        public void Withdraw(double amount)
        {
            _bank.Withdraw(amount);
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

        public void Deposit(double amount)
        {
            _bank.Deposit(amount);
        }

        public void Withdraw(double amount)
        {
            _bank.Withdraw(amount);
        }
    }
}

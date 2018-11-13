using System;
using System.Collections.Generic;
using System.Text;

namespace BankProject
{
    class UIInteraction
    {
        private bool _isBankOpen = true;
        public IBankAccessor Teller { get; set; }
        public IBankAccessor ATM { get; set; }

        public UIInteraction()
        {
            Teller = new Teller();
            ATM = new ATM();
        }

        public void OperateBank()
        {
            ShowBankInstructions();

            while (_isBankOpen)
            {
                string transactionInput = "";

                Console.WriteLine("");
                Console.WriteLine("Enter transaction:");
                transactionInput = Console.ReadLine();
                var splitInput = transactionInput.Split(' ');

                // TODO: input checking

                switch(splitInput[0].ToLower())
                {
                    case "t":
                        if (splitInput[1] == "d")
                            Teller.Deposit(Double.Parse(splitInput[2]));
                        else if (splitInput[1] == "w")
                            Teller.Withdraw(Double.Parse(splitInput[2]));
                        break;
                    case "a":
                        if (splitInput[1] == "d")
                            ATM.Deposit(Double.Parse(splitInput[2]));
                        else if (splitInput[1] == "w")
                            ATM.Withdraw(Double.Parse(splitInput[2]));
                        break;
                    case "q":
                        BankIsClosed();
                        break;
                    default:
                        break;
                }
            }
        }

        private static void ShowBankInstructions()
        {
            Console.WriteLine("Enter transaction: t/a(Teller or ATM) d/w(Deposit or Withdrawal) Amount");
            Console.WriteLine("Type q to Quit");
            Console.WriteLine("Ex. t d 100");
        }

        private void BankIsClosed()
        {
            Console.WriteLine("Goodbye.");
            _isBankOpen = false;
        }
    }
}

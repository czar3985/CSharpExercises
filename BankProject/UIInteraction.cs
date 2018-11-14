using System;

namespace BankProject
{
    public interface IInput
    {
        string ReadLine();
    }

    public interface IOutput
    {
        void WriteLine(string message);
    }

    public class Input : IInput
    {
        public string ReadLine()
        {
            return Console.ReadLine();
        }
    }

    public class Output : IOutput
    {
        public void WriteLine(string message)
        {
            Console.WriteLine(message);
        }
    }

    class UIInteraction
    {
        private bool _isBankOpen = true;
        public IBankAccessor Teller { get; set; }
        public IBankAccessor ATM { get; set; }
        public IInput Input { get; set; }
        public IOutput Output { get; set; }

        public UIInteraction()
        {
            Teller = new Teller();
            ATM = new ATM();
            Input = new Input();
            Output = new Output();
        }

        public void OperateBank()
        {
            ShowBankInstructions();

            while (_isBankOpen)
            {
                string transactionInput = "";

                Output.WriteLine("");
                Output.WriteLine("Enter transaction:");
                transactionInput = Input.ReadLine();
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

        private void ShowBankInstructions()
        {
            Output.WriteLine("Enter transaction: t/a(Teller or ATM) d/w(Deposit or Withdrawal) Amount");
            Output.WriteLine("Type q to Quit");
            Output.WriteLine("Ex. t d 100");
        }

        private void BankIsClosed()
        {
            Output.WriteLine("Goodbye.");
            _isBankOpen = false;
        }
    }
}

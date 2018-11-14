using System;

namespace BankProject
{
    public interface INotificationSystem
    {
        void NotifyTransactionResult(string resultMessage);
    }

    public class NotificationSystem : INotificationSystem
    {
        private INotifier _smsNotifier = null;
        public INotifier SMSNotifier {
            get {
                if (_smsNotifier == null)
                    _smsNotifier = new SMSNotifier();
                return _smsNotifier;
            }
            set {
                _smsNotifier = value;
            }
        }

        private INotifier _emailNotifier = null;
        public INotifier EmailNotifier {
            get {
                if (_emailNotifier == null)
                    _emailNotifier = new EmailNotifier();
                return _emailNotifier;
            }
            set {
                _emailNotifier = value;
            }
        }

        private IOutput _output = null;
        public IOutput Output {
            get {
                if (_output == null)
                    _output = new Output();
                return _output;
            }
            set {
                _output = value;
            }
       }

        public void NotifyTransactionResult(string resultMessage)
        {
            Output.WriteLine(resultMessage);
            SMSNotifier.NotifyTransactionResult(resultMessage);
            EmailNotifier.NotifyTransactionResult(resultMessage);
        }
    }

    public interface INotifier
    {
        void NotifyTransactionResult(string resultMessage);
    }

    class SMSNotifier : INotifier
    {
        public IOutput Output { get; set; }

        public SMSNotifier()
        {
            Output = new Output();
        }

        public void NotifyTransactionResult(string resultMessage)
        {
            Output.WriteLine($"SMS message: {resultMessage}");
        }
    }

    class EmailNotifier : INotifier
    {
        public IOutput Output { get; set; }

        public EmailNotifier()
        {
            Output = new Output();
        }

        public void NotifyTransactionResult(string resultMessage)
        {
            Output.WriteLine($"Email message: {resultMessage}");
        }
    }
}

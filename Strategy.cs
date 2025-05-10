using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonDesignPatterns
{
    internal class Strategy
    {
    }

    // Strategy Interface Components
    interface IPaymentStrategy
    {
        void Pay(decimal amount);
    }


    // Concrete Strategies Components
    internal class CreditCardPayment:IPaymentStrategy
    {
        public void Pay(decimal amount)
        {
            Console.WriteLine($"Pay as credit card, the amount is: {amount}");
        }
    }

    // Concrete Strategies Components
    internal class CryptoPayment:IPaymentStrategy
    {
        public void Pay(decimal amount)
        {
            Console.WriteLine($"Pay as crypto, the amount is: {amount}");
        }
    }

    // Context(uses strategy) Components
    internal class CheckoutProcessor
    {
        private  IPaymentStrategy _paymentStrategy;
        public CheckoutProcessor(IPaymentStrategy paymentStrategy)
        {
            _paymentStrategy=paymentStrategy;
        }

        public void SetStrategy(IPaymentStrategy setStrategy)
        {
            _paymentStrategy=setStrategy;
        }

        public void Pay(decimal amount)
        {
            _paymentStrategy.Pay(amount);
        }
    }

}

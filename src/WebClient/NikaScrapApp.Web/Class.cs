namespace LSPDemo
{
    public abstract class BankAccount
    {
        protected double balance;
        public virtual void Deposit(double amount)
        {
            balance += amount;
            Console.WriteLine($"Deposit: {amount}, Total Amount: {balance}");
        }
        public abstract void Withdraw(double amount);
        public double GetBalance()
        {
            return balance;
        }
    }
    public class RegularAccount : BankAccount
    {
        public override void Withdraw(double amount)
        {
            if (balance >= amount)
            {
                balance -= amount;
                Console.WriteLine($"Withdraw: {amount}, Balance: {balance}");
            }
            else
            {
                Console.WriteLine($"Trying to Withdraw: {amount}, Insufficient Funds, Available Funds: {balance}");
            }
        }
    }
    public class FixedTermDepositAccount : BankAccount
    {
        private bool termEnded = false; // simplification for the example
        public override void Withdraw(double amount)
        {
            if (!termEnded)
            {
                Console.WriteLine("Cannot withdraw from a fixed term deposit account until term ends");
            }
            else if (balance >= amount)
            {
                balance -= amount;
                Console.WriteLine($"Withdraw: {amount}, Balance: {balance}");
            }
            else
            {
                Console.WriteLine($"Trying to Withdraw: {amount}, Insufficient Funds, Available Funds: {balance}");
            }
        }
    }

    //Testing the Liskov Substitution Principle
    public class Program
    {
        public static void Main()
        {
            Console.WriteLine("RegularAccount:");
            var RegularBankAccount = new RegularAccount();
            RegularBankAccount.Deposit(1000);
            RegularBankAccount.Deposit(500);
            RegularBankAccount.Withdraw(900);
            RegularBankAccount.Withdraw(800);
            Console.WriteLine("\nFixedTermDepositAccount:");
            var FixedTermDepositBankAccount = new FixedTermDepositAccount();
            FixedTermDepositBankAccount.Deposit(1000);
            FixedTermDepositBankAccount.Withdraw(500);

            Console.ReadKey();
        }
    }
}
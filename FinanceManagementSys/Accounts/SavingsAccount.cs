using FinanceManagementSystem.Models;

namespace FinanceManagementSystem.Accounts;

public sealed class SavingsAccount : Account
{
    public SavingsAccount(string accountNumber, decimal initialBalance) 
        : base(accountNumber, initialBalance)
    {
    }

    public override void ApplyTransaction(Transaction transaction, string currency)
    {
        if (transaction.Amount > Balance)
        {
            Console.WriteLine($"Insufficient funds ({currency})");
            return;
        }

        Balance -= transaction.Amount;
        Console.WriteLine($"Savings account transaction applied: {transaction.Amount} {currency} deducted from account {AccountNumber}");
        Console.WriteLine($"Updated balance: {Balance} {currency}");
    }
}

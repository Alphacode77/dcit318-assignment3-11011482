using FinanceManagementSystem.Models;

namespace FinanceManagementSystem.Accounts;

public class Account
{
    public string AccountNumber { get; set; }
    public decimal Balance { get; protected set; }

    public Account(string accountNumber, decimal initialBalance)
    {
        AccountNumber = accountNumber;
        Balance = initialBalance;
    }

    public virtual void ApplyTransaction(Transaction transaction, string currency)
    {
        Balance -= transaction.Amount;
        Console.WriteLine($"Transaction applied: {transaction.Amount} {currency} deducted from account {AccountNumber}");
        Console.WriteLine($"Current balance: {Balance} {currency}");
    }
}

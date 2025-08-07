using FinanceManagementSystem.Interfaces;
using FinanceManagementSystem.Models;

namespace FinanceManagementSystem.Processors;

public class BankTransferProcessor : ITransactionProcessor
{
    private readonly string _currency;
    public BankTransferProcessor(string currency)
    {
        _currency = currency;
    }
    public void Process(Transaction transaction)
    {
        Console.WriteLine($"Bank Transfer: Processing transaction of {transaction.Amount} {_currency} for {transaction.Category}");
        Console.WriteLine($"Transaction ID: {transaction.Id}, Date: {transaction.Date:yyyy-MM-dd}");
    }
}

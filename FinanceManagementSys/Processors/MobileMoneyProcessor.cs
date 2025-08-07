using FinanceManagementSystem.Interfaces;
using FinanceManagementSystem.Models;

namespace FinanceManagementSystem.Processors;

public class MobileMoneyProcessor : ITransactionProcessor
{
    private readonly string _currency;
    public MobileMoneyProcessor(string currency)
    {
        _currency = currency;
    }
    public void Process(Transaction transaction)
    {
        Console.WriteLine($"Mobile Money: Processing transaction of {transaction.Amount} {_currency} for {transaction.Category}");
        Console.WriteLine($"Transaction ID: {transaction.Id}, Date: {transaction.Date:yyyy-MM-dd}");
    }
}

using FinanceManagementSystem.Accounts;
using FinanceManagementSystem.Interfaces;
using FinanceManagementSystem.Models;
using FinanceManagementSystem.Processors;

namespace FinanceManagementSystem;

public class FinanceApp
{
    private List<Transaction> _transactions = new();
    private string _currency = "USD";

    public void Run()
    {
        Console.WriteLine("Welcome to the Finance Management System");
        Console.WriteLine();

        // Get account details from user
        Console.Write("Enter account number: ");
        string? accountNumberInput = Console.ReadLine();
        string accountNumber = string.IsNullOrWhiteSpace(accountNumberInput) ? "SA001" : accountNumberInput;
        
        // Ask for currency type
        Console.Write("Enter currency for this account (e.g., USD, GHS, BTC, Pi): ");
        string currencyInput = Console.ReadLine();
        if (!string.IsNullOrWhiteSpace(currencyInput))
            _currency = currencyInput.Trim();

        // Display balance (initially zero) after account number input
        decimal initialBalance = 0;
        Console.WriteLine($"Account {accountNumber} created. Current balance: 0 {_currency}");

        // Ask for initial balance
        Console.Write($"Enter initial balance ({_currency}): ");
        while (!decimal.TryParse(Console.ReadLine(), out initialBalance) || initialBalance < 0)
        {
            Console.Write($"Please enter a valid positive amount ({_currency}): ");
        }

        // Create savings account
        var savingsAccount = new SavingsAccount(accountNumber, initialBalance);
        Console.WriteLine($"Created savings account: {savingsAccount.AccountNumber} with initial balance: {savingsAccount.Balance} {_currency}");
        Console.WriteLine();

        // Get transaction details from user
        var transactions = GetTransactionsFromUser();

        // Process transactions
        Console.WriteLine("Processing transactions:");
        ProcessTransactions(transactions);

        // Apply transactions to account
        Console.WriteLine("Applying transactions to savings account:");
        ApplyTransactionsToAccount(savingsAccount, transactions);

        // Display summary
        DisplaySummary(savingsAccount);
    }

    private List<Transaction> GetTransactionsFromUser()
    {
        var transactions = new List<Transaction>();
        int transactionId = 1;

        Console.WriteLine($"Enter transaction details (press Enter with empty amount to finish, currency: {_currency}):");
        Console.WriteLine();

        while (true)
        {
            Console.Write($"Transaction {transactionId} - Amount ({_currency}): ");
            string amountInput = Console.ReadLine() ?? "";
            
            if (string.IsNullOrWhiteSpace(amountInput))
                break;

            if (!decimal.TryParse(amountInput, out decimal amount) || amount <= 0)
            {
                Console.WriteLine($"Please enter a valid positive amount ({_currency}).");
                continue;
            }

            Console.Write($"Transaction {transactionId} - Category: ");
            string category = Console.ReadLine() ?? "General";

            var transaction = new Transaction(transactionId, DateTime.Now, amount, category);
            transactions.Add(transaction);
            transactionId++;
            Console.WriteLine();
        }

        return transactions;
    }

    private void ProcessTransactions(List<Transaction> transactions)
    {
        // Define crypto currencies
        var cryptoCurrencies = new[] { "BTC", "ETH", "Pi", "XRP", "ADA", "DOT", "LINK", "LTC", "BCH", "XLM" };
        bool isCryptoCurrency = cryptoCurrencies.Contains(_currency.ToUpper());

        if (isCryptoCurrency)
        {
            var cryptoProcessor = new CryptoWalletProcessor(_currency);
            foreach (var transaction in transactions)
            {
                cryptoProcessor.Process(transaction);
                Console.WriteLine();
            }
        }
        else
        {
            var bankProcessor = new BankTransferProcessor(_currency);
            var mobileProcessor = new MobileMoneyProcessor(_currency);

            for (int i = 0; i < transactions.Count; i++)
            {
                if (i % 2 == 0)
                {
                    bankProcessor.Process(transactions[i]);
                }
                else
                {
                    mobileProcessor.Process(transactions[i]);
                }
                Console.WriteLine();
            }
        }
    }

    private void ApplyTransactionsToAccount(SavingsAccount account, List<Transaction> transactions)
    {
        foreach (var transaction in transactions)
        {
            account.ApplyTransaction(transaction, _currency);
            _transactions.Add(transaction);
            Console.WriteLine();
        }
    }

    private void DisplaySummary(SavingsAccount account)
    {
        Console.WriteLine($"Total transactions stored: {_transactions.Count}");
        Console.WriteLine($"Final account balance: {account.Balance} {_currency}");
        
        if (_transactions.Count > 0)
        {
            Console.WriteLine();
            Console.WriteLine("Transaction Summary:");
            foreach (var transaction in _transactions)
            {
                Console.WriteLine($"- {transaction.Amount} {_currency} for {transaction.Category} (ID: {transaction.Id})");
            }
        }
    }
}

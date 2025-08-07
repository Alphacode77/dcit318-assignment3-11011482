# Finance Management System

A comprehensive C# finance management system that tracks transactions, enforces data integrity, and supports multiple transaction types and account behaviors. The system integrates interfaces, records, and sealed classes to achieve modularity, immutability, and inheritance control.

## Features

- **Transaction Tracking**: Record and manage financial transactions with immutable data structures
- **Multiple Payment Processors**: Support for bank transfers, mobile money, and crypto wallet transactions
- **Account Management**: Base account class with specialized savings account implementation
- **Data Integrity**: Proper encapsulation and validation to ensure data consistency
- **Modular Design**: Clean separation of concerns using interfaces and inheritance
- **Interactive User Input**: Enter account number, select currency, and input transactions interactively
- **Currency Support**: Choose any currency (e.g., USD, GHS, BTC, Pi) for all transactions and balances

## Project Structure

```
FinanceManagementSys/
├── Models/
│   └── Transaction.cs              # Transaction record with immutable properties
├── Interfaces/
│   └── ITransactionProcessor.cs    # Interface for transaction processing
├── Processors/
│   ├── BankTransferProcessor.cs    # Bank transfer transaction processor
│   ├── MobileMoneyProcessor.cs     # Mobile money transaction processor
│   └── CryptoWalletProcessor.cs    # Crypto wallet transaction processor
├── Accounts/
│   ├── Account.cs                  # Base account class
│   └── SavingsAccount.cs           # Sealed savings account implementation
├── FinanceApp.cs                   # Main application logic
├── Program.cs                      # Application entry point
└── FinanceManagementSystem.csproj  # Project configuration
```

## Core Components

### Transaction Model

The `Transaction` record represents financial data with the following properties:

- `int Id`: Unique transaction identifier
- `DateTime Date`: Transaction date and time
- `decimal Amount`: Transaction amount
- `string Category`: Transaction category (e.g., "Groceries", "Utilities", "Entertainment")

### Transaction Processors

Three concrete implementations of `ITransactionProcessor` interface with automatic currency allocation:

1. **BankTransferProcessor**: Handles bank transfer transactions for local currencies
2. **MobileMoneyProcessor**: Processes mobile money transactions for local currencies
3. **CryptoWalletProcessor**: Manages cryptocurrency wallet transactions for crypto currencies

**Currency Allocation Logic:**

- **Local Currencies** (USD, GHS, EUR, etc.): Automatically processed by Bank Transfer and Mobile Money processors (alternating)
- **Crypto Currencies** (BTC, ETH, Pi, XRP, ADA, DOT, LINK, LTC, BCH, XLM): Automatically processed by Crypto Wallet processor only

Each processor provides a distinct implementation of the `Process` method, displaying transaction details including amount, category, ID, date, and the selected currency.

### Account Classes

#### Base Account Class

- `string AccountNumber`: Account identifier
- `decimal Balance`: Current account balance (protected setter for encapsulation)
- Constructor: Accepts account number and initial balance
- `virtual void ApplyTransaction(Transaction transaction, string currency)`: Deducts transaction amount from balance and displays currency

#### Savings Account Class

- Inherits from `Account` class
- Sealed class to prevent further inheritance
- Overrides `ApplyTransaction` method with insufficient funds validation
- Displays "Insufficient funds" message if transaction amount exceeds balance, including currency

### Finance Application

The `FinanceApp` class orchestrates the entire system:

- Maintains a list of transactions (`_transactions`)
- `Run()` method demonstrates system functionality:
  1. Prompts for account number
  2. Prompts for currency (e.g., USD, GHS, BTC, Pi)
  3. Displays balance (initially zero) after account number input
  4. Prompts for initial balance (in selected currency)
  5. Generates transactions interactively (amount and category, in selected currency)
  6. Processes transactions using appropriate processors based on currency type:
     - Local currencies: Bank Transfer and Mobile Money (alternating)
     - Crypto currencies: Crypto Wallet only
  7. Applies transactions to the savings account (with currency)
  8. Stores all transactions in the collection
  9. Displays a summary with all amounts in the selected currency

## Requirements

- .NET 8.0 or later
- C# 12.0 or later (for record types)

## Installation and Setup

1. **Clone or Download**: Ensure you have the project files in your local directory

2. **Navigate to Project Directory**:

   ```bash
   cd FinanceManagementSys
   ```

3. **Restore Dependencies**:

   ```bash
   dotnet restore
   ```

4. **Build the Project**:

   ```bash
   dotnet build
   ```

5. **Run the Application**:

   ```bash
   dotnet run
   ```

## Usage

The application is fully interactive and demonstrates:

1. **Account Creation**: Enter an account number, select a currency, and specify an initial balance
2. **Transaction Processing**: Enter as many transactions as you like (amount and category, in the selected currency)
3. **Balance Updates**: Applies transactions to the savings account and displays updated balances in the selected currency
4. **Transaction Storage**: Maintains a collection of all processed transactions
5. **Summary**: Shows all transactions and the final balance in the selected currency

## Sample Output

```
Welcome to the Finance Management System

Enter account number: SA001
Enter currency for this account (e.g., USD, GHS, BTC, Pi): GHS
Account SA001 created. Current balance: 0 GHS
Enter initial balance (GHS): 1000
Created savings account: SA001 with initial balance: 1000 GHS

Enter transaction details (press Enter with empty amount to finish, currency: GHS):

Transaction 1 - Amount (GHS): 150
Transaction 1 - Category: Groceries

Transaction 2 - Amount (GHS): 200
Transaction 2 - Category: Utilities

Transaction 3 - Amount (GHS): 75
Transaction 3 - Category: Entertainment

Processing transactions:
Bank Transfer: Processing transaction of 150 GHS for Groceries
Transaction ID: 1, Date: 2025-08-07

Mobile Money: Processing transaction of 200 GHS for Utilities
Transaction ID: 2, Date: 2025-08-07

Bank Transfer: Processing transaction of 75 GHS for Entertainment
Transaction ID: 3, Date: 2025-08-07

Applying transactions to savings account:

Savings account transaction applied: 150 GHS deducted from account SA001
Updated balance: 850 GHS

Savings account transaction applied: 200 GHS deducted from account SA001
Updated balance: 650 GHS

Savings account transaction applied: 75 GHS deducted from account SA001
Updated balance: 575 GHS

Total transactions stored: 3
Final account balance: 575 GHS

Transaction Summary:
- 150 GHS for Groceries (ID: 1)
- 200 GHS for Utilities (ID: 2)
- 75 GHS for Entertainment (ID: 3)

**Note**: For crypto currencies (like BTC, Pi), all transactions would be processed by Crypto Wallet only.
```

## Design Patterns and Principles

### Immutability

- Uses C# records for transaction data to ensure immutability
- Prevents accidental modification of transaction properties

### Interface Segregation

- `ITransactionProcessor` interface defines a single responsibility
- Allows for easy extension with new processor types

### Inheritance Control

- Base `Account` class provides common functionality
- Sealed `SavingsAccount` prevents further inheritance
- Virtual methods allow for polymorphic behavior

### Encapsulation

- Protected setters ensure proper data access control
- Private fields maintain internal state integrity

### Modularity

- Separate classes for different responsibilities
- Clean separation between models, processors, and accounts

## Extending the System

### Adding New Transaction Types

1. Create a new class implementing `ITransactionProcessor`
2. Implement the `Process` method with specific logic
3. Use the new processor in the `FinanceApp`

### Adding New Account Types

1. Create a new class inheriting from `Account`
2. Override `ApplyTransaction` method if needed
3. Implement account-specific validation logic

### Adding New Transaction Categories

1. Modify the `Transaction` record if needed
2. Update the `FinanceApp` to create transactions with new categories

## Error Handling

The system includes basic error handling:

- Insufficient funds validation in `SavingsAccount` (with currency)
- Proper null checking and validation
- Graceful handling of invalid transaction amounts

## Performance Considerations

- Records provide efficient value-based equality
- Minimal memory allocation with immutable data structures
- Efficient list operations for transaction storage

## Testing

To test the system with different scenarios:

1. **Modify Transaction Amounts**: Change the amounts in the interactive prompts to test insufficient funds scenarios
2. **Add New Processors**: Implement additional `ITransactionProcessor` implementations
3. **Test Different Categories**: Enter different transaction categories to test various use cases

## Troubleshooting

### Build Issues

- Ensure .NET 8.0 SDK is installed
- Run `dotnet restore` to resolve dependency issues
- Check for syntax errors in C# files

### Runtime Issues

- Verify all required files are present in the project structure
- Check console output for error messages
- Ensure proper file permissions

## License

This project is provided as educational material for learning C# programming concepts including interfaces, records, inheritance, and sealed classes.

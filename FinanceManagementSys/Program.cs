using FinanceManagementSystem;

namespace FinanceManagementSystem;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Finance Management System");
        Console.WriteLine();

        var financeApp = new FinanceApp();
        financeApp.Run();
    }
}

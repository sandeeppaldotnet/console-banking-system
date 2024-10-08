using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banking_System
{
    internal class Program
    {
        private static Dictionary<int, BankAccount> accounts = new Dictionary<int, BankAccount>();
        private static int nextAccountId = 1;
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("\nWelcome to the Banking System");
                Console.WriteLine("1. Create Account");
                Console.WriteLine("2. Deposit Money");
                Console.WriteLine("3. Withdraw Money");
                Console.WriteLine("4. Check Balance");
                Console.WriteLine("5. Exit");
                Console.Write("Please select an option: ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        CreateAccount();
                        break;
                    case "2":
                        PerformTransaction("deposit");
                        break;
                    case "3":
                        PerformTransaction("withdraw");
                        break;
                    case "4":
                        CheckAccountBalance();
                        break;
                    case "5":
                        Console.WriteLine("Thank you for using the Banking System!");
                        return;
                    default:
                        Console.WriteLine("Invalid option. Please try again.");
                        break;
                }
            }
        }
        static void CreateAccount()
        {
            Console.Write("Enter account holder's name: ");
            string name = Console.ReadLine();

            Console.Write("Enter initial deposit amount: ");
            decimal initialDeposit;
            while (!decimal.TryParse(Console.ReadLine(), out initialDeposit) || initialDeposit <= 0)
            {
                Console.Write("Invalid amount. Please enter a positive number: ");
            }

            BankAccount newAccount = new BankAccount(nextAccountId, name, initialDeposit);
            accounts[nextAccountId] = newAccount;
            Console.WriteLine($"Account created successfully! Account ID: {nextAccountId}");
            nextAccountId++;
        }

        static void PerformTransaction(string transactionType)
        {
            Console.Write("Enter account ID: ");
            int accountId;
            while (!int.TryParse(Console.ReadLine(), out accountId) || !accounts.ContainsKey(accountId))
            {
                Console.Write("Invalid account ID. Please try again: ");
            }

            Console.Write($"Enter amount to {transactionType}: ");
            decimal amount;
            while (!decimal.TryParse(Console.ReadLine(), out amount) || amount <= 0)
            {
                Console.Write($"Invalid amount. Please enter a positive number: ");
            }

            if (transactionType == "deposit")
            {
                accounts[accountId].Deposit(amount);
            }
            else if (transactionType == "withdraw")
            {
                accounts[accountId].Withdraw(amount);
            }
        }

        static void CheckAccountBalance()
        {
            Console.Write("Enter account ID: ");
            int accountId;
            while (!int.TryParse(Console.ReadLine(), out accountId) || !accounts.ContainsKey(accountId))
            {
                Console.Write("Invalid account ID. Please try again: ");
            }

            accounts[accountId].CheckBalance();
        }
    }
}

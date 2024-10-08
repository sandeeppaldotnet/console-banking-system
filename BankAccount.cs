using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banking_System
{
  
    internal class BankAccount
    {
      
        public int AccountId { get; private set; }
        public string HolderName { get; private set; }
        public decimal Balance { get; private set; }
       
        public BankAccount(int accountId, string holderName, decimal initialDeposit)
        {
            AccountId = accountId;
            HolderName = holderName;
            Balance = initialDeposit;
        }
       //Mehtod Deposit Money
        public void Deposit(decimal amount)
        {
            if (amount > 0) 
            {
                Balance += amount; 
                Console.WriteLine($"Successfully deposited {amount:C}. New balance: {Balance:C}");
            }
            else
            {
                Console.WriteLine("Deposit amount must be greater than zero.");
            }
        }
        // Method to withdraw money 
        public void Withdraw(decimal amount)
        {
            if (amount > 0 && amount <= Balance) 
            {
                Balance -= amount; 
                Console.WriteLine($"Successfully withdrew {amount:C}. New balance: {Balance:C}");
            }
            else if (amount > Balance)
            {
                Console.WriteLine("Insufficient funds for withdrawal.");
            }
            else
            {
                Console.WriteLine("Withdrawal amount must be greater than zero.");
            }
        }
        // Method to check the current balance 
        public void CheckBalance()
        {
            Console.WriteLine($"Current balance for account ID {AccountId}: {Balance:C}");
        }
    }
}

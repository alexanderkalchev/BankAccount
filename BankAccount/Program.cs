using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAccount
{
    internal class Program
    {

        static void Action(List<BankAccount> accounts, string[] cmdArgs, string type) 
        {
            bool found = false;
            int id = int.Parse(cmdArgs[1]);
            decimal amount = decimal.Parse(cmdArgs[2]);
            foreach (BankAccount account in accounts)
            {
                if (account.Id == id)
                {
                    if(type == "deposit") account.Deposit(amount);
                    if (type == "withdraw") account.Withdraw(amount);

                    found = true;
                };
            }
            if (!found) Console.WriteLine("No such bank account!");
        }

        static void Print(List<BankAccount> accounts, string[] cmdArgs) 
        {
            int id = int.Parse(cmdArgs[1]);
            foreach (BankAccount account in accounts)
            {
                if (account.Id == id) 
                {
                    Console.WriteLine($"ID: {id}, balance: {account.Balance}");
                    return;
                }
            }
            Console.WriteLine("No such bank account!");
        }

        static void List(List<BankAccount> accounts) 
        {
            foreach (BankAccount account in accounts)
            {
                Console.WriteLine($"Bank account: \nId:{account.Id}");
            }
        }

        static void Main(string[] args)
        {
            List<BankAccount> accounts = new List<BankAccount>();
            string input;
            while (true)
            {
                input = Console.ReadLine();
                string[] cmdArgs = input.Split(' ');
                switch (cmdArgs[0].ToLower())
                {
                    case "create":
                        accounts.Add(new BankAccount());
                        Console.WriteLine("Bank account created.");
                        break;
                    case "deposit":
                        Action(accounts, cmdArgs, "deposit");
                        break;
                    case "withdraw":
                        Action(accounts, cmdArgs, "withdraw");
                        break;
                    case "print":
                        Print(accounts, cmdArgs);
                        break;
                    case "list":
                        List(accounts);
                        break;
                    default:
                        break;
                }
            }
        }
    }
}

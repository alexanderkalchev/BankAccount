using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAccount
{
    class BankAccount
    {

        public static int bankAccounts = 0;

        private int id;
        private decimal balance;

        public int Id 
        {
            get 
            {
                return this.id;
            }
            set 
            {
                if (value >= 0) this.id = value;
                else throw new Exception("ГРЕШКА ID");
            }
        }

        public decimal Balance { get; private set; }

        public BankAccount() 
        {
            this.Id = bankAccounts;
            this.Balance = 0;
            bankAccounts++;
        }

        public void Deposit(decimal amount) 
        {
            this.Balance += amount;
        }

        public void Withdraw(decimal amount) 
        {
            this.Balance -= amount;
        }
    }
}

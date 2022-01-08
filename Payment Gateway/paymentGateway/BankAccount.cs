using Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Class
{
    public class BankAccount : Account
    {
        private StringBuilder activities = new StringBuilder();
        public enum Currencies
        {
            USD,
            CAD
        }
        private Currencies currentCurrency;
        public double totalAmount = 0;
        public BankAccount(Currencies currency, List<User> owners) : base(owners)
        {
            currentCurrency = currency;
        }

        public override void Deposit(double amount)
        {
            totalAmount += amount;
            activities.Append("Deposit: " + currentCurrency.ToString() + " " + amount + "\tTotal Amount: " + currentCurrency.ToString() + " " + totalAmount + "\n");

        }
        public override void Withdraw(double amount)
        {
            totalAmount = totalAmount - amount;
            if (amount<totalAmount)
            {
                activities.Append("Withdraw: " + currentCurrency.ToString() + " " + amount + "\tTotal Amount: " + currentCurrency.ToString() + " " + totalAmount + "\n");

            }
        }

        public override string Statement()
        {
            return activities.ToString();
        }

       
    }
}

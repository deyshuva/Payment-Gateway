using Class;
using Interface;
using System;
using System.Collections.Generic;

namespace Abstract
{
    public abstract class Account : IAccount
    {
        private List<User> owners = new List<User>();
        private bool shareType = false;
        private int accountID;

        public Account(List<User> owners)
        {
            if (owners.Count > 1)
            {
                shareType = true;
            }
            accountID = generateID();
            foreach (User user in owners)
            {
                user.AddAccount(this);
            }
        }
        public List<User> getOwners()
        {
            return owners;
        }
        public bool getShareType()
        {
            return shareType;
        }
        public int getAccountID()
        {
            return accountID;
        }
        private int generateID()
        {
            Random random = new Random();
            return random.Next();
        }


        public abstract void Deposit(double amount);
        public abstract string Statement();
        public abstract void Withdraw(double amount);
    }
}

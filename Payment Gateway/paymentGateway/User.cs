using Abstract;
using Interface;
using System;
using System.Collections.Generic;
namespace Class
{

	public class User : IConnect
	{
		private string userName;
		private string password;
		private string name;
		private bool status = false;
		private List<Account> accounts = new List<Account>();
		public double totalAmount = 0;


		public User(string userName, string password, string name)
		{
			this.userName = userName;
			this.password = password;
			this.name = name;
		}

		public bool Connect(string userName, string password)
		{

			if (userName == null || password == null)
			{
				status = false;
				return false;

			}
			if (userName.Equals(this.userName) && password.Equals(this.password))
			{
				status = true;
				return true;
			}

			status = false;
			return false;

		}
		public void Disconnect()
		{
			status = false;
		}

		public List<Account> getAccounts()
        {
			return accounts;
        }
		public void AddAccount(Account account)
		{
			if (!status) return;

			if (account != null)
			{
				bool isExists = false;

				foreach (Account userAccount in accounts)
				{
					if (userAccount.getAccountID() == account.getAccountID())
					{
						isExists = true;
						break;
					}
				}

				if (!isExists)
				{
					accounts.Add(account);
				}
			}
		}

		public void Deposit(Double amount, int accountID)
		{
			Account account = getExistingAccount(accountID);

			if (account != null)
			{
				account.Deposit(amount);
			}
		}

		public void Withdraw(Double amount, int accountID)
		{
			Account account = getExistingAccount(accountID);

			if (account != null )
			{
				account.Withdraw(amount);
			}
		}

		public string getStatement(int accountID)
        {
			Account account = getExistingAccount(accountID);

			if (account != null)
			{
				return account.Statement();
			}

			return null;
		}

		private Account getExistingAccount(int accountID)
        {
			if (!status) return null;

			foreach (Account userAccount in accounts)
			{
				if (userAccount.getAccountID() == accountID)
				{
					return userAccount;
				}
			}

			return null;
		}
	}
}

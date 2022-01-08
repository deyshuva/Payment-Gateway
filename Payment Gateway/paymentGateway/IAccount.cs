using System;
namespace Interface
{
	public interface IAccount
	{
		//buy
		void Deposit(double amount);
		
		//sell
		void Withdraw(double amount);
		
		//Balance
		string Statement();

	}
}
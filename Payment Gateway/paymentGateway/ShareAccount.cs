using System;
using System.Collections.Generic;
using System.Text;
using Abstract;
namespace Class
{
	public class ShareAccount : Account
	{
		public double amount;
		public double shareholderPercentages;
        public enum ShareBond
        {
           XCineplex,
           YAmzn,
           ZTstate

        }
        
        private ShareBond shareAccount;
        public double totalShare = 0;
        private StringBuilder activities = new StringBuilder();
        public ShareAccount(ShareBond shareAccount,List<User> owners) : base(owners)
		{
            this.shareAccount = shareAccount;
		}
        
      //buy
        public override void Deposit(double amount)
        {
            totalShare += amount;
            activities.Append("Buy Share: " + amount + " " + shareAccount.ToString()+ " \tTotal Share" + totalShare + " " + shareAccount.ToString());
        }

      //sell
        public override void Withdraw(double amount)
        {
            if (amount < totalShare)
            {
                totalShare = totalShare - amount;
                activities.Append("\nSell Share: " + amount+ " " + shareAccount.ToString()+ " \tTotal Share" + totalShare + " " + shareAccount.ToString());
            }
        }
        public override string Statement()
        {
            return activities.ToString();
        }

    }
}

using Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Class
{
	public class GoodsAccount : Account
	{
		public string goodType;
		public double amount;
		public enum tradeUnit
		{
			grams,
			kilos,
			uncas
		}
        private tradeUnit trade;
        public double totalGoods = 0;
        private StringBuilder activities = new StringBuilder();


        public GoodsAccount(tradeUnit trade, List<User> owners) : base(owners)
        {
            this.trade = trade;
        }

        //buy
        public override void Deposit(double amount)
        {
            totalGoods += amount;
            activities.Append("Buy: " + amount + " " + trade.ToString() + "\tTotal Goods" + totalGoods + " " + trade.ToString());

        }

        public override string Statement()
        {
            return activities.ToString();
        }

        //sell
        public override void Withdraw(double amount)
        {
            totalGoods = totalGoods - amount;
            if (amount < totalGoods)
            {
                activities.Append("\nSell: " +  amount +" "+ trade.ToString() +"\tTotal Goods" +  totalGoods+ " " + trade.ToString());
            }
        }
    }

}


using System;
using Class;
using Abstract;
using Interface;
using System.Collections.Generic;


namespace Shuva_Dey_8781413_Assignment3
{
    class PaymentGateway
    {
        static List<User> singleuser = new List<User>();
        static List<User> multiUsers = new List<User>();

        static void Main(string[] args)
        {
            User user3 = new User("Ron23", "aec123", "Rohn Smitha");
            //connect
            user3.Connect("Ron23", "aec123");
            //goods
            singleuser.Add(user3);
            //list user account
            BankAccount bAccount = new BankAccount(BankAccount.Currencies.CAD, singleuser);
            GoodsAccount gAccount = new GoodsAccount(GoodsAccount.tradeUnit.kilos, singleuser);
            ShareAccount sAccount = new ShareAccount(ShareAccount.ShareBond.YAmzn, singleuser);
            // get all account 
            foreach(Account account in user3.getAccounts())
            {
                if(account is BankAccount)
                {
                    Console.Write("\nUser has Bank account, ");
                }else if(account is GoodsAccount)
                {
                    Console.Write("Goods account, ");

                }
                else Console.WriteLine("Share account");

            }
            //----all the operations comes here---
            //deposit and withdraw in Bank Account
            user3.Deposit(500, bAccount.getAccountID());
            user3.Withdraw(80.5, bAccount.getAccountID());
            user3.Withdraw(120.5, bAccount.getAccountID());

            //Buy and sell in goods account
            user3.Deposit(20, gAccount.getAccountID());
            user3.Withdraw(2, gAccount.getAccountID());
            //Buy and sell in share account
            user3.Deposit(20, sAccount.getAccountID());
            user3.Withdraw(5, sAccount.getAccountID());

            Console.WriteLine("\nBank Statement:");
            Console.WriteLine(user3.getStatement(bAccount.getAccountID()));
            Console.WriteLine("Share Statement");

            Console.WriteLine(user3.getStatement(sAccount.getAccountID()));

            Console.WriteLine("\nGoods Statement:");
            Console.WriteLine(user3.getStatement(gAccount.getAccountID()));

            // ----- TEST CASES ------
           /* Console.WriteLine("\n\nTest case 1: for multiple user account");
            testCase1();
            Console.WriteLine("\nTest case 2: for invalid user and password (won't be connected)");
            testcase2();
            Console.WriteLine("\nTest case 3: withdraw more than available (Withdraw is not possible)");
            testcase3();*/

        }

        //multiuser testcase
        static void testCase1()
        {
            //Created all the user here
            User user1 = new User("john23", "abc123", "John Smith");
            User user2 = new User("Jina14", "xyz321", "Jina Parker");

            //connecting user
            user1.Connect("john23", "abc123");
            user2.Connect("Jina14", "xyz321");      
            
            //Adding as multiple user
            multiUsers.Add(user1);
            multiUsers.Add(user2);

            //creation of Account here with multiple user
            BankAccount bAccount2 = new BankAccount(BankAccount.Currencies.USD, multiUsers);

            //user1.Deposit(525, bAccount1.getAccountID());
            user1.Deposit(725, bAccount2.getAccountID());
            user1.Withdraw(80, bAccount2.getAccountID());
            user2.Deposit(250, bAccount2.getAccountID());
            user2.Withdraw(100, bAccount2.getAccountID());


            //Printing statement for user1
            Console.WriteLine("user1:");
            Console.WriteLine("Statement for Account2:");
            Console.WriteLine(user1.getStatement(bAccount2.getAccountID()));
            //Printing statement for user2
            Console.WriteLine("user2: \nStatement for Account2");
            Console.WriteLine(user2.getStatement(bAccount2.getAccountID()));

            
        }

        //try with invalid password
        static void testcase2()
        {
            User user8 = new User("Ron23", "aec123", "Rohn Smitha");
            user8.Connect("Roni23", "ae123");
            //goods
            singleuser.Add(user8);
            GoodsAccount gAccount = new GoodsAccount(GoodsAccount.tradeUnit.kilos, singleuser);
            user8.Deposit(20, gAccount.getAccountID());
            user8.Withdraw(2, gAccount.getAccountID());
            Console.WriteLine("Statements for user wrong user or password:");

            Console.WriteLine(user8.getStatement(gAccount.getAccountID()));
        }
        //withdraw more than available
        static void testcase3()
        {
            User user5 = new User("Jinat5", "xyi821", "Jinat Newsy");
            user5.Connect("Jinat5", "xyi821");
            singleuser.Add(user5);
            //share account
            ShareAccount sAccount = new ShareAccount(ShareAccount.ShareBond.XCineplex, singleuser);
            //buy
            user5.Deposit(500, sAccount.getAccountID());
            //sell
            user5.Withdraw(700, sAccount.getAccountID());
            Console.WriteLine("Statement for user5 :");

            Console.WriteLine(user5.getStatement(sAccount.getAccountID()));
        }
    }
}

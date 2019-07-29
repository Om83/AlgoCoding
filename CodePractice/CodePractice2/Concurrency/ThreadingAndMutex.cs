using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace CodePractice2.Concurrency
{
    class Bank_ThreadingAndMutex
    {
        static int AccountBalance = 1000;

        public void Deposit(int ammount)
        {
            AccountBalance += ammount;
        }

        public void WithDraw(int ammount)
        {
            AccountBalance -= ammount;
        }
    }

    class ATM
    {

     

        void Start()
        {
            //Bank_ThreadingAndMutex bank = new Bank_ThreadingAndMutex();

            //List<Thread> ATMWithDrawThreads = new List<Thread>( new Thread(bank.WithDraw));
            ////List<Thread> ATMWDepositThreads = new List<Thread>(new Thread[10]);
            //int i =0,j= 0;
            //int MaxThread = 10;

            //for (int i = 0; i < length; i++)
            //{
            //    Thread "WithDrawThread"+i.ToString() =
            //}
            //foreach (Thread thread in ATMWithDrawThreads)
            //{
            //    thread.Name = "WithdrawThread_" + i++;
            
            //}
            //foreach (Thread thread in ATMWDepositThreads)
            //{
            //    thread.Name = "DepositThread_" + j++;
            //    thread.Start();
            //}
        //}

	}
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace CodePractice2
{
    public class FooBar
    {
        int n = 5;

        bool FoosTurn = true;
        object obj = new object();

        public void foo()
        {

            for (int i = 0; i < n; i++)
            {
                lock (obj)
                {
                        Console.Write("foo");
                        FoosTurn = false;
                }
            }

        }

        public void bar()
        {

            for (int i = 0; i < n; i++)
            {
                lock (obj)
                {
                    if (FoosTurn == false)
                    {
                        Console.Write("bar\n");
                        FoosTurn = true;
                    }
                }
            }
        }
    }

    //Goal print foobar using two thread n times

    public class FooBarTest
    {
        //Should Print Foo theb Bar and so on
        public static void PrintFooBar()
        {
            FooBar fb = new FooBar();

            Thread threadFoo = new Thread(fb.foo);
            Thread threadBar = new Thread(fb.bar);
            threadFoo.Start();
            threadBar.Start();
            Thread.Sleep(10000);
        }

    }


}

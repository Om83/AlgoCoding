using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace CodePractice2
{
    public class ReadWriteProblem
    {
        int Amount = 1000000; // 1 Million
        Semaphore semRead = new Semaphore(3, 3);
        Semaphore semWrite = new Semaphore(1, 1);
        static int readCount = 0;
        static int writeCount = 0;
        Object readLock = new object();
        Object writeLock = new object();
        static bool finishReading = false; // No read threads should be allowed to enter as we about to being writing

        public void ReadAccount()
        {

            Console.WriteLine(Thread.CurrentThread.Name + " is waiting");
            while(finishReading == true)
            {
                Console.WriteLine(Thread.CurrentThread.Name + " is not entering read since write is about to start");
                Thread.Sleep(100);
            }
            semRead.WaitOne();

            lock (readLock)
            {
                readCount++;
                if(readCount==1)
                {
                    //Threads are reading ,write should not happen, let's set write semphore count to zero
                    semWrite.WaitOne();
                }
            }
            Console.WriteLine(Thread.CurrentThread.Name + " is reading");
            Thread.Sleep(100);
            Console.WriteLine(Thread.CurrentThread.Name + " is exiting");
            semRead.Release();
            lock (readLock)
            {
                readCount--;
                if (readCount == 0)
                {
                    //No threads are reading , so system should be able to write
                    semWrite.Release();
                }
            }
        }

        public void WriteAccount()
        {
            //Signal finish reading
            lock (readLock)
            {
                finishReading = true;
            }

            Console.WriteLine(Thread.CurrentThread.Name + " is waiting");
            semRead.WaitOne();
            Console.WriteLine(Thread.CurrentThread.Name + " is writing");
            Thread.Sleep(150);
            Console.WriteLine(Thread.CurrentThread.Name + " is exiting");
            semRead.Release();

            lock (readLock)
            {
                finishReading = false;
            }
        }



       // public void ReadAccount()
       // {
       //     Console.WriteLine("New {0} is waiting in line...", Thread.CurrentThread.Name);
       //     semRead.WaitOne();

       //     while(stopReading)
       //     {
       //         Thread.Sleep(100);
       //     }

       //     readerCount++;
       //     Console.WriteLine("{0} is reading Account. Value is {1}", Thread.CurrentThread.Name, Amount.ToString());
       //     Thread.Sleep(100);
       //     Console.WriteLine("Existing {0} is leaving ", Thread.CurrentThread.Name);
       //     semRead.Release();
       //     readerCount--;

       // }

       //public  void UpdateAccount()
       // {
       //     Console.WriteLine("New {0} is waiting in line...", Thread.CurrentThread.Name);
       //     semWrite.WaitOne();
       //     Console.WriteLine("\n\nGoing to update account...all existing read threads must exit first");
       //     stopReading = true;
       //     Console.WriteLine("Stop reading triggered. All new read threads must wait");
       //     while(readerCount!=0)
       //     {
       //         Console.WriteLine("Possibily " + readerCount +" threads are still reading" );
       //         Thread.Sleep(100);
       //     }
       //     Thread.Sleep(100);
       //     Amount = Amount - 100;
       //     Console.WriteLine("{0} is Updating Account. Value is {1}", Thread.CurrentThread.Name, Amount.ToString());
       //     Console.WriteLine("Existing {0} is leaving ", Thread.CurrentThread.Name);

       //     semWrite.Release();
       //     stopReading = false;
       //     Console.WriteLine("Reading allowed.... new read threads can enter");
       // }
    }

    public class ReadWriteTests
    {
        public static void TestReadWrite()
        {
            Thread[] readThreads = new Thread[20];
            Thread[] writeThreads = new Thread[5];
            ReadWriteProblem rw = new ReadWriteProblem();

            //Create Read Threads
            for (int i=0,j= 0; i < 20; i++)
            {
                readThreads[i] = new Thread(rw.ReadAccount);
                readThreads[i].Name = " read_thread_" + i;
                readThreads[i].Start();
                if(i%4==0)
                {
                    writeThreads[j] = new Thread(rw.WriteAccount);
                    writeThreads[j].Name = " write_thread_" + i/4;
                    writeThreads[j++].Start();
                }
            }
        }
    }   
}

using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading;
using CodePractice2.Concurrency;

namespace CodePractice2.Tests
{
    /// <summary>
    /// Summary description for ReadWritesTests
    /// </summary>
    [TestClass]
    public class ReadWritesTests
    {
        public ReadWritesTests()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        //
        // You can use the following additional attributes as you write your tests:
        //
        // Use ClassInitialize to run code before running the first test in the class
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // Use ClassCleanup to run code after all tests in a class have run
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // Use TestInitialize to run code before running each test 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // Use TestCleanup to run code after each test has run
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion

        [TestMethod]
        public void TestMethod1()
        {

            Thread[] readThreads = new Thread[100];
            Thread[] writeThreads = new Thread[100];
            ReadWriteProblem rw = new ReadWriteProblem();


            //Create Read Threads
            for (int i = 0; i < 100; i++)
            {
                readThreads[i] = new Thread(rw.ReadAccount);
                readThreads[i].Name = "thread_" + i;
                readThreads[i].Start();
            }

            //Create Update Threads
            for (int i = 0; i < 100; i++)
            {
                //writeThreads[i] = new Thread(rw.UpdateAccount);
                writeThreads[i].Name = "thread_" + i;
                writeThreads[i].Start();
            }
        }
    }
}

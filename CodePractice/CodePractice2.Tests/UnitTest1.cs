using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CodePractice2;
using System.Collections.Generic;

namespace CodePractice2.Tests
{
    [TestClass]
    public class UnitTest1
    {
        Graph g;
        [TestInitialize]
        public void CreateGraph()
        {
            g = new Graph();
            g.AddNode("WA", new List<string>(new string[] { "OR", "ID" }));
            g.AddNode("OR", new List<string>(new string[] { "WA", "ID", "NV", "CA" }));
            g.AddNode("ID", new List<string>(new string[] { "MT", "WY", "UT", "NV", "OR", "WA" }));
            g.AddNode("AZ", new List<string>(new string[] { "CO", "NM", "UT", "CA", "NV" }));
            g.AddNode("UT", new List<string>(new string[] { "ID", "WY", "CO", "AZ", "NV" }));

        }

        [TestCleanup]
        public void Cleanup()
        {
            g = null;
        }
        [TestMethod]
        public void TestBFS()
        {
            //http://images-mediawiki-sites.thefullwiki.org/11/3/1/3/1663511729624992.png 
            //List<string> path = g.BreadthFirstSearch("WA", "AZ");           
            List<string> path = g.BreadthFirstSearch("UT", "WA");
            if (path != null)
            {
                Console.WriteLine("Shortest Path is : ");
                foreach (var nodeId in path)
                {
                    Console.Write(nodeId +" ");
                }
            }
            else
            {
                Console.WriteLine("Path not found");
            }
        }

        [TestMethod]
        public void TestPrintLevelNodes()
        {
            Graph.PrintLevelNodes(g, "WA");
        }

    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace CodePractice2
{

    //SHortest Path Algo 
    //Best Vizualization can be found here https://www.cs.usfca.edu/~galles/visualization/Dijkstra.html
    public class Graph
    {
        HashSet<GraphNode> graph = new HashSet<GraphNode>();
        Queue<GraphNode> queue = new Queue<GraphNode>();
        List<string> path = new List<string>();

        public GraphNode GetNodeFromId(string id)
        {
            GraphNode graphNode = null;
            foreach (var node in this.graph)
            {
                if (node.Id.ToLower() == id.ToLower())
                    graphNode = node;
            }
            return graphNode;
        }

        public void AddNode(string id, List<string> neighbors)
        {
            GraphNode graphNode = new GraphNode(id);
            graphNode.Neighbors = neighbors;
            this.graph.Add(graphNode);
        }

        void DeleteNode(GraphNode node)
        {
            foreach (var graphNode in node.Neighbors)
            {
                GetNodeFromId(graphNode).Neighbors.Remove(node.Id);
            }
            this.graph.Remove(node);
            
        }

        /// <summary>
        /// Return shortest path after BFS
        /// </summary>
        /// <param name="source"></param>
        /// <param name="destination"></param>
        /// <returns></returns>
        public List<string> BreadthFirstSearch( string source, string destination )
        {
          
            
 
            GraphNode sourceNode = GetNodeFromId(source);
            GraphNode destNode = GetNodeFromId(destination);
            if (source == null || destination == null || sourceNode == null || destNode == null)
                return null;
            queue.Enqueue(sourceNode);
            sourceNode.Visited = true;
            int level = 0;

            while (queue.Count != 0)
            {
                GraphNode gn = queue.Dequeue();

                if (gn == destNode)
                {
                    path.Add(destNode.Id);
                    //Build the Shortest Path
                    while (destNode.Parent!=sourceNode)
                    {
                        path.Add(destNode.Parent.Id);
                        destNode = destNode.Parent;
                    }
                    path.Add(sourceNode.Id);
                    path.Reverse();
                    return path;
                }

                //Console.Write("Nodes at level {0} are : ",(++level).ToString());
                foreach (var neighbor in gn.Neighbors)
                {
                    GraphNode node = GetNodeFromId(neighbor);
                    if (node != null && node.Visited!=true)
                    {
                        queue.Enqueue(node);
                        node.Parent = gn;
                        node.Visited = true;
                    }
                    //Console.Write(neighbor + " ");
                }
                //Console.WriteLine();
            }

            return null;
        }

        public static void PrintLevelNodes(Graph g, string start)
        {
            if(g!=null && start!=null)
            {
                GraphNode startNode = g.GetNodeFromId(start);
                GraphNode tempNode;
                GraphNode tempChildNode;
                List<string> nodeIdList; 
                int level = 0;
                Queue<GraphNode> queue1 = new Queue<GraphNode>();
                queue1.Enqueue(startNode);
                startNode.Visited = true;
                Queue<GraphNode> queue2 = new Queue<GraphNode>();
                if (startNode!=null)
                {
                    while(queue1.Count>0 || queue2.Count>0)
                    {
                        nodeIdList = new List<string>();
                        if (level % 2 == 0)
                        {
                            while(queue1.Count>0)
                            {
                                tempNode = queue1.Dequeue();
                                nodeIdList.Add(tempNode.Id);
                                foreach (var childNode in tempNode.Neighbors)
                                {
                                    tempChildNode = g.GetNodeFromId(childNode);
                                    if (tempChildNode != null && tempChildNode.Visited!=true)
                                    {
                                        queue2.Enqueue(tempChildNode);
                                        tempChildNode.Visited = true;
                                    }

                                }

                            }
                        }
                        else
                        {
                            while (queue2.Count > 0)
                            {
                                tempNode = queue2.Dequeue();
                                nodeIdList.Add(tempNode.Id);
                                foreach (var childNode in tempNode.Neighbors)
                                {
                                    tempChildNode = g.GetNodeFromId(childNode);
                                    if (tempChildNode != null && tempChildNode.Visited != true)
                                    {
                                        queue1.Enqueue(tempChildNode);
                                        tempChildNode.Visited = true;
                                    }
                                }

                            }
                        }

                        PrintNodes(level, nodeIdList);
                        level++;
                    }
                }
            }
        }

        private static void PrintNodes(int level, List<string> Nodes)
        {
            Console.Write("Nodes at level " + level.ToString() + " are : ");
            foreach (var nodeId in Nodes)
            {
                Console.Write(nodeId + " ");
            }
            Console.WriteLine();
        }
    }

    public class GraphNode
    {
        public string Id { get; }
        public List<string> Neighbors { get; set; }

        public GraphNode Parent { get; set; }

        public bool Visited { get; set; }
        public GraphNode(string id)
        {
            this.Id = id;
        }

        public GraphNode(string id, List<string> neighbors)
        {
            this.Neighbors = neighbors;
        }

    }

    //internal class Edge
    //{
    //    HashSet<GraphNode> graphEdge = new HashSet<GraphNode>();
    //    GraphNode start;
    //    GraphNode end;
    //    int weight;
    //}
}

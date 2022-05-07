using System;
using System.Collections.Generic;
using System.IO;

namespace CovidMeetsHogwarts
{
    public class Graph // undirected graph
    {
        // Attributes
        private string name;
        private List<Node> nodes; // spots
        private List<Edge> edges; // paths
        
        // Methods
        // - constructor
        public Graph(string name)
        {
            this.name = name;
            nodes = new List<Node>();
            edges = new List<Edge>();
        }

        // - getters
        public string GetName()
        {
            return name;
        }

        public List<Node> GetNodes()
        {
            return nodes;
        }

        public List<Edge> GetEdges()
        {
            return edges;
        }

        /// <summary>
        /// try to create and add node to this graph.
        /// if a node with the same label already exists, then return existing node.
        /// return created node otherwise.
        /// </summary>
        /// <param name="label">label of the node to add</param>
        /// <returns>created/existing node</returns>
        Node AddNode(string label)
        {
            foreach (var nod in nodes)
            {
                if (nod.GetLabel() == label)
                    return nod;
            }
            
            Node newNode = new Node(label);
            nodes.Add(newNode);
            return newNode;
            
        }
        
        /// <summary>
        /// try to create and add edge to this graph.
        /// if this edge already exists, then return false because no edges were added.
        /// return true otherwise.
        /// </summary>
        /// <param name="source">source node of the edge to add</param>
        /// <param name="destination">destination node of the edge to add</param>
        /// <returns>a boolean of whether an edge was added or not</returns>
        bool AddEdge(Node source, Node destination)
        {
            foreach (var edg in edges)
            {
                if (((edg.GetEndpoints().source == source) &&
                     (edg.GetEndpoints().destination == destination)) ||
                    ((edg.GetEndpoints().source == destination) &&
                     (edg.GetEndpoints().destination == source)))
                    return false;
            }

            Edge newEdge = new Edge(source, destination);
            edges.Add(newEdge);
            return true;
        }

        /// <summary>
        /// extract the graph's name of the first line in a DOT file. (first line of a graph declaration)
        /// 
        /// example of a first line: "graph Epita {".
        /// In this example, the string "Epita" should be returned.
        /// </summary>
        /// <param name="firstLine">first line of a DOT file</param>
        /// <returns>the name of the graph</returns>
        public static string ExtractNameFromLine(string firstLine)
        {
            string[] res = firstLine.Split(" ");
            return res[1];
        }
        
        /// <summary>
        /// extract nodes and edge from a given edge line in DOT file and add them
        /// to given 'graph'.
        /// The format of edgeLine's string is the same as the ToString() method
        /// in Edge.cs without the newline character.
        /// 
        /// example of edgeLine: "    VA302 -- VA303;".
        /// In this example, the nodes of respective labels "VA302" and "VA303" as well
        /// as the edge linking those two should be added to the graph.
        /// </summary>
        /// <param name="edgeLine">string in DOT language describing an edge</param>
        /// <param name="graph">graph to update</param>
        /// <exception cref="Exception">an exception should be raised if the edge already exists</exception>
        public static void UpdateGraphFromLine(string edgeLine, Graph graph)
        {
            string[] splt = edgeLine.Split(' ', '-',  ';');
            Node nodeSource = new Node(splt[4]);
            Node nodeDest = new Node(splt[8]);
            
            graph.AddEdge(nodeSource, nodeDest);
            graph.AddNode(nodeSource.GetLabel());
            graph.AddNode(nodeDest.GetLabel());
            
            nodeSource.GetNeighbors().Add(nodeDest);
        }
        
        /// <summary>
        /// generate graph from file written in simple DOT language.
        /// </summary>
        /// <param name="filepath">path of file in DOT language</param>
        /// <returns>created graph</returns>
        public static Graph FromFile(string filepath)
        {
            Graph newGraph = null;
            string nodeExtract;
            try
            {
                if (File.Exists(filepath))
                {
                    StreamReader readDot = File.OpenText(filepath);
                    string graphName = ExtractNameFromLine(readDot.ReadLine());
                    newGraph = new Graph(graphName);

                    while ((nodeExtract = readDot.ReadLine()) != null )
                    {
                        UpdateGraphFromLine(nodeExtract, newGraph);
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("File doesnt exist");
            }

            return newGraph;
        }
    }
}
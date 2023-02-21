using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Lab6
{
    //system has 1 graph manager object to store graphs and manipulate them by IDs
    public class GraphManager
    {
        //list of graphs stored 
        public List<Graph> graphs = new List<Graph>();

        //singleton instance to be used everywhere
        private static GraphManager myGraphManager = new GraphManager();


        //private constructor to prevent creation of another instance
        private GraphManager() { }

        //return a reference to the only instance of this class
        public static GraphManager getInstance()
        {
            return myGraphManager;
        }



        //create a new graph with a user-specified ID
        public void createGraph(int graphID)
        {
            
            Graph g = new Graph(graphID); //create a new graph
            
            string choice;
           
            do
            {
                //add vertices
                Console.WriteLine("Would you like to add a vertex or an edge? Enter 'v' for vertex, 'e' for edge and 'q' to quit\n");
                choice = Console.ReadLine();
                if (choice == "v")
                {
                    Console.WriteLine("Enter a vertex ID, q to quit: \n  ");
                    int vertexID = int.Parse(Console.ReadLine());
                    Console.WriteLine("Enter x coordinate for vertex \n");
                    int x = int.Parse(Console.ReadLine());
                    Console.WriteLine("Enter y coordinate for vertex \n");
                    int y = int.Parse(Console.ReadLine());
                    Vertex v = new Vertex(vertexID, x, y);
                    Console.WriteLine(v.getX().ToString());
                    g.vertices.Add(v);


                }
                else if(choice == "e")
                {
                    //add edges
                    Console.WriteLine("Enter an edge ID, q to quit: \n  ");
                    int edgeID = int.Parse(Console.ReadLine());
                    Console.WriteLine("Enter starting vertex id \n");
                    int fromID = int.Parse(Console.ReadLine());
                    Vertex from = g.getVertex(fromID);
                    if (from.getVertexID() == -1)
                    {
                        Console.WriteLine("Vertex does not exist, enter a valid one\n");
                        fromID = int.Parse(Console.ReadLine());
                        from = g.getVertex(fromID);
                    }
                    Console.WriteLine("Enter ending vertex id \n");
                    int toID = int.Parse(Console.ReadLine());
                    Vertex to = g.getVertex(toID);
                    if (to.getVertexID() == -1)
                    {
                        Console.WriteLine("Vertex does not exist, enter a valid one\n");
                        toID = int.Parse(Console.ReadLine());
                        to = g.getVertex(toID);
                    }
                    Edge e = new Edge(edgeID, from, to);
                    g.edges.Add(e);
                }


            } while (choice != "q");


            graphs.Add(g); //add the newly created graph to the list

        }

        //revise am existing graph's vertices or edges based on IDs
        public void reviseGraph(int graphID)
        {
            string choice;
            Console.WriteLine("Would you like to update a vertex(v) or an edge(e)? ");
            choice = Console.ReadLine();
            if(choice == "v")
            {
                reviseVertex(graphID); //update coordinates of vertex
            }
            else if(choice == "e")
            {
                reviseEdge(graphID); //update vertices of edge
            }
            else
            {
                Console.WriteLine("Invalid option\n");
            }
        }

        //update vertex coordinates
        private void reviseVertex(int graphID)
        {
            Graph g;
            for(int i = 0; i < graphs.Count; i++)
            {
                if(graphs[i].getGrapID() == graphID)
                {
                    g = graphs[i];
                    Console.WriteLine("Enter the vertexID to be updated:\n");
                    int vertexID = int.Parse(Console.ReadLine());
                    Vertex v = g.getVertex(vertexID);
                    Console.WriteLine("Enter new x coordinate\n");
                    int x = int.Parse(Console.ReadLine());
                    Console.WriteLine("Enter new y coordinate\n");
                    int y = int.Parse(Console.ReadLine());
                    v.setX(x);
                    v.setY(y);

                }
            }
           
        }

        //update edge's vertices
        private void reviseEdge(int graphID)
        {
            Graph g;
            for (int i = 0; i < graphs.Count; i++)
            {
                if (graphs[i].getGrapID() == graphID)
                {
                    g = graphs[i];
                    Console.WriteLine("Enter the edgeID to be updated:\n");
                    int edgeID = int.Parse(Console.ReadLine());
                    Edge e = g.getEdge(edgeID);
                    Console.WriteLine("Enter id of new starting vertex\n");
                    int fromID = int.Parse(Console.ReadLine());
                    Vertex from = g.getVertex(fromID);
                    Console.WriteLine("Enter id of new ending coordinate\n");
                    int toID = int.Parse(Console.ReadLine());
                    Vertex to = g.getVertex(toID);
                    e.setFrom(from);
                    e.setTo(to);

                }
            }
        }

        //clone a chosen graph toegether with a copy of its vertices and edges
        //different ID assigned to graph 
        //deep copy
        public void copyGraph(int graphID)
        {
           
            for(int i = 0; i < graphs.Count; i++)
            {
                if(graphs[i].getGrapID() == graphID)
                {
                    Graph gClone = (Graph)graphs[i].Clone();
                    int cloneID;
                    Console.WriteLine("Enter a new graph ID for the copied graph: \n");
                    cloneID = int.Parse(Console.ReadLine());
                    gClone.setGraphID(cloneID);
                    graphs.Add(gClone);
                }
            }
        }

      

        //print the specified graph
        public void printGraph(Form1 form1, int graphID)
        {
            PaintEventArgs e;
            for (int i = 0; i < graphs.Count; i++)
            {
                if (graphs[i].getGrapID() == graphID)
                {
                   

                    graphs[i].print( form1.showGraphBox);
                }
            }
        }
    }

   
}





     




     

  

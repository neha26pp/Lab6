using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;

namespace Lab6
{
    [Serializable]
    //Graph class to store information about a 2D graph
    public class Graph: ICloneable
    {
        private int graph_ID;

        //list of vertices
        public List<Vertex> vertices = new List<Vertex>(); 

        //list of edges
        public List<Edge> edges = new List<Edge>();

        public Graph() { }

        //constructor to initialize a graph with ID
        public Graph(int id)
        {
            graph_ID = id;
        }

        //get graph ID
        public int getGrapID()
        {
            return graph_ID;
        }

        //set graph ID
        public void setGraphID(int id)
        {
            this.graph_ID = id;
        }

        //get a vertex from the list of vertices based on ID
        public Vertex getVertex(int vertexID)
        {
            Vertex v = new Vertex(-1,0,0);
            for(int i = 0; i < vertices.Count; i++)
            {
                if(vertices[i].getVertexID() == vertexID)
                {
                    v  = vertices[i];
                }
            }
            return v;
        }

        //get an edge from the list of edges based on ID
        public Edge getEdge(int edgeID)
        {
            Edge e = new Edge();
            for (int i = 0; i < edges.Count; i++)
            {
                if (edges[i].getEdgeID() == edgeID)
                {
                    e = edges[i];
                }
            }
            return e;
        }

        //print the graph to the screen
        public void print(PictureBox box)
        {
            Bitmap bmp = new Bitmap(box.Width, box.Height);
            Graphics g = Graphics.FromImage(bmp);
            
           for(int i = 0; i < vertices.Count; i++)
            {
                vertices[i].drawVertex(box, g);
                Console.WriteLine(vertices[i].getVertexID() + " "  + vertices[i].getX() + "\n");
            }

           for(int i = 0; i < edges.Count; i++)
            {
                edges[i].drawEdge(box, g);
                Console.WriteLine(edges[i].getEdgeID() + "\n");
            }

            box.Image = bmp;
        }

        //create a deep copy of the graph
        public object Clone() 
        {
            //Object.MemberwiseClone creates a shallow copy (only primitive data types)
            /**For deep copy use serialization - deserialization 
             * serialization: stores state of an object to the stream of bytes
             * deserialization: converts from a byte stream to an original object 
             * 
             * */
            using (MemoryStream stream = new MemoryStream())
            {
                if (this.GetType().IsSerializable)
                {
                    BinaryFormatter formatter = new BinaryFormatter();
                    formatter.Serialize(stream, this);
                    stream.Position = 0;
                    return formatter.Deserialize(stream);
                }
                return null;
            }
        }
    }
}

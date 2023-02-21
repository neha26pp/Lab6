using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Lab6
{
    [Serializable]
    //stores information about edges in a graph 
    public class Edge
    {
        int edge_ID;
        //starting and ending vertices of the edge
        private Vertex from_vertex;
        private Vertex to_vertex;

        

        public Edge() { }

        //constructor to initialize edge with ID, and vertices
        public Edge(int id, Vertex from, Vertex to)
        {
            edge_ID = id; 
            from_vertex = from;
            to_vertex = to;
        }

        //getter and setter for edge ID
        public int getEdgeID()
        {
            return edge_ID;
        }
        
        public void setEdgeID(int id)
        {
            edge_ID = id;
        }

        //getter and setter for starting vertex of the edge
        public Vertex getFrom()
        {
            return from_vertex;
        }
        public void setFrom(Vertex from)
        {
            from_vertex = from;
        }

        //getter and setter for ending vertex of the edge
        public Vertex getTo()
        {
            return to_vertex;
        }
        public void setTo(Vertex to)
        {
            to_vertex = to;
        }
      

        //draw an edge to the screen
        public void drawEdge(PictureBox box, Graphics g  )
        {
            Vertex from = getFrom();
            Vertex to = getTo();
            Point p1 = new Point(from.getX(), from.getY());
            Point p2 = new Point(to.getX(), to.getY());
            Pen pen = new Pen(Color.Black);
            g.DrawLine(pen, p1, p2);
            pen.Dispose();
           // g.Dispose();

        }
    }
}

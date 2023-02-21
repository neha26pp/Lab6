using System;
using System.Drawing;
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
            int s = 10;
            Vertex from = getFrom();
            Vertex to = getTo();
            Rectangle r1 = new Rectangle(from.getX(), from.getY(), 2 * s, 2 * s);
            Rectangle r2 = new Rectangle(to.getX(), to.getY(), 2 * s, 2 * s);

            int v = r1.X > r2.Y ? -1 : 1;
            double d = cosine(new Point(r2.X - r1.X, r2.Y - r1.Y), new Point(v, 0));
            double x = r1.X + s + v * s * d;
            double y = r1.Y + s + v * s * Math.Sqrt(1 - d * d);
            double x2 = r2.X + s - v * s * d;
            double y2 = r2.Y + s - v * s * Math.Sqrt(1 - d * d);

            g.DrawLine(new Pen(Color.Black), (int)x, (int)y, (int)x2, (int)y2);
            g.FillEllipse(new SolidBrush(Color.Black), (int)(x - 5), (int)(y - 5), 10, 10);

            Point p = compute(new Point(r2.X - r1.X, r2.Y - r1.Y), Math.PI / 6);
            g.DrawLine(new Pen(Color.Black), (int)x2, (int)y2, (int)x2 + p.X, (int)y2 + p.Y);
            p = compute(new Point(r2.X-r1.X, r2.Y-r1.Y), -Math.PI / 6);
            g.DrawLine(new Pen(Color.Black), (int)x2, (int)y2, (int)x2 + p.X, (int)y2 + p.Y);
        }

        public double cosine(Point p1, Point p2)
        {
            double d0 = p1.X * p2.X + p1.Y * p2.Y;
            double d1 = Math.Sqrt(p1.X * p1.X + p1.Y * p1.Y);
            return d0 / d1;
        }

        public Point compute(Point p1, double angle)
        {
            double d1 = Math.Sqrt(p1.X * p1.X + p1.Y * p1.Y);
            double x = -20 * p1.X / d1;
            double y = -20 * p1.Y / d1;
            double nx = x * Math.Cos(angle) - y * Math.Sin(angle);
            double ny = x * Math.Sin(angle) + y * Math.Cos(angle);
            return new Point((int)nx, (int)ny);
        }
    }
}

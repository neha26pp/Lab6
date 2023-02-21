using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Windows.Forms;

namespace Lab6
{
    [Serializable]
    //stores information about vertices of a graph
    public class Vertex
    {
        private int vertex_ID;
        private int x_coordinate;
        private int y_coordinate;
     

        public Vertex() { }

        //constructor to initialize vertex with ID, x and y coordinates
        public Vertex(int id,int x, int y)
        {
            setVertexID(id);
            setX(x);
            setY(y);
        }

        //getter and setter for vertex ID
        public int getVertexID()
        {
            return vertex_ID;
        }

        public void setVertexID (int vertexID)
        {
            this.vertex_ID = vertexID;
        }

        //getter and setter for x-coordinate
        public int getX()
        {
            return x_coordinate;
        }

        public void setX(int x)
        {
            this.x_coordinate = x;
        }

        //getter and setter for y-coordinate
        public int getY()
        {
            return y_coordinate;
        }

        public void setY(int y)
        {
            this.y_coordinate = y;
        }

      
        //draw a vertex to the screen
        public void drawVertex(PictureBox box, Graphics g)
        {
           // Bitmap bmp = new Bitmap(box.Width, box.Height);

            int x = getX();
            int y = getY();
            Pen pen = new Pen(Color.Black);
            Brush brush;
           
            g.DrawEllipse(pen, x, y, 5, 5);
           
            //Rectangle rect = new Rectangle()
            //g.FillEllipse()
            //pen.Dispose();

           
        }



        
    }
}

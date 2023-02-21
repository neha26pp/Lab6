using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab6
{
    static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            //get singleton instance of GraphManager which will be used throughout the program
            GraphManager gm = GraphManager.getInstance();

            //display menu for user to choose from
            string choice;
            do
            {

                Console.WriteLine("Menu: (q) to quit\n");
                Console.WriteLine("1. Create graph\n");
                Console.WriteLine("2. Revise graph\n");
                Console.WriteLine("3. Copy graph\n");
                Console.WriteLine("4. Print graph\n");
                 choice = Console.ReadLine();
                if (choice == "1")
                {
                    //create graph
                    Console.WriteLine("Enter graph id: ");
                    string id = Console.ReadLine();
                    gm.createGraph(int.Parse(id));
                }
                else if(choice == "4")
                {
                    //print graph
                    Console.WriteLine("Enter graph id: ");
                    string id = Console.ReadLine();
                    Form1 form1 = new Form1();
                    gm.printGraph(form1, int.Parse(id));
                    Application.Run(form1);
                  
                   
                }
                else if(choice == "2")
                {
                    //revise graph
                    Console.WriteLine("Enter graph id: ");
                    string id = Console.ReadLine();
                    gm.reviseGraph(int.Parse(id));
                }
                else
                {
                    //copy graph
                    Console.WriteLine("Enter graph id: ");
                    string id = Console.ReadLine();
                    gm.copyGraph(int.Parse(id));
                }
               
                
            } while (choice != "q");
        }
    }
}

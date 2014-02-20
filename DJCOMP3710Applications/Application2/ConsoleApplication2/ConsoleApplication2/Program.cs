using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;

namespace ConsoleApplication2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.BackgroundColor = ConsoleColor.Yellow;
            //Console.ResetColor();
            
            Console.WriteLine("***** Fun with Data Readers *****\n");
            Console.WriteLine("The result in a table format\n");
            Console.WriteLine("R#  CL#\t\tClient Name\t\tBA#");
            Console.WriteLine("-------------------------------------------");

            string cnStr = "Provider=Microsoft.ACE.OLEDB.12.0;" + "Data Source='C:/Users/Daniel/Documents/Spring14/RD/Work/trunk/DJCOMP3710Applications/DJCamashaly Design.accdb'";

            using (OleDbConnection cn = new OleDbConnection())
            {
                cn.ConnectionString = cnStr;
                cn.Open();
                //ShowConnectionStatus(cn);

                string strSQL = "Select [Client Number], [Client Name], [Business Analyst Number] From DJClient";

                using (OleDbCommand myCommand = new OleDbCommand(strSQL, cn))
                {
                    using (OleDbDataReader myDataReader = myCommand.ExecuteReader())
                    {
                        int x = 0;
                        while (myDataReader.Read())
                        {
                            x++;
                            if (x < 10)
                            {
                                Console.Write(" ");
                            }
                            Console.Write(x + " ");

                            for (int i = 0; i < myDataReader.FieldCount; i++)
                            {

                                Console.Write(myDataReader.GetValue(i)+"\t");


                                if (myDataReader.GetName(i) == "Client Name")
                                {
                                   // Console.Write("\t");
                                    if (myDataReader.GetValue(i).ToString().Length <= 23)
                                    {
                                        Console.Write("\t");
                                        if (myDataReader.GetValue(i).ToString().Length <= 15)
                                        {
                                            Console.Write("\t");
                                        }
                                    }
                                }

                                if (myDataReader.GetName(i) == "Business Analyst Number")
                                {
                                    Console.WriteLine();
                                }
                            }
                           
                        }
                        Console.WriteLine("-------------------------------------------");
                        Console.WriteLine("Totally there are {0} records!", x);
                    }
                }
            }
        }
        public static void ShowConnectionStatus(OleDbConnection cn)
        {
            Console.WriteLine("***** Info about your connection *****");
            Console.WriteLine("Database location: {0}", cn.DataSource);
            Console.WriteLine("Timeout: {0}", cn.ConnectionTimeout);
            Console.WriteLine("Connection state: {0}\n", cn.State);
        }
    }
}

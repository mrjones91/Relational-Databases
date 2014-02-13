using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;

namespace DJConsoleConnectedDataReader
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***** Fun with Data Readers *****\n");

            string cnStr = "Provider=Microsoft.ACE.OLEDB.12.0;" + "Data Source='C:/Users/Daniel/Documents/Spring14/RD/Work/DJCOMP3710Applications/DJCamashaly Design.accdb'";

            using (OleDbConnection cn = new OleDbConnection())
            {
                cn.ConnectionString = cnStr;
                cn.Open();
                ShowConnectionStatus(cn);

                string strSQL = "Select [Client Number], [Client Name], [Business Analyst Number] From DJClient";

                using (OleDbCommand myCommand = new OleDbCommand(strSQL, cn))
                {
                    using (OleDbDataReader myDataReader = myCommand.ExecuteReader())
                    {
                        int x = 0;
                        while (myDataReader.Read())
                        {
                            x++;
                            Console.WriteLine("***** Record #{0}*****", x);
                            for (int i = 0; i <myDataReader.FieldCount; i++)
                            {
                                Console.WriteLine("{0} = {1}", myDataReader.GetName(i), myDataReader.GetValue(i));
                            }
                            Console.WriteLine();
                        }
                        Console.WriteLine("Totally there are {0} records.", x);
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

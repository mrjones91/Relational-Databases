using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace DJCOMP3710Applications
{
    public partial class Form1 : Form
    {
        DataTable dt1 = new DataTable();
        DataTable dt2 = new DataTable();

        string cnStr = "Provider=Microsoft.ACE.OLEDB.12.0;" + "Data Source='C:/Users/Daniel/Documents/Spring14/RD/Work/trunk/DJCamashaly Design.accdb'";

        public Form1()
        {
            InitializeComponent();

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (OleDbConnection cn = new OleDbConnection())
            {
                cn.ConnectionString = cnStr;
                cn.Open();

                //Make SQL command object
                string strSQL = "Select [Client Number], [Client Name], [Business Analyst Number] FROM DJClient";

                using (OleDbCommand djCommand = new OleDbCommand(strSQL, cn))
                {
                    using (OleDbDataReader djDataReader = djCommand.ExecuteReader())
                    {
                        dt1.Load(djDataReader);
                        dataGridView1.DataSource = dt1;
                    }
                }
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            using (OleDbConnection cn = new OleDbConnection())
            {
                cn.ConnectionString = cnStr;
                cn.Open();

                //SQL command
                string baNum = textBox1.Text;
                string where = String.Format(" WHERE [Business Analyst Number] ='{0}'", baNum);
                string strSQL = "SELECT [Client Number], [Client Name], [Business Analyst Number] FROM DJClient " + where;

                using (OleDbCommand djCommand = new OleDbCommand(strSQL, cn))
                {
                    using (OleDbDataReader djDataReader = djCommand.ExecuteReader())
                    {
                        dt2.Load(djDataReader);
                        dataGridView2.DataSource = dt2;
                    }
                }
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FTT_travel
{
    internal class Operations
    {
        public OleDbConnection cn = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=FTT_Travel_DB.accdb;Persist Security Info=False");
        public OleDbCommand cmd = new OleDbCommand();
        public OleDbDataReader dataReader;
        public void connect()
        {
            cn.Open();
            cmd.Connection = cn;
        }
        public void disconnect()
        {
            cn.Close();
        }
    }
}

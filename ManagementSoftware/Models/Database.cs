using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagementSoftware.Models
{
    public class Database
    {
        public string stringConnect = @"Data Source=DESKTOP-62K66UH\SQLEXPRESS;Initial Catalog=QLShoes;Integrated Security=True";

        private SqlConnection connect;
        private SqlDataAdapter adt;
        private SqlCommandBuilder cmd;
        
        public static Database singleton = null;
        public static Database Singleton
        {
            get
            {
                if (singleton == null)
                    singleton = new Database();
                return singleton;
            }
        }

        public Database()
        {
            this.connect = new SqlConnection(stringConnect);
        }

        public DataTable LoadData(string sql)
        {
            DataTable table = new DataTable();
            adt = new SqlDataAdapter(sql, this.connect);
            adt.Fill(table);
            return table;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using System.Data.SQLite;

namespace StudentsTesting1.DataAccess
{
    public class DBAccess
    {
        private string filename { get; set; }
        private SQLiteConnection connection { get; set; }
        public DBAccess()
        {
            filename = "Database/Car.db";
            connection = new SQLiteConnection("Data Source=" + filename + ";Version=3;");
            connection.Open();
        }

        public void SQLExecute(string query)
        {
            SQLiteCommand command = new SQLiteCommand(query);
            command.ExecuteNonQuery();
        }
    }
}

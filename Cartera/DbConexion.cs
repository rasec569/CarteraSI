using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;

namespace Cartera
{
    class DbConexion
    {
        private const string DBName = "Cartera San Isidro.sqlite";
        private const string SQLScript = @"..\..\Util\database.sql";
        public static SQLiteConnection GetInstance()
        {
            var db = new SQLiteConnection(
                string.Format("Data Source={0};Version=3;", DBName)
            );

            db.Open();

            return db;
        }
    }
    
}

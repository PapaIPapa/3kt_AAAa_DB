using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.Sqlite;
using System.Data.SQLite;

namespace _3kt
{


    public class DatabaseDB
    {
        private SQLiteConnection _connection;

        public DatabaseDB(string databasePath)
        {
            _connection = new SQLiteConnection($"Data Source={databasePath}");
            _connection.Open();
        }

        public void CreateTable(string tableName, string columns)
        {
            using (var command = _connection.CreateCommand())
            {
                command.CommandText = $"CREATE TABLE IF NOT EXISTS {tableName} ({columns})";
                command.ExecuteNonQuery();
            }
        }

        public void InsertData(string tableName, string columns, string values)
        {
            using (var command = _connection.CreateCommand())
            {
                command.CommandText = $"INSERT INTO {tableName} ({columns}) VALUES ({values})";
                command.ExecuteNonQuery();
            }
        }

        public void Close()
        {
            _connection.Close();
        }
    }
}

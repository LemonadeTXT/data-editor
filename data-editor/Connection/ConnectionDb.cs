using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace data_editor.Connection
{
    public class ConnectionDb
    {
        public string ConnectionString { get; set; }

        public string GetConnectionStringFromFile()
        {
            using (var streamReader = new StreamReader("Connection.txt"))
            {
                return streamReader.ReadToEnd();
            }
        }

        public void SetConnectionStringToFile(string newConnectionString)
        {
            if (!string.IsNullOrEmpty(newConnectionString) &&
                newConnectionString != ConnectionString)
            {
                newConnectionString = newConnectionString.TrimStart(' ').TrimEnd(' ');

                File.WriteAllText("Connection.txt", newConnectionString);
            }
        }
    }
}

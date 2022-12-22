using System.IO;

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
                File.WriteAllText("Connection.txt", newConnectionString.TrimStart(' ').TrimEnd(' '));
            }
        }
    }
}

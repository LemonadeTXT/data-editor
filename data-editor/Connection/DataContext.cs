using data_editor.Models;
using System.Data.Entity;

namespace data_editor.Connection
{
    public class DataContext : DbContext
    {
        public DataContext(string connectionString) : base(connectionString)
        {
            Database.CreateIfNotExists();
        }

        public DbSet<User> Users { get; set; }
    }
}

using data_editor.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

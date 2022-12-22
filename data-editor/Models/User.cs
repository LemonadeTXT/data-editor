using System;

namespace data_editor.Models
{
    public class User
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Status { get; set; }
        public DateTime RegisterDate { get; set; }
        public DateTime LastOnlineDate { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using data_editor.Connection;
using data_editor.Models;

namespace data_editor.Services
{
    public class UserService
    {
        private readonly DataContext _dataContext;

        public UserService()
        {
            _dataContext = new DataContext(new ConnectionDb().GetConnectionStringFromFile());
        }

        public List<User> GetAllUsers()
        {
            return _dataContext.Users.ToList();
        }

        public void Add(string userName, string password)
        {
            _dataContext.Users.Add(new User
            {
                UserName = userName,
                Password = password,
                Status = "user",
                RegisterDate = DateTime.Now,
                LastOnlineDate = DateTime.Now
            });

            _dataContext.SaveChanges();
        }

        public void AddFullUsers(List<User> users)
        {
            _dataContext.Users.AddRange(users);

            _dataContext.SaveChanges();
        }

        public void Delete(List<User> users)
        {
            _dataContext.Users.RemoveRange(users);

            _dataContext.SaveChanges();
        }

        public void Edit(User user)
        {
            var oldUser = _dataContext.Users.Find(user.Id);

            _dataContext.Entry(oldUser).CurrentValues.SetValues(user);

            _dataContext.SaveChanges();
        }

        public List<User> Find(string findText)
        {
            var users = GetAllUsers();

            if (string.IsNullOrEmpty(findText))
            {
                return users;
            }

            var foundedUsers = new List<User>();

            findText = findText.ToLower();

            foreach (var user in users)
            {
                if (user.Id.ToString().Contains(findText) ||
                    user.UserName.ToLower().Contains(findText) ||
                    user.Password.ToLower().Contains(findText) ||
                    user.Status.ToLower().Contains(findText) ||
                    user.RegisterDate.ToString().ToLower().Contains(findText) ||
                    user.LastOnlineDate.ToString().ToLower().Contains(findText))
                {
                    foundedUsers.Add(user);
                }
            }

            if (foundedUsers.Count is 0)
            {
                return users;
            }

            return foundedUsers;
        }
    }
}
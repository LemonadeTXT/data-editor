using System.Collections.Generic;
using System.IO;
using data_editor.Models;
using Newtonsoft.Json;

namespace data_editor.Services
{
    public class DataStorageJson
    {
        public List<User> Read()
        {
            return JsonConvert.DeserializeObject<List<User>>(File.ReadAllText("DataStorage.json"));
        }

        public void Write(List<User> users)
        {
            if (File.Exists("DataStorage.json"))
            {
                var newUsers = Read();

                if (newUsers != null)
                {
                    users.AddRange(newUsers);
                }
            }

            var usersSerialize = JsonConvert.SerializeObject(users);

            File.WriteAllText("DataStorage.json", usersSerialize);
        }
    }
}

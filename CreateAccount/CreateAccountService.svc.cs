using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using Newtonsoft.Json;

namespace CreateAccount
{
    public class Service1 : ICreateAccountService
    {
        public Boolean createAccount(string username, string password)
        {
            List<User> usersList = new List<User>();
            UsersRootObject obj = new UsersRootObject();
            string json; // for the final JSON string
            Boolean exists = false;
            Boolean created = false; 

            obj = JsonConvert.DeserializeObject<UsersRootObject>(File.ReadAllText(@"C:\Users\Harith Neralla\repos\cse-445-assignment-3\CreateAccount\user_credentials.json"));
            if (obj.users != null)
            {
                usersList = obj.users.ToList<User>();
                foreach (User user in usersList)
                {
                    if (user.username == username)
                    {
                        exists = true;
                    }
                }
            }
           
           if (!exists)
            {
                User newUser = new User();
                newUser.username = username;
                newUser.password = password;
                usersList.Add(newUser);
                obj.users = usersList.ToArray<User>();
                json = JsonConvert.SerializeObject(obj, Formatting.Indented);
                File.WriteAllText(@"C:\Users\Harith Neralla\repos\cse-445-assignment-3\CreateAccount\user_credentials.json", json);
                created = true;
            }

            return created;
        }

        public class UsersRootObject
        {
            public User[] users { get; set; }
        }

        public class User
        {
            public string username { get; set; }
            public string password { get; set; }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using Newtonsoft.Json;
using System.Text;
using System.Web;

namespace CreateAccount
{
    public class Service1 : ICreateAccountService
    {
        // Author: Harith Neralla
        // ASU CSE 445 Summer 2017
        // 06/17/2017

        // Service allows users to create new accounts. Username and password are accepted as 
        // parameters. An external JSON file is used to store account credentials. This file is also used to 
        // check if the entered username exists. The method returns a boolean value that lets the client
        // know if the new account has been created. 

        public class UsersRootObject
        {
            public User[] users { get; set; } // Array of users
        }

        // User class object
        public class User
        {
            public string username { get; set; }
            public string password { get; set; }
        }

        // Accepts username and password as parameters. Encrypts passwords and stores in a JSON file.
        // Creates an account; checks if the username already exists
        public Boolean createAccount(string username, string password)
        {
            User newUser = new User(); // User object for new user
            UsersRootObject usersObj = new UsersRootObject(); // Object of user
            List<User> usersList = new List<User>(); // List of users to read in existing data and add new users
            string json; // for the final JSON formatted list of users
            Boolean exists = false; // boolean value to check if the username exists
            Boolean created = false; // boolean value to return
            byte[] pwd; // byte array to store the encrypted password into
            string encryptedPass = ""; // string to store the encrypted password into


            string path = HttpRuntime.AppDomainAppPath + "\\user_credentials.json"; // File path to user credentials 

            try
            {
                string jsonData = File.ReadAllText(path); // reads in the JSON file into a string

                usersObj = JsonConvert.DeserializeObject<UsersRootObject>(jsonData); // transfers jsonData to the usersObj

                if (usersObj.users != null) // makes sure that there is at least one existing user to iterate through accounts
                {
                    usersList = usersObj.users.ToList<User>(); // transfers users to a List<User>

                    foreach (User user in usersList) // iterates through the users
                    {
                        if (user.username == username) // checks if the username already exists
                        {
                            exists = true;
                        }
                    }
                }

                if (!exists) // If username doesn't already exist
                {
                    pwd = Encoding.ASCII.GetBytes(password); // Encrypts the password

                    // Loop converts byte array to a string
                    foreach (byte digit in pwd)
                    {
                        encryptedPass += digit;
                    }

                    newUser.username = username;
                    newUser.password = encryptedPass;
                    usersList.Add(newUser); // adds the new user to the user list

                    usersObj.users = usersList.ToArray<User>(); // Converts the list to a User object array
                    json = JsonConvert.SerializeObject(usersObj, Formatting.Indented); // Converts object to JSON string
                    File.WriteAllText(path, json); // Writes JSON data to the file

                    created = true;
                }
            }
            finally
            {

            }
            
            return created; // Returns creation confirmation
        }

        
    }
}
﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace HomeWorkBencun
{
    public class User
    {
        #region Fields and Properties

        public int ID { get; set; }
        public string Name { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }

        #endregion

        #region Constructors
        public User()
        {

        }

        public User(int iD, string name, string userName, string email)
        {
            this.ID = iD;
            this.Name = name;
            this.UserName = userName;
            this.Email = email;
        }
        #endregion

        #region Methods

        /// <summary>
        /// Accept parameter int id between 1 - 10 and Return User as JSON string 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static async Task<string> GetUserJSONById(int id)
        {
            string userJson;

            HttpClient http = new HttpClient();

            if (id >= 1 && id <= 10)
            {
                //Console.WriteLine($"sending requests for:  {id}");

                userJson = await http.GetStringAsync($"https://jsonplaceholder.typicode.com/users/{id}");

                //Console.WriteLine($"srequests for:  {id} done");
            }
            else
            {
                userJson = "";
                Console.WriteLine("There is no User with that id.");
            }
            //Console.WriteLine(userJson);
            return userJson;
        }

        public static User DeserializeUserJSON(string userJson)
        {

            User s1 = JsonConvert.DeserializeObject<User>(userJson);

            return s1;

        }


        public void PrintUser()
        {
            Console.WriteLine($"Id: {ID}, Name: {Name}, User name: {UserName}, Email: {Email}.");
        }
        #endregion

    }
}
using Newtonsoft.Json;
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
        public User() {}

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
        public static async Task<string> GetUserJSONById(int id)
        {

            HttpClient http = new HttpClient();
                    Console.WriteLine($"Sending requests for User with ID:  {id}.");

            string userJson = await http.GetStringAsync($"https://jsonplaceholder.typicode.com/users/{id}");

                    Console.WriteLine($"Requests for User with ID:  {id} is done.");
            //Console.WriteLine(userJson);
            return userJson;
        }

        /// <summary>
        /// Prosleđeni JSON string deserijalizuje u objekat klase User
        /// </summary>
        public static User DeserializeUserJSON(string userJson)
        {
            User user = JsonConvert.DeserializeObject<User>(userJson);

            return user;
        }


        public void PrintUser()
        {
            Console.WriteLine($"Id: {ID}, Name: {Name}, UserName: {UserName}, Email: {Email}.");
        }
        #endregion

    }
}

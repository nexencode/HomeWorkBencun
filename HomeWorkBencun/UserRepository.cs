using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace HomeWorkBencun
{
    public static class UserRepository
    {
        /// <summary>
        ///Accept parameter int id between 1 - 10 and Return User as JSON string 
        /// </summary>
        public static async Task<string> GetUserJSONById(int id)
        {
            string userJson;

            HttpClient http = new HttpClient();

            if (id >= 1 && id <= 10)
            {
                Console.WriteLine($"Sending requests for User with ID:  {id}.");

                userJson = await http.GetStringAsync($"https://jsonplaceholder.typicode.com/users/{id}");

                Console.WriteLine($"Requests for User with ID:  {id} is done.");
            }
            else
            {
                userJson = "";
                Console.WriteLine("There is no User with that id.");
            }
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

        /// <summary>
        /// Ova funkcija preuzima korisnika upotrebom funkcije GetUserJSONById() a zatim ga deserijalizuje upotrebom funkcije DeserializeUserJSON() i taj objekat na kraju vraca kao rezultat svog izvršenja.
        /// </summary>
        public static async Task<User> GetAndDeserializeUserById(int id)
        {
            string userString = await GetUserJSONById(id);

            User u = DeserializeUserJSON(userString);

            return u;
        }
        public static void OnNewUser(object s, UserEventArgs e)
        {
            Console.WriteLine($"-----------------------------");

            e.User.PrintUser();

            Console.WriteLine($"-----------------------------");
        }
    }
}

using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWorkBencun
{
    class Program
    {
        static void Main(string[] args)
        {

            var u2 = GetAndDeserializeUserById(2).GetAwaiter().GetResult();

            u2.PrintUser();

            Console.WriteLine($"============================");


            Console.ReadKey();
        }

        /// <summary>
        /// Ova funkcija preuzima korisnika upotrebom funkcije GetUserJSONById() a zatim ga deserijalizuje upotrebom funkcije DeserializeUserJSON() i taj objekat na kraju vraca kao rezultat svog izvršenja.
        /// </summary>
        public static async Task<User> GetAndDeserializeUserById(int id)
        {
            string userString = await User.GetUserJSONById(id);

            User u = User.DeserializeUserJSON(userString);

            return u;
        }
    }
}

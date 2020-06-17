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
            //First part of home work
            #region 
            User user = GetAndDeserializeUserById(3).GetAwaiter().GetResult();
            user.PrintUser();
            #endregion

            Console.WriteLine($"==============================");


            //Second part of home work
            #region 
            UserFetcher userFetcher = new UserFetcher();

            userFetcher.NewUserAvailable += OnNewUser;


            List<int> ids = new List<int>() { 2, 4, 11, 5, 15, 6, 19 };

            userFetcher.GetAllUsers(ids).GetAwaiter().GetResult();

            #endregion


            Console.WriteLine("Press any key to exit from application...");
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

        public static void OnNewUser(object s, UserEventArgs e)
        {
            Console.WriteLine($"-----------------------------");

            e.User.PrintUser();

            Console.WriteLine($"-----------------------------");
        }

    }
}

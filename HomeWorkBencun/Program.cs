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
            User user = GetAndDeserializeUserById(2).GetAwaiter().GetResult();
            user.PrintUser();
            #endregion

            //Second part of home work
            #region 
            UserFetcher userFetcher = new UserFetcher();

            userFetcher.NewUserAvailable += OnNewUser;

            List<int> ids = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9 };

            userFetcher.GetAllUsers(ids);
            #endregion


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

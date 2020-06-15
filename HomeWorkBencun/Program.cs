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
            UserFetcher userFetcher = new UserFetcher();

            userFetcher.NewUserAvailable += UserRepository.OnNewUser;

            List<int> ids = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9 };

            userFetcher.GetAllUsers(ids);

            Console.ReadKey();
        }
    }
}

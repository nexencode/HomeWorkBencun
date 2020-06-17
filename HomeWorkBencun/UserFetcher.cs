using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWorkBencun
{
    public class UserFetcher
    {
        public event EventHandler<UserEventArgs> NewUserAvailable;

        public async Task GetAllUsers(List<int> usersIdList)
        {
            foreach (int id in usersIdList)
            {
                try
                {
                    if (id >= 1 && id <= 10)
                    {
                        var user = await Program.GetAndDeserializeUserById(id);

                        NewUserAvailable?.Invoke(this, new UserEventArgs(user));
                    }
                    else
                    {
                        var user = await Program.GetAndDeserializeUserById(id);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"=======================");

                    Console.WriteLine(ex.Message);

                    Console.WriteLine($"There is no user with id: {id}");

                    Console.WriteLine($"=======================");

                }
            }
        }
    }
}

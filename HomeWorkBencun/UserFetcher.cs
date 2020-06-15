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

        public async void GetAllUsers(List<int> usersIdList)
        {
            foreach (int id in usersIdList)
            {
                var user = await Program.GetAndDeserializeUserById(id);

                var del = NewUserAvailable as EventHandler<UserEventArgs>;

                if (NewUserAvailable != null)
                {
                    del(this, new UserEventArgs(user));
                }
            }
        }
    }
}

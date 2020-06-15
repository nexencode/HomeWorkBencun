using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWorkBencun
{
    public class UserEventArgs : EventArgs
    {
        public User User { get; private set; }

        public UserEventArgs(User user)
        {
            this.User = user;
        }
    }
}

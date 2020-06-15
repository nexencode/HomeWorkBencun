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
        public void PrintUser()
        {
            Console.WriteLine($"Id: {ID}, Name: {Name}, UserName: {UserName}, Email: {Email}.");
        }
        #endregion

    }
}

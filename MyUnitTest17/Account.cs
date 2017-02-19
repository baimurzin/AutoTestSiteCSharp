using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyUnitTest17
{
    public class Account
    {
        public Account(string login, string pass)
        {
            this.Username = login;
            this.Password = pass;
        }

        public String Username { get; set; }
        public String Password { get; set; }
    }
}

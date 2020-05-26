using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentsTesting1.Logic.Users
{
    abstract class User
    {
        public string firstName { get; protected set; }
        public string lastName { get; protected set; }

        public User(string FirstName, string LastName)
        {
            firstName = FirstName;
            lastName = LastName;
        }
    }
}

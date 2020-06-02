using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using StudentsTesting1.Logic.Users;

namespace StudentsTesting1.Views
{
    public class AccountView
    {
        public int ID { get; set; }
        public string login { get; set; }
        public string role { get; set; }

        public AccountView(int id, string Login, string Role)
        {
            ID = id;
            login = Login;
            role = Role;
        }
    }
}

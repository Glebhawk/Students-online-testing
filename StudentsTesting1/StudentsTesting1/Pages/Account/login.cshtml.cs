using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using StudentsTesting1.Logic.Users;
using StudentsTesting1.DataAccess;
using System.ComponentModel.DataAnnotations;

namespace StudentsTesting1.Pages
{
    public class loginModel : PageModel
    {
        [Required(ErrorMessage = "Не вказано логін!")]
        public string login { get; set; }

        [Required(ErrorMessage = "Не введений пароль!")]
        [DataType(DataType.Password)]
        public string password { get; set; }
        public void OnGet()
        {

        }
    }
}
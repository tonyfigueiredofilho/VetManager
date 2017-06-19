using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VetManager.Models
{
    public class UsersModelView
    {
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public System.DateTime BirthDate { get; set; }
        public int Profile { get; set; }
        public string Senha { get; set; }
    }
}
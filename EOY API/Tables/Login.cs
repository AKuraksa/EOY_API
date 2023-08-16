using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace EOY_API.Tables

{
    public class Login
    {

        public int id { get; set; }


        public string username { get; set; }

        public string password { get; set; }

        public string email { get; set; }

        public string First_name { get; set; }

        public string Last_name { get; set; }
    }
}

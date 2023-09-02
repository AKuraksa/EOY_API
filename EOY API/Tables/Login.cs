using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

using System.Text.Json;
using System.Text.Json.Serialization;


namespace EOY_API.Tables

{
    public class Login
    {

        public Guid id { get; set; }

        
        public string Username { get; set; }

    
        public string Password { get; set; }

        [EmailAddress]
        public string Email { get; set; }
     
        public string FirstName { get; set; }
      
        public string LastName { get; set; }

        public bool Permission { get; set; }
    }
}

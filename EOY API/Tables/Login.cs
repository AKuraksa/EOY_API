using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace EOY_API.Tables

{
    public class Login
    {
       
        int id { get; set; }

        
        string username { get; set; }
        
        string password { get; set; }
       
        string email { get; set; }
      
        string First_name { get; set; }
     
        string Last_name { get; set; }
    }
}

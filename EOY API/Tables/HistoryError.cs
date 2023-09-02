using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

using System.Text.Json;
using System.Text.Json.Serialization;


namespace EOY_API.Tables

{
    public class HistoryError
    {

        public Guid id { get; set; }

        
        public DateTime Date { get; set; }

    
        public string TypeError { get; set; }

        [EmailAddress]
        public string WorkPlace { get; set; }
     
       
    }
}

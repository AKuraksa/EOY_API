using Microsoft.EntityFrameworkCore;
namespace EOY_API.Tables
{
    public class Workplace
    {
        public Guid ID { get; set; }
        public string WorkplaceName { get; set; }
        public string Ip { get; set; }
        public string Mac { get; set; }
        public bool State { get; set; }
        public string DeviceName { get; set; }
        public string? UserLogged { get; set; }

        public bool GetHELP { get; set; }
        public bool GetINFO { get; set; }
     


    }
}

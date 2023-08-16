using Microsoft.EntityFrameworkCore;
namespace EOY_API.Tables
{
    public class Workplace
    {
        public int ID { get; set; }
        public string Name_Workplace { get; set; }
        public string IP { get; set; }
        public string MAC { get; set; }
        public string STATE { get; set; }
        public string Name_device { get; set; }

        public string GetHELP { get; set; }
        public string GetINFO { get; set; }
     


    }
}

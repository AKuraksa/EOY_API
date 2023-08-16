using Microsoft.EntityFrameworkCore;
namespace EOY_API.Tables
{
    public class Workplace
    {
        int ID { get; set; }
        string Name_Workplace { get; set; }
        string IP { get; set; }
        string MAC { get; set; }
        string STATE { get; set; }
        string Name_device { get; set; }
        
        string GetHELP { get; set; }
        string GetINFO { get; set; }
     


    }
}

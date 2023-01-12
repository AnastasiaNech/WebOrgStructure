using WebAPICalendar.DataContract;
using WebSiteOrgStructure.Models;

namespace WebSiteOrgStructure.Data.Models;

public class Str_Calendar
{
    public DateTime Date { get; set; }
    public List<Day> Days { get; set; } 
    public List<string> DaysName { get; set; }
    public List<Event> Events { get; set; }
}

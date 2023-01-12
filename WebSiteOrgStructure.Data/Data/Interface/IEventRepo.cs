using WebSiteOrgStructure.Models;

namespace WebSiteOrgStructure.Data.Interface;

public interface IEventRepo
{
    Task<List<Event>> GetEventAsync();
    Task CreateEventAsync(Event eventCalendar);
    Task SaveChangesAsync();
}
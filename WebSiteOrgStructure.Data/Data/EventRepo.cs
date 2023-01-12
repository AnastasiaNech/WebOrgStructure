using Microsoft.EntityFrameworkCore;
using OnlyOrgStructure.Data;
using WebSiteOrgStructure.Data.Interface;
using WebSiteOrgStructure.Models;

namespace WebSiteOrgStructure.Data;

public class EventRepo : IEventRepo
{
    private readonly DbContextConfigurer _context;

    public EventRepo(DbContextConfigurer context)
    {
        _context = context;
    }

    public async Task<List<Event>> GetEventAsync()
    {
        return await _context.Events
            .AsQueryable()
            .ToListAsync();
    }

    public async Task CreateEventAsync(Event eventCalendar)
    {
        ArgumentNullException.ThrowIfNull(eventCalendar);
        await _context.AddAsync(eventCalendar);
    }
    public async Task SaveChangesAsync()
    {
        await _context.SaveChangesAsync();
    }
}
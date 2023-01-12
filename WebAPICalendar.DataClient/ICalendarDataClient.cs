using WebAPICalendar.DataContract;

namespace WebAPICalendar.DataClient;

public interface ICalendarDataClient
{
    Task<Calendar> GetDayNowAsync();
}

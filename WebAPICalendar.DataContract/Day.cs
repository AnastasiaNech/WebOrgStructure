namespace WebAPICalendar.DataContract;
public class Day
{
    public int DayNumber { get; set; }
    public int MonthNumber { get; set; }
    public string? DayName { get; set; }
    public bool IsWeekendOrHoliday { get; set; }
    public bool IsToday { get; set; }
}

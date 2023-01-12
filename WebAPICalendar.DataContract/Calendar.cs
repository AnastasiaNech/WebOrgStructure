namespace WebAPICalendar.DataContract;
public class Calendar
{

   public DateTime Date { get; set; }

   public List<Day> Days { get; set; }

  public List<string> DaysName { get; set; }

}

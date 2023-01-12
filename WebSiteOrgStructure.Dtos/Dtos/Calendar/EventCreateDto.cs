namespace WebSiteOrgStructure.Dtos;
public class EventCreateDto
{
    public int DayNumber { get; set; }
    public int MonthNumber { get; set; }
    public string? UserInfo { get; set; }
    public string? DayName { get; set; }
    public string? EventText { get; set; }
}
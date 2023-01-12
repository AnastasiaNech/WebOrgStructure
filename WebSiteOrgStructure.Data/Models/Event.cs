using System.ComponentModel.DataAnnotations;

namespace WebSiteOrgStructure.Models;
public class Event
{
    [Key]
    public Guid Id { get; set; }

    public int DayNumber { get; set; }
    public int MonthNumber { get; set; }
    public string? DayName { get; set; }

    [Display(Name = "Пользователь")]
    public string? UserInfo { get; set; }

    [Display(Name = "Событие")]
    public string? EventText { get; set; }
}

using Microsoft.AspNetCore.Mvc;
using Nancy;
using Nancy.Json;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Net.Http;
using System.Runtime.Serialization;
using System.Text;
using System.Text.Json;
using System.Xml;
using System.Xml.Serialization;
using WebAPICalendar.Model;

namespace WebAPICalendar.Controllers;

[ApiController]
[Route("[controller]")]
public class CalendarController : Controller
{
    [HttpGet]
    public Calendar GetDayNow()
    {
        DateTime date = DateTime.Now;
        int daysCount = DateTime.DaysInMonth(date.Year, date.Month);
        List<Day> days = new List<Day>();
        for (int day = 1; day <= daysCount; ++day)
        {
            string dayName = new DateTime(date.Year, date.Month, day).ToString("dddd");
            days.Add(new Day()
            {
                DayNumber = day,
                MonthNumber = date.Month,
                DayName = dayName,
                IsWeekendOrHoliday = dayName == "суббота" || dayName == "воскресенье",
                IsToday = day == DateTime.Today.Day
            });
        }
        Calendar calendar = new Calendar()
        {
            Date = DateTime.Now,
            Days = days,
            DaysName = this.GetDaysName(),
        };
        return calendar;
    }

    private List<string> GetDaysName()    
    {
        return new List<string>()
       {
           "Понедельник",
           "Вторник",
           "Среда",
           "Четверг",
           "Пятница",
           "Суббота",
           "Воскресенье"
       };
    }
}


using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WebAPICalendar.DataClient;
using WebAPICalendar.DataContract;
using WebSiteOrgStructure.Data.Interface;
using WebSiteOrgStructure.Data.Models;

namespace WebSiteOrgStructure.Controllers
{
    public class CalendarController : Controller
    {
        private readonly ICalendarDataClient _calendarDataClient;
        private readonly IMapper _mapper;
        private readonly IEventRepo _repo;

        public CalendarController(ICalendarDataClient calendarDataClient, 
        IMapper mapper,
        IEventRepo repo)

        {
            _mapper = mapper;
            _repo = repo;
            _calendarDataClient = calendarDataClient;
        }

        public IActionResult Index()
        {
            Calendar calendar  = _calendarDataClient.GetDayNowAsync().Result;
            Str_Calendar cal = _mapper.Map<Str_Calendar>(calendar);
            cal.Events = _repo.GetEventAsync().Result;
            ViewBag.ParentEvents = cal;
            return View(cal);
        }
    }
}

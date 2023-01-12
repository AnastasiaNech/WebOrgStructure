using MediatR;
using Microsoft.AspNetCore.Mvc;
using WebSiteOrgStructure.Dtos;
using WebSiteOrgStructure.MediatRAPi;

namespace WebSiteOrgStructure.Controllers;

public class EventController : Controller
{
    private readonly IMediator _mediator;

    public EventController(IMediator mediator)

    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task Create(EventCreateDto eventCalendar)
    {
        await _mediator.Send(new EventRequest() { eventCreateDto = eventCalendar });
    }
}
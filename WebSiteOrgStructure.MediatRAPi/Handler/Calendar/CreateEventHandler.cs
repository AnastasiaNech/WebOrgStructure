using MediatR;
using WebSiteOrgStructure.BLL;
using WebSiteOrgStructure.Dtos;

namespace WebSiteOrgStructure.MediatRAPi;
public class EventRequest : IRequest<EventReadDto>
{
    public EventCreateDto? eventCreateDto { get; set; }
}

public class CreateEventHandler : IRequestHandler<EventRequest, EventReadDto>
{
    private readonly IEventBLL _eventBLL;

    public CreateEventHandler(IEventBLL eventBLL)
    {
        _eventBLL = eventBLL;
    }
    public async Task<EventReadDto> Handle(EventRequest request, CancellationToken cancellation = default)
    {
        return await _eventBLL.CreateAsync(request.eventCreateDto);
    }
}
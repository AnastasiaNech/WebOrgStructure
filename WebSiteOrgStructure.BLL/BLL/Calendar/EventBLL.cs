using AutoMapper;
using WebSiteOrgStructure.Data.Interface;
using WebSiteOrgStructure.Dtos;
using WebSiteOrgStructure.Models;

namespace WebSiteOrgStructure.BLL;
public class EventBLL : IEventBLL
{
    private readonly IMapper _mapper;
    private readonly IEventRepo _repo;
    public EventBLL(
        IMapper mapper,
        IEventRepo repo)
    {
        _mapper = mapper;
        _repo = repo;
    }

    public async Task<EventReadDto> CreateAsync(EventCreateDto eventCreateDto)
    {
        var eventModel = _mapper.Map<Event>(eventCreateDto);
        await _repo.CreateEventAsync(eventModel);
        await _repo.SaveChangesAsync();
        return _mapper.Map<EventReadDto>(eventModel);
    }
}
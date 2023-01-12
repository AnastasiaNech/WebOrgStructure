using WebSiteOrgStructure.Dtos;

namespace WebSiteOrgStructure.BLL;
public interface IEventBLL
{
    Task<EventReadDto> CreateAsync(EventCreateDto eventCreateDto);
}

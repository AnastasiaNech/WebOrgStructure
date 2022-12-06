using WebSiteOrgStructure.Dtos;

namespace WebSiteOrgStructure.BLL;

public interface IUserBLL
{
    Task<UserReadDto> CreateAsync(UserCreateDto user);
    Task<List<UserReadDto>> GetUsersListAsync();
    List<DepartmentStructDto> GetCountUserAndRole();
}

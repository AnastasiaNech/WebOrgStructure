using WebSiteOrgStructure.Dtos;

namespace WebSiteOrgStructure.BLL;
public interface IUserBLL
{
    Task<UserReadDto> CreateAsync(UserCreateDto user);
    Task UpdateAsync(UserUpdateDto user);
    Task<UserReadDto> GetAsync(Guid id);
    Task DeleteAsync(Guid userId);
    Task<List<UserReadDto>> GetUsersListAsync();
    Task<List<DepartmentStructDto>> GetCountUserAndRole();
}

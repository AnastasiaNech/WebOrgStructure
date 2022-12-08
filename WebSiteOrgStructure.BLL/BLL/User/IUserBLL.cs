using System.Collections.Generic;
using WebSiteOrgStructure.Dtos;

namespace WebSiteOrgStructure.BLL;

public interface IUserBLL
{
    Task<UserReadDto> CreateAsync(UserCreateDto user);
    Task<List<UserReadDto>> GetUsersListAsync();
    Task<List<DepartmentStructDto>> GetCountUserAndRole();
}

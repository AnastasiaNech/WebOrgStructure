using WebSiteOrgStructure.Models;

namespace WebSiteOrgStructure.Data.Interface;

public interface IUserRepo
{
    Task CreateUserAsync(User user);
    Task<List<DepartmentStruct>> GetCountUserAndRole();
    Task<List<User>> GetUsersListAsync();
    Task SaveChangesAsync();
}
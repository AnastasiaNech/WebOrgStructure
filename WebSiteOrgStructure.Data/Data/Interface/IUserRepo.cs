using WebSiteOrgStructure.Models;

namespace WebSiteOrgStructure.Data.Interface;
public interface IUserRepo
{
    Task CreateUserAsync(User user);
    void DeleteUserAsync(User user);
    Task<User?> GetUserByIdAsync(Guid userId);
    Task<List<DepartmentStruct>> GetCountUserAndRole();
    Task<List<User>> GetUsersListAsync();
    Task SaveChangesAsync();
}
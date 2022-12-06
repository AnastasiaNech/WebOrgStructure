using OfficeOpenXml.FormulaParsing.Excel.Functions.Math;
using WebSiteOrgStructure.Dtos;
using WebSiteOrgStructure.Models;

namespace WebSiteOrgStructure.Data.Interface;

public interface IUserRepo
{
    Task CreateUserAsync(User user);
    List<DepartmentStruct> GetCountUserAndRole();
    Task<List<User>> GetUsersListAsync();
    Task SaveChangesAsync();
}
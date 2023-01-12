using WebSiteOrgStructure.Models;

namespace WebSiteOrgStructure.Data.Interface;

public interface IDepartmentRepo
{
    Task CreateDepartmentAsync(Department department);
    Task<List<Department>> GetDepartmentsListAsync();
    Task SaveChangesAsync();
}

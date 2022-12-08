using WebSiteOrgStructure.Models;

namespace WebSiteOrgStructure.Data.Interface;

public interface IDepartmentRepo
{
    List<string?> GetDepartmentList(string departmentName);
    Task<List<Department>> GetDepartmentsListAsync();
}

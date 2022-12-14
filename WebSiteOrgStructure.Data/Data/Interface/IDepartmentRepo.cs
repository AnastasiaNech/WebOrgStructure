using OfficeOpenXml.FormulaParsing.Excel.Functions.Math;
using WebSiteOrgStructure.Models;

namespace WebSiteOrgStructure.Data.Interface;

public interface IDepartmentRepo
{
    Task CreateDepartmentAsync(Department department);
    List<string?> GetDepartmentList(string departmentName);
    Task<List<Department>> GetDepartmentsListAsync();
    Task SaveChangesAsync();
}

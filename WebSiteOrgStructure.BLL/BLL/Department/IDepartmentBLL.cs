using WebSiteOrgStructure.Dtos;

namespace WebSiteOrgStructure.BLL;

public interface IDepartmentBLL
{
    Task<List<DepartmentReadDto>> GetDepartmentsListAsync();
}

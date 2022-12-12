using WebSiteOrgStructure.Dtos;

namespace WebSiteOrgStructure.BLL;

public interface IDepartmentBLL
{
    Task<DepartmentReadDto> CreateAsync(DepartmentCreateDto department);
    Task<List<DepartmentReadDto>> GetDepartmentsListAsync();
}

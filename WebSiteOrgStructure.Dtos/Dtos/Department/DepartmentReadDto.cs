namespace WebSiteOrgStructure.Dtos;

public class DepartmentReadDto
{
    public Guid Id { get; set; }
    public string? DepartmentName { get; set; }
    public string? ParentDepartmentName { get; set; }
}

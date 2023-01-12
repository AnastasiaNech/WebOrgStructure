namespace WebSiteOrgStructure.Dtos;

public class OrganizationalStructureDto
{
    public Guid Id { get; set; }
    public string? DepartmentName { get; set; }
    public string? ParentDepartmentName { get; set; }
    public string? Role { get; set; }
    public string? Name { get; set; }
    public string? Surname { get; set; }
}


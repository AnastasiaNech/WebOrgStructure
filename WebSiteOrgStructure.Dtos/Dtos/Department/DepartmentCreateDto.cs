namespace WebSiteOrgStructure.Dtos;
public class DepartmentCreateDto
{
    public string? DepartmentName { get; set; }
    public string? ParentDepartmentName { get; set; }
    public string? CheckParent { get; set; }
}
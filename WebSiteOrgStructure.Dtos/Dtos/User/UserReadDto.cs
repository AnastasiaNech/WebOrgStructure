namespace WebSiteOrgStructure.Dtos;

public class UserReadDto
{
    public Guid Id { get; set; }
    public string? Name { get; set; }
    public string? Surname { get; set; }
    public string? Mail { get; set; }
    public string? Role { get; set; }
    public string? DepartmentName { get; set; }
}

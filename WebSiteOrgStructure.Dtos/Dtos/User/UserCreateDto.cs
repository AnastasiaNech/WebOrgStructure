using System.ComponentModel.DataAnnotations;

namespace WebSiteOrgStructure.Dtos;
public class UserCreateDto
{
    [Required]
    public string? Name { get; set; }
    public string? Surname { get; set; }
    public string? Mail { get; set; }
    public string? Role { get; set; }
    public string? DepartmentName { get; set; }
}
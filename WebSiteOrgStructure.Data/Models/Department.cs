using System.ComponentModel.DataAnnotations;

namespace WebSiteOrgStructure.Models;

public class Department
{
    [Key]
    public Guid Id { get; set; }
    public string? DepartmentName { get; set; }
    public string? ParentDepartmentName { get; set; }
}

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebSiteOrgStructure.Models;

public class Department
{
    [Key]
    public Guid Id { get; set; }

    [Display(Name = "Введите название")]
    [Required(ErrorMessage = "Вам нужно ввести имя")]
    public string? DepartmentName { get; set; }

    [Display(Name = "Укажите родительское подразделение")]
    public string? ParentDepartmentName { get; set; }

    [NotMapped]
    public string? CheckParent { get; set; } = "Yes";
}

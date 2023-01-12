using System.ComponentModel.DataAnnotations;

namespace WebSiteOrgStructure.Dtos;
public class UserReadDto
{
    public Guid Id { get; set; }
    
    [Display(Name = "Введите имя")]
    [Required(ErrorMessage = "Вам нужно ввести имя")]
    public string? Name { get; set; }

    [Display(Name = "Введите фамилию")]
    public string? Surname { get; set; }

    [Display(Name = "Почта")]
    public string? Mail { get; set; }

    [Display(Name = "Должность")]
    public string? Role { get; set; }

    [Display(Name = "Департамент")]
    public string? DepartmentName { get; set; }
}

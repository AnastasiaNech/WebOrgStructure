using System.ComponentModel.DataAnnotations;

namespace WebSiteOrgStructure.Dtos;
public class UserUpdateDto: UserCreateDto
{
    public Guid Id { get; set; }
}
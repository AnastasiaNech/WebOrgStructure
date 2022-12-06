namespace WebSiteOrgStructure.Data.Interface;

public interface IDepartmentRepo
{
    List<string?> GetDepartmentList(string departmentName);
}

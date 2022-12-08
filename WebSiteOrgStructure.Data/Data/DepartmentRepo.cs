using Microsoft.EntityFrameworkCore;
using OnlyOrgStructure.Data;
using WebSiteOrgStructure.Data.Interface;
using WebSiteOrgStructure.Models;

namespace WebSiteOrgStructure.Data;

public class DepartmentRepo : IDepartmentRepo
{
    private readonly DbContextConfigurer _context;

    public DepartmentRepo(DbContextConfigurer context)
    {
        _context = context;
    }

    public List<string?> GetDepartmentList(string departmentName)
    {
        return _context.Departments
       .AsQueryable()
       .Where(x => x.ParentDepartmentName == departmentName)
       .Select(x => x.DepartmentName)
       .Distinct()
       .ToList();
    }

    public async Task<List<Department>> GetDepartmentsListAsync()
    {
        return await _context.Departments
            .AsQueryable()
            .ToListAsync();
    }
}

using Microsoft.EntityFrameworkCore;
using OfficeOpenXml.FormulaParsing.Excel.Functions.Math;
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

    public async Task CreateDepartmentAsync(Department department)
    {
        ArgumentNullException.ThrowIfNull(department);
        ArgumentNullException.ThrowIfNull(department.DepartmentName);
        await _context.AddAsync(department);
    }

    public async Task<List<Department>> GetDepartmentsListAsync()
    {
        return await _context.Departments
            .AsQueryable()
            .ToListAsync();
    }

    public async Task SaveChangesAsync()
    {
        await _context.SaveChangesAsync();
    }
}

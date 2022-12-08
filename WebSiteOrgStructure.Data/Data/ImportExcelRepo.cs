using OfficeOpenXml;
using AutoMapper;
using OnlyOrgStructure.Data;
using WebSiteOrgStructure.Data.Interface;
using WebSiteOrgStructure.Dtos;
using WebSiteOrgStructure.Models;

namespace WebSiteOrgStructure.Data;

public class ImportExcelRepo : IImportExcelRepo
{
    private readonly IMapper _mapper;
    private DbContextConfigurer _context;

    public ImportExcelRepo(IMapper mapper, DbContextConfigurer context)
    {
        _mapper = mapper;
        _context = context;
    }

    public Task ImportExcelAsync(ExcelPackage package)
    {
        try
        {

            var list = new List<OrganizationalStructureDto>();
            ExcelWorksheet worksheet = package.Workbook.Worksheets[0];
            var rowcount = worksheet.Dimension.Rows;
            for (int row = 2; row <= rowcount; row++)
            {
                list.Add(new OrganizationalStructureDto
                {
                    Id = Guid.NewGuid(),
                    DepartmentName = worksheet.Cells[row, 1].Value?.ToString().Trim(),
                    ParentDepartmentName = worksheet.Cells[row, 2].Value?.ToString().Trim(),
                    Role = worksheet.Cells[row, 3].Value?.ToString().Trim(),
                    Surname = worksheet.Cells[row, 4].Value?.ToString().Substring(0, (int)(worksheet.Cells[row, 4].Value?.ToString().IndexOf(" "))),
                    Name = worksheet.Cells[row, 4].Value?.ToString().Substring((int)worksheet.Cells[row, 4].Value?.ToString().IndexOf(" ") + 1)
                });
            }
            _context.Departments.AddRange(list.Select(x => _mapper.Map<Department>(x)));
            _context.Users.AddRange(list.Select(x => _mapper.Map<User>(x)));
            _context.SaveChanges();
            return Task.FromResult(true);
            
        }
        catch 
        {
            return Task.FromResult(false);
        }
    }
}
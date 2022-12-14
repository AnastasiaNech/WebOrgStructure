using AutoMapper;
using OfficeOpenXml.FormulaParsing.Excel.Functions.Math;
using WebSiteOrgStructure.BLL;
using WebSiteOrgStructure.Data.Interface;
using WebSiteOrgStructure.Dtos;
using WebSiteOrgStructure.Models;

public class DepartmentBLL : IDepartmentBLL
{
    private readonly IMapper _mapper;
    private readonly IDepartmentRepo _repo;
    public DepartmentBLL(
        IMapper mapper,
        IDepartmentRepo repo)
    {
        _mapper = mapper;
        _repo = repo;
    }
    public async Task<List<DepartmentReadDto>> GetDepartmentsListAsync()
    {
        var departments = await _repo.GetDepartmentsListAsync();
        return _mapper.Map<List<DepartmentReadDto>>(departments);
    }

    public async Task<DepartmentReadDto> CreateAsync(DepartmentCreateDto department)
    {
        var departmentModel = _mapper.Map<Department>(department);
        await _repo.CreateDepartmentAsync(departmentModel);
        await _repo.SaveChangesAsync();
        return _mapper.Map<DepartmentReadDto>(departmentModel);
    }  
    
}
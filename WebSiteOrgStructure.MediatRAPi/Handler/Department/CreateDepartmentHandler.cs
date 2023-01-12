using MediatR;
using WebSiteOrgStructure.BLL;
using WebSiteOrgStructure.Dtos;

namespace WebSiteOrgStructure.MediatRAPi;
public class DepartmentRequest : IRequest<DepartmentReadDto>
{
    public DepartmentCreateDto? departmentCreateDto{ get; set; }
}

public class CreateDepartmentHandler : IRequestHandler<DepartmentRequest, DepartmentReadDto>
{
    private readonly IDepartmentBLL _departmentBLL;

    public CreateDepartmentHandler(IDepartmentBLL departmentBLL)
    {
        _departmentBLL = departmentBLL;
    }
    public async Task<DepartmentReadDto> Handle(DepartmentRequest request, CancellationToken cancellation = default)
    {
        return await _departmentBLL.CreateAsync(request.departmentCreateDto);
    }
}
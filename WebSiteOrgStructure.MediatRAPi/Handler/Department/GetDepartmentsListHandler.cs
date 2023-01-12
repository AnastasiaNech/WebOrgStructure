using MediatR;
using WebSiteOrgStructure.BLL;
using WebSiteOrgStructure.Dtos;

namespace WebSiteOrgStructure.MediatRAPi;

public record GetDepartmentsRequest : IRequest<List<DepartmentReadDto>>;

public class GetDepartmentsListHandler : IRequestHandler<GetDepartmentsRequest, List<DepartmentReadDto>>
{
    private readonly IDepartmentBLL _departmentBLL;

    public GetDepartmentsListHandler(IDepartmentBLL departmentBLL)
    {
        _departmentBLL = departmentBLL;
    }

    public async Task<List<DepartmentReadDto>> Handle(GetDepartmentsRequest request, CancellationToken cancellation = default)
    {
        return await _departmentBLL.GetDepartmentsListAsync();
    }
}
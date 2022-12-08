using MediatR;
using WebSiteOrgStructure.BLL;
using WebSiteOrgStructure.Dtos;

namespace WebSiteOrgStructure.MediatRAPi;

public record GetCountUserAndRoleRequest : IRequest<List<DepartmentStructDto>>;

public class GetCountUserAndRoleHandler : IRequestHandler<GetCountUserAndRoleRequest, List<DepartmentStructDto>>
{
    private readonly IUserBLL _userBLL;

    public GetCountUserAndRoleHandler(IUserBLL userBLL)
    {

        _userBLL = userBLL;
    }

    public async Task<List<DepartmentStructDto>> Handle(GetCountUserAndRoleRequest request, CancellationToken cancellation = default)
    {
        return await _userBLL.GetCountUserAndRole();
    }
}
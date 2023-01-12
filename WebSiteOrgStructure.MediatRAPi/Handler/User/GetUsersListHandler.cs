using MediatR;
using WebSiteOrgStructure.BLL;
using WebSiteOrgStructure.Dtos;

namespace WebSiteOrgStructure.MediatRAPi;

public record GetUsersListRequest : IRequest<List<UserReadDto>>;

public class GetUsersListHandler : IRequestHandler<GetUsersListRequest, List<UserReadDto>>
{
    private readonly IUserBLL _userBLL;

    public GetUsersListHandler(IUserBLL userBLL)
    {
        _userBLL = userBLL;
    }

    public async Task<List<UserReadDto>> Handle(GetUsersListRequest request, CancellationToken cancellation = default)
    {
        return await _userBLL.GetUsersListAsync();
    }
}
using MediatR;
using WebSiteOrgStructure.BLL;
using WebSiteOrgStructure.Dtos;

namespace WebSiteOrgStructure.MediatRAPi;

public class GetUserRequest : IRequest<UserReadDto>
{
    public Guid id { get; set; }
}

public class GetUserHandler : IRequestHandler<GetUserRequest, UserReadDto>
{
    private readonly IUserBLL _userBLL;

    public GetUserHandler(IUserBLL userBLL)
    {
        _userBLL = userBLL;
    }

    public async Task<UserReadDto> Handle(GetUserRequest request, CancellationToken cancellation = default)
    {
        return await _userBLL.GetAsync(request.id);
    }
}

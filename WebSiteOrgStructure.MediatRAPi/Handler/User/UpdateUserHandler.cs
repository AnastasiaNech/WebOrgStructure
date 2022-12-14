using MediatR;
using WebSiteOrgStructure.BLL;
using WebSiteOrgStructure.Dtos;

namespace WebSiteOrgStructure.MediatRAPi;

public class UserUpdateRequest : IRequest
{
    public UserUpdateDto? userUpdateDto { get; set; }
}

public class UpdateUserHandler : AsyncRequestHandler<UserUpdateRequest>
{
    private readonly IUserBLL _userBLL;

    public UpdateUserHandler(IUserBLL userBLL)
    {

        _userBLL = userBLL;
    }

    protected override Task Handle(UserUpdateRequest request, CancellationToken cancellation = default)
    {
        return _userBLL.UpdateAsync(request.userUpdateDto);
    }
}

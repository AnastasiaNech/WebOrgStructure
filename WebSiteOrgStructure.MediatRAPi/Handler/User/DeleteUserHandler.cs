using MediatR;
using WebSiteOrgStructure.BLL;
using WebSiteOrgStructure.Dtos;

namespace WebSiteOrgStructure.MediatRAPi;


public class DeleteUserRequest : IRequest
{
    public Guid userId { get; set; }
}

public class DeleteUserHandler : AsyncRequestHandler<DeleteUserRequest>
{ 
    private readonly IUserBLL _userBLL;

    public DeleteUserHandler(IUserBLL userBLL)
    {

        _userBLL = userBLL;
    }

    protected override Task Handle(DeleteUserRequest request, CancellationToken cancellation = default)
    {
        return _userBLL.DeleteAsync(request.userId);
    }

}
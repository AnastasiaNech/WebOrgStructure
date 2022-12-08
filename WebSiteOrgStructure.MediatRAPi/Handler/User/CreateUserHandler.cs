using MediatR;
using WebSiteOrgStructure.BLL;
using WebSiteOrgStructure.Dtos;

namespace WebSiteOrgStructure.MediatRAPi;

public class CreateUserRequest : IRequest<UserReadDto>
{
    public UserCreateDto? userCreateDto { get; set; }
}

public class CreateUserHandler : IRequestHandler<CreateUserRequest, UserReadDto>
{
    private readonly IUserBLL _userBLL;

    public CreateUserHandler(IUserBLL userBLL)
    {

        _userBLL = userBLL;
    }

    public async Task<UserReadDto> Handle(CreateUserRequest request, CancellationToken cancellation = default)
    {
        return await _userBLL.CreateAsync(request.userCreateDto);
    }
}

using AutoMapper;
using WebSiteOrgStructure.Data.Interface;
using WebSiteOrgStructure.Dtos;
using WebSiteOrgStructure.Models;

namespace WebSiteOrgStructure.BLL;

public class UserBLL: IUserBLL
{
    private readonly IMapper _mapper;
    private readonly IUserRepo _repo;
    public UserBLL(
        IMapper mapper,
        IUserRepo repo)
    {
        _mapper = mapper;
        _repo = repo;
    }
    public async Task<UserReadDto> CreateAsync(UserCreateDto user)
    {
        var userModel = _mapper.Map<User>(user);
        await _repo.CreateUserAsync(userModel);
        await _repo.SaveChangesAsync();
        return _mapper.Map<UserReadDto>(userModel);
    }

    public async Task<List<DepartmentStructDto>> GetCountUserAndRole()
    {
        var departmentStructs = await _repo.GetCountUserAndRole();
        return _mapper.Map<List<DepartmentStructDto>>(departmentStructs);
    }

    public async Task<List<UserReadDto>> GetUsersListAsync()
    {
        var users = await _repo.GetUsersListAsync();
        return _mapper.Map<List<UserReadDto>>(users);
    }

}

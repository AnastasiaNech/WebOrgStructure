using AutoMapper;
using WebSiteOrgStructure.Data.Interface;
using WebSiteOrgStructure.Dtos;
using WebSiteOrgStructure.Models;

namespace WebSiteOrgStructure.BLL;
public class UserBLL : IUserBLL
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

    public async Task UpdateAsync(UserUpdateDto user)
    {

        var userUpdate = await _repo.GetUserByIdAsync(user.Id);
        ArgumentNullException.ThrowIfNull(userUpdate);
        _mapper.Map(user, userUpdate);
        await _repo.SaveChangesAsync();
    }

    public async Task<UserReadDto> GetAsync(Guid id)
    {
        var user = await _repo.GetUserByIdAsync(id);
        ArgumentNullException.ThrowIfNull(user);
        return _mapper.Map<UserReadDto>(user);
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

    public async Task DeleteAsync(Guid userId)
    {
        var user = await _repo.GetUserByIdAsync(userId);
        ArgumentNullException.ThrowIfNull(user);
        _repo.DeleteUserAsync(user);
        await _repo.SaveChangesAsync();
    }
}

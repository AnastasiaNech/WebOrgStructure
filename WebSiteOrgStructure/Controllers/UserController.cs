using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using WebSiteOrgStructure.Dtos;
using WebSiteOrgStructure.MediatRAPi;


namespace WebSiteOrgStructure.Controllers;

public class UserController : Controller
{
    private readonly IMediator _mediator;

    public UserController(IMediator mediator)

    {
        _mediator = mediator;
    }

    public IActionResult Index()
    {
        ViewBag.Departments = new SelectList(_mediator.Send(new GetDepartmentsRequest()).Result
            .Select(x => x.DepartmentName)
            .Distinct());
        ViewBag.Roles = new SelectList(_mediator.Send(new GetUsersListRequest()).Result
            .Select(x => x.Role)
            .Distinct());
        return View();
    }

    public IActionResult IndexUpdateUser(string json)
    {
        ViewBag.Departments = new SelectList(_mediator.Send(new GetDepartmentsRequest()).Result
            .Select(x => x.DepartmentName)
            .Distinct());
        ViewBag.Roles = new SelectList(_mediator.Send(new GetUsersListRequest()).Result
            .Select(x => x.Role)
            .Distinct());
        UserReadDto user = JsonConvert.DeserializeObject<UserReadDto>(json);
        return View(user);
    }

    [HttpGet]
    public async Task<UserReadDto> Get(Guid id)
    {
        return await _mediator.Send(new GetUserRequest() { id = id });
    }



    [HttpPost]
    public async Task<IActionResult> Create(UserCreateDto user)
    {
        if (ModelState.IsValid)
        {
            await _mediator.Send(new CreateUserRequest() { userCreateDto = user });
            ViewBag.Message = "Сотрудник добавлен успешно!";
            return View("Result");
        }
        ViewBag.Message = "Ошибка создания!";
        return View("Result");
    }

    public async Task<IActionResult> Update(UserUpdateDto user)
    {
        await _mediator.Send(new UserUpdateRequest() { userUpdateDto = user });
        ViewBag.Message = "Ошибка создания!";
        return View("Result");
    }

    [HttpDelete]
    public async Task<IActionResult> Delete(Guid id)
    {
        await _mediator.Send(new DeleteUserRequest() { userId = id });
        return View("Result");
    }

    [HttpGet]
    public async Task<IActionResult> IndexUsersList()
    {
        return View(await Task.FromResult(_mediator.Send(new GetUsersListRequest())).Result);
    }

    [HttpGet]
    public async Task<IActionResult> IndexCountUserAndRole()
    {
        return View(await Task.FromResult(_mediator.Send(new GetCountUserAndRoleRequest())).Result);
    }
}

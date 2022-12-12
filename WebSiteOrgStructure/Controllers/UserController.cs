using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
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

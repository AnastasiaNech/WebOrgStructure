using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using WebSiteOrgStructure.BLL;
using WebSiteOrgStructure.Dtos;

namespace WebSiteOrgStructure.Controllers;

public class UserController : Controller
{
    private readonly IUserBLL _userBLL;

    public UserController(IUserBLL userBLL)
    {

        _userBLL = userBLL;
    }

    public IActionResult Index()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(UserCreateDto user)
    {
        if (ModelState.IsValid)
        {
            await _userBLL.CreateAsync(user);
            ViewBag.Message = "Сотрудник добавлен успешно!";
            return View("Result");
        }
        ViewBag.Message = "Ошибка создания!";
        return View("Result");
    }

    [HttpGet]
    public async Task<IActionResult> IndexUsersList()
    {
        Task<List<UserReadDto>> list = _userBLL.GetUsersListAsync();
        ViewBag.List = list.Result;
        return View("IndexUsersList");
    }

    [HttpGet]
    public IActionResult IndexCountUserAndRole()
    {
       List<DepartmentStructDto> list = _userBLL.GetCountUserAndRole();
        ViewBag.ListStruct = list;
        return View("IndexCountUserAndRole");
    }
}

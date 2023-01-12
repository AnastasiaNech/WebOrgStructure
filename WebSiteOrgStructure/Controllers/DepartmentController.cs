using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebSiteOrgStructure.Dtos;
using WebSiteOrgStructure.MediatRAPi;

namespace WebSiteOrgStructure.Controllers;

public class DepartmentController : Controller
{
    private readonly IMediator _mediator;

    public DepartmentController(IMediator mediator)

    {
        _mediator = mediator;
    }

    public IActionResult Index()
    {
        ViewBag.ParentDepartments = new SelectList
            (new SelectList(_mediator.Send(new GetDepartmentsRequest()).Result
            .Where(x => x.ParentDepartmentName == null)
            .Select(x => x.DepartmentName))
            .Union
            (new SelectList(_mediator.Send(new GetDepartmentsRequest()).Result
            .Where(x => x.ParentDepartmentName != null)
            .Select(x => x.ParentDepartmentName)))
            .Select(x => x.Text)
            .Distinct()); 
      return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(DepartmentCreateDto department)
    {
        if (ModelState.IsValid)
        {
            await _mediator.Send(new DepartmentRequest() { departmentCreateDto = department });
            ViewBag.Message = "Департамент добавлен успешно!";
            return View("Result");
        }
        ViewBag.Message = "Ошибка создания!";
        return View("Result");
    }
}

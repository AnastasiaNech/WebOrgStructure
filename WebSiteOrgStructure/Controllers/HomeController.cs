using MediatR;
using Microsoft.AspNetCore.Mvc;
using OfficeOpenXml;
using System.Diagnostics;
using WebSiteOrgStructure.Data.Interface;
using WebSiteOrgStructure.MediatRAPi;
using WebSiteOrgStructure.Models;

namespace WebSiteOrgStructure.Controllers;

public class HomeController : Controller
{

    private readonly IMediator _mediator;

    public HomeController(IMediator mediator)

    {
        _mediator = mediator;
    }


    public IActionResult Index()
    {
        return View();
    }

    public async Task<IActionResult> ImportAsync(IFormFile file)
    {  
        try
        {
            ArgumentNullException.ThrowIfNull(file);
            await _mediator.Send(new ImportExcelRequest() { file = file });
            ViewBag.Message = "Файл загружен успешно!";
            return View("Result");
        }
        catch 
        {
           ViewBag.Message = "При загрузке произошла ошибка!";
            return View("Result");
        }

    }
}
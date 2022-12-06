using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using OfficeOpenXml;
using System.Diagnostics;
using WebSiteOrgStructure.Data;
using WebSiteOrgStructure.Data.Interface;
using WebSiteOrgStructure.Dtos;
using WebSiteOrgStructure.Models;

namespace WebSiteOrgStructure.Controllers;

public class HomeController : Controller
{

    private readonly IImportExcelRepo _importExcelBLL;
    private readonly IMapper _mapper;

    public HomeController(IImportExcelRepo importExcelBLL, IMapper mapper)
    {

        _importExcelBLL = importExcelBLL;
        _mapper = mapper;
    }

    public IActionResult Index()
    {
        return View();
    }

    public async Task<Task> ImportAsync(IFormFile file)
    {
        ArgumentNullException.ThrowIfNull(file);
        using (var steam = new MemoryStream())
        {
            await file.CopyToAsync(steam);
            using (var package = new ExcelPackage(steam))
            {
                return _importExcelBLL.ImportExcelAsync(package);
            }
        }
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
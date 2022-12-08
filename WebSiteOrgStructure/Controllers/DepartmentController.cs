using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebSiteOrgStructure.Dtos;
using WebSiteOrgStructure.MediatRAPi;

namespace WebSiteOrgStructure.Controllers
{
    public class DepartmentController : Controller
    {
        private readonly IMediator _mediator;

        public DepartmentController(IMediator mediator)

        {
            _mediator = mediator;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}

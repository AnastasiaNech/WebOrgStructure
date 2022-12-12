using MediatR;
using Microsoft.AspNetCore.Http;
using OfficeOpenXml;
using WebSiteOrgStructure.Data.Interface;


namespace WebSiteOrgStructure.MediatRAPi;

public class ImportExcelRequest : IRequest<bool>
{
    public IFormFile file { get; set; }
}

public class ImportExcelHandler : IRequestHandler<ImportExcelRequest, bool>
{
    private readonly IImportExcelRepo _importRepo;

    public ImportExcelHandler(IImportExcelRepo importRepo)
    {

        _importRepo = importRepo;
    }

    public async Task<bool> Handle(ImportExcelRequest request, CancellationToken cancellation = default)
    {
        using (var steam = new MemoryStream())
        {
            await request.file.CopyToAsync(steam);
            using (var package = new ExcelPackage(steam))
            {
                return await _importRepo.ImportExcelAsync(package);
            }
        }
    }
}

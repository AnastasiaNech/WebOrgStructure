using OfficeOpenXml;

namespace WebSiteOrgStructure.Data.Interface;

public interface IImportExcelRepo
{
    Task<bool> ImportExcelAsync(ExcelPackage package);
}

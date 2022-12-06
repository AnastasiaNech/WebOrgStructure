using OfficeOpenXml;

namespace WebSiteOrgStructure.Data.Interface;

public interface IImportExcelRepo
{
    Task ImportExcelAsync(ExcelPackage package);
}

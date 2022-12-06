using WebSiteOrgStructure.Data.Interface;
using WebSiteOrgStructure.Data;
using WebSiteOrgStructure.BLL;

namespace WebSiteOrgStructure.DI;

public class DI
{
    public static void CreateDI(IServiceCollection services)
    {
        services.AddScoped<IDepartmentRepo, DepartmentRepo>();
        services.AddScoped<IImportExcelRepo, ImportExcelRepo>();
        services.AddScoped<IUserRepo, UserRepo>();
        services.AddScoped<IUserBLL, UserBLL>();
    }
}

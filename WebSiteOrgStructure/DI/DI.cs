using WebSiteOrgStructure.Data.Interface;
using WebSiteOrgStructure.Data;
using WebSiteOrgStructure.BLL;
using WebAPICalendar.DataClient;

namespace WebSiteOrgStructure.DI;

public class DI
{
    public static void CreateDI(IServiceCollection services)
    {
        services.AddHttpClient<ICalendarDataClient, CalendarDataClient>();
        services.AddScoped<IDepartmentRepo, DepartmentRepo>();
        services.AddScoped<IImportExcelRepo, ImportExcelRepo>();
        services.AddScoped<IUserRepo, UserRepo>();
        services.AddScoped<IEventRepo, EventRepo>();
        services.AddScoped<IUserBLL, UserBLL>();
        services.AddScoped<IDepartmentBLL, DepartmentBLL>();
        services.AddScoped<IEventBLL, EventBLL>();
    }
}

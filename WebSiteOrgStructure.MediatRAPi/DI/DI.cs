using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace WebSiteOrgStructure.MediatRAPi;

public static class MediatRDI
{
    public static void CreateDI(IServiceCollection services)
    {
        services.AddMediatR(AppDomain.CurrentDomain.GetAssemblies());
    }
}

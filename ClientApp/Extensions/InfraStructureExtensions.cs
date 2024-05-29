using Infrastructure.Models;
using Infrastructure.Repository;
using Models.Interfaces;
using System.Runtime.CompilerServices;

namespace ClientApp.Extensions
{
    public static class InfraStructureExtensions
    {
        public static void AddInfraStructure(this WebApplicationBuilder webApplication)
        {
            webApplication.Services.AddScoped<IRepository<Hotel>, Repository<Hotel>>();
        }
    }
}

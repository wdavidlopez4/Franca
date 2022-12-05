using Franca.Application.BranchOffices.GetAllBranchOffices;
using Franca.Application.Elements.AddElement;
using Franca.Application.Elements.GetAllElements;
using Franca.Application.Technicals.CreateTechnical;
using Franca.Application.Technicals.DeleteTechnical;
using Franca.Application.Technicals.GetAllTechnicals;
using Franca.Application.Technicals.GetTechnical;
using Franca.Application.Technicals.ModifyTechnical;
using Franca.Domain;
using Franca.Infrastructure.MapObjects;
using Franca.Infrastructure.Persistences;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Franca.Infrastructure
{
    public class FrancaStartup
    {
        public static void SetUp(IServiceCollection services, IConfiguration configuration)
        {
            ConfigureContext(services, configuration);
            ConfigureIOC(services);
            ConfigureMediador(services);
            ConfigureMapper(services);
        }

        private static void ConfigureContext(IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<FrancaContext>(options =>
            options.UseSqlServer(
                    configuration.GetConnectionString("FrancaConnectionString")));
        }

        private static void ConfigureIOC(IServiceCollection services)
        {
            services.AddScoped<IRepository, Repository>();
            services.AddScoped<IMapObject, MapObject>();
        }

        private static void ConfigureMediador(IServiceCollection services)
        {
            services.AddMediatR(
                typeof(GetAllBranchOfficesQuery).GetTypeInfo().Assembly,
                typeof(AddElementCommand).GetTypeInfo().Assembly,
                typeof(GetAllElementsQuery).GetTypeInfo().Assembly,
                typeof(CreateTechnicalCommand).GetTypeInfo().Assembly,
                typeof(DeleteTechnicalCommand).GetTypeInfo().Assembly,
                typeof(GetAllTechnicalsQuery).GetTypeInfo().Assembly,
                typeof(ModifyTechnicalCommand).GetTypeInfo().Assembly,
                typeof(GetTechnicalQuery).GetTypeInfo().Assembly);
        }

        private static void ConfigureMapper(IServiceCollection services)
        {
            //mapeo de entidades
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
        }
    }
}

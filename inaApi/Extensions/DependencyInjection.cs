using inaApp.Common.Interfaces;
using inaApp.Data;
using inaApp.DTOs.cliente;
using inaApp.DTOs.Producto;
using inaApp.Entites;
using inaApp.Repository;
using inaApp.Services;
using inaApp.Services.Mapping;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace inaApp.Api.Extensions
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddAplicaServices(this IServiceCollection services, IConfiguration configuration)
        {
            //Inyecciones de baseDatos-dbContex
            services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
            });

            //profile auto mapper
            services.AddAutoMapper(cfg => { }, typeof(MappingProfile));

            //Inyecciones de dependencia de servicios
            services.AddScoped<IGenericService<ProductoResponseDTO, ProductoCreateDTO, ProductoUpdateDTO>, ProductoService>();
            services.AddScoped <IGenericService<ClienteResponseDTO, ClienteCreateDTO, ClienteUpdateDTO>, ClienteService>();

            //Inyección de dependencia de repostorios
            services.AddScoped<IGenericRepository<Producto>, ProductoRespository>();
            services.AddScoped<IGenericRepository<Cliente>, ClienteRepository>();


            

            return services;
        }
    }
}

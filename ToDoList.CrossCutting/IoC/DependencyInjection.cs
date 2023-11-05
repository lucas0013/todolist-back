using Catalogo.Application.Mappings;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ToDoList.Application.Interfaces;
using ToDoList.Application.Services;
using ToDoList.Domain.Account;
using ToDoList.Domain.Interfaces;
using ToDoList.Domain.IRepositories;
using ToDoList.Infraestructure.Identity;
using ToDoList.Infrastructure.Context;
using ToDoList.Infrastructure.Repositories;

namespace ToDoList.CrossCutting.IoC
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services,
            IConfiguration configuration)
        {            
            services.AddDbContext<AppDbContext>(options =>
                                options.UseNpgsql(configuration.GetConnectionString("PostgreSqlAws")));

            services
                .AddIdentity<ApplicationUser, IdentityRole>(options => {
                    options.SignIn.RequireConfirmedAccount = false;
                    options.User.RequireUniqueEmail = true;
                    options.Password.RequireDigit = false;
                    options.Password.RequiredLength = 6;
                    options.Password.RequireNonAlphanumeric = false;
                    options.Password.RequireUppercase = false;
                    options.Password.RequireLowercase = false;
                })
                .AddEntityFrameworkStores<AppDbContext>()
                .AddDefaultTokenProviders();

            services.AddScoped<ITarefaRepository, TarefaRepository>();
            services.AddScoped<ITarefaService, TarefaService>();
            
            services.AddScoped<ITagRepository, TagRepository>();
            services.AddScoped<ITagService, TagService>();

            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddScoped<IAuthenticate, AuthenticateService>();
            services.AddScoped<ISeedUserRoleInitial, SeedUserRoleInitial>();

            services.AddAutoMapper(typeof(DomainToDTOMappingProfile));

            return services;
        }
    }
}

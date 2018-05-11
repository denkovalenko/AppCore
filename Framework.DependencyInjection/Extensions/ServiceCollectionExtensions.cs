using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using AutoMapper;
using FrameworkApp.BusinessLogic.Service;
using FrameworkApp.Data.Repository;
using FrameworkApp.Data.UoW;
using FrameworkApp.RepositoryInterfaces.ObjectInterfaces;
using FrameworkApp.RepositoryInterfaces.UoW;
using FrameworkApp.ServiceInterfaces.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using FrameworkApp.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Configuration;

namespace Framework.DependencyInjection.Extensions
{
    public static class ServiceCollectionExtensions
    {
        //private const String  defaultConnection
        
        public static IServiceCollection RegisterServices(this IServiceCollection services, IConfiguration Configuration)
        {
            services.AddDbContext<AppDbContext>(options => options.UseSqlServer(ConfigurationExtensions.GetConnectionString(Configuration,"DefaultConnection")));
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            services.AddSingleton<IUserRepository, UserRepository>();
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<ITokenService, TokenService>();
            services.AddTransient<IServiceFactory, ServiceFactory>();


            services.AddAutoMapper(null, AppDomain.CurrentDomain.GetAssemblies());

            return services;
        }
    }
}

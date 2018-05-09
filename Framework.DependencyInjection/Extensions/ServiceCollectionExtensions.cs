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

namespace Framework.DependencyInjection.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection RegisterServices(this IServiceCollection services)
        {
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            services.AddSingleton<IUserRepository, UserRepository>();
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<IServiceFactory, ServiceFactory>();


            var config = new AutoMapper.MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new FrameworkApp.DependencyInjection.MapperConfiguration.MappingConfig());
            });

            var mapper = config.CreateMapper();

            //services.AddAutoMapper(null, AppDomain.CurrentDomain.GetAssemblies());
            //services.AddAutoMapper(null, typeof(FramewrokApp.Mapper.MappingsProfile).Assembly.);
            //services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies().Where(x => x.FullName.Contains("FramewrokApp.Mapper")));
            //var qw = AppDomain.CurrentDomain.GetAssemblies().Where(x => x.FullName.Contains("FramewrokApp."));

            return services;
        }
    }
}

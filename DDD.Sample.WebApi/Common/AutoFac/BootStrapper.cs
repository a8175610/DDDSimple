using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Http;
using Autofac;
using Autofac.Integration.WebApi;
using DDD.Sample.Application;
using DDD.Sample.Application.Interface;
using DDD.Sample.Domain.Repository.Interface;
using DDD.Sample.Infrastructure;
using DDD.Sample.Infrastructure.DomainEventCore;
using DDD.Sample.Infrastructure.Interface;
using DDD.Sample.Infrastructure.Interface.DomainEventCore;
using DDD.Sample.Infrastructure.Repository;

namespace DDD.Sample.WebApi.Common.AutoFac
{
    public static class Bootstrapper
    {
        public static void Run()
        {
            SetAutofacWebAPI();
        }
        private static void SetAutofacWebAPI()
        {
            var configuration = GlobalConfiguration.Configuration;
            var builder = new ContainerBuilder();
            // Configure the container  
            
            //builder.ConfigureWebApi(configuration);
            // Register API controllers using assembly scanning. 
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());

            builder.RegisterType<SampleContext>().As<IDbContext>().InstancePerRequest();
            builder.RegisterType<EventBus>().As<IEventBus>().SingleInstance();
            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>().InstancePerRequest();
            builder.RegisterType<StudentRepository>().As<IStudentRepository>().InstancePerRequest();
            builder.RegisterType<StudentService>().As<IStudentService>().InstancePerDependency();
            
            var container = builder.Build();
            // Set the WebApi dependency resolver.  
            var resolver = new AutofacWebApiDependencyResolver(container);
            configuration.DependencyResolver = resolver;
        }
    }
}
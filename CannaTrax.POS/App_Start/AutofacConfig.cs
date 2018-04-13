using Autofac;
using Autofac.Integration.WebApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Http;

namespace CannaTrax.POS
{
    public class AutofacConfig
    {
         public static void Register(HttpConfiguration config)
        {
            var builder = new ContainerBuilder();

            builder.RegisterWebApiFilterProvider(config);
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());

            //builder.RegisterModule(new FileServiceModule());

            var container = builder.Build();
            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);
        }
    }
}
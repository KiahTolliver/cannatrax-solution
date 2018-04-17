using Autofac;
using CannaTrax.Data.EF.Interfaces;
using CannaTrax.Data.EF.Repositories;


namespace CannaTrax.Data.EF.IOC
{
    public class DataModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterGeneric(typeof(EntityRepository<>)).As(typeof(IEntityRepository<>)).InstancePerLifetimeScope();
            builder.RegisterType<UtilityContext>().As<IUtilityContext>().InstancePerLifetimeScope();

            builder.RegisterModule(new RepositoriesModule());
        }
    }
}

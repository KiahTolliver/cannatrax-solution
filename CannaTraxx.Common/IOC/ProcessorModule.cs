using Autofac;
using CannaTraxx.Common.Processors;

namespace CannaTraxx.Common.IOC
{
    internal class ProcessorModule: Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<CustomerProcessor>().As<ICustomerProcessor>().InstancePerLifetimeScope();
            builder.RegisterType<CategoryProcessor>().As<ICategoryProcessor>().InstancePerLifetimeScope();
            builder.RegisterType<GeneralSettingsProcessor>().As<IGeneralSettingsProcessor>().InstancePerLifetimeScope();
            builder.RegisterType<ItemProcessor>().As<IItemProcessor>().InstancePerLifetimeScope();
            builder.RegisterType<ModuleProcessor>().As<IModuleProcessor>().InstancePerLifetimeScope();
            builder.RegisterType<PurchaseProcessor>().As<IPurchaseProcessor>().InstancePerLifetimeScope();
            builder.RegisterType<PurchaseDetailProcessor>().As<IPurchaseDetailProcessor>().InstancePerLifetimeScope();
            builder.RegisterType<RoleProcessor>().As<IRoleProcessor>().InstancePerLifetimeScope();
            builder.RegisterType<SaleProcessor>().As<ISaleProcessor>().InstancePerLifetimeScope();
            builder.RegisterType<SaleDetailProcessor>().As<ISaleDetailProcessor>().InstancePerLifetimeScope();
            builder.RegisterType<SalePaymentProcessor>().As<ISalePaymentProcessor>().InstancePerLifetimeScope();
            builder.RegisterType<ShopProcessor>().As<IShopProcessor>().InstancePerLifetimeScope();
            builder.RegisterType<SupplierProcessor>().As<ISupplierProcessor>().InstancePerLifetimeScope();
            builder.RegisterType<TaxProcessor>().As<ITaxProcessor>().InstancePerLifetimeScope();
            builder.RegisterType<UserProcessor>().As<IUserProcessor>().InstancePerLifetimeScope();
            builder.RegisterType<UserLogProcessor>().As<IUserLogProcessor>().InstancePerLifetimeScope();
            builder.RegisterType<UserPermissionProcessor>().As<IUserPermissionProcessor>().InstancePerLifetimeScope();

        }
    }
}

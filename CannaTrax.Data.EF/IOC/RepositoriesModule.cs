using Autofac;
using CannaTrax.Data.EF.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;

using System.Text;
using System.Threading.Tasks;

namespace CannaTrax.Data.EF.IOC
{
   internal class RepositoriesModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<CategoryRepository>().As<ICategoryRepository>().InstancePerLifetimeScope();
            builder.RegisterType<CustomerRepository>().As<ICustomerRepository>().InstancePerLifetimeScope();
            builder.RegisterType<GeneralSettingsRepository>().As<IGeneralSettingsRepository>().InstancePerLifetimeScope();
            builder.RegisterType<ItemRepository>().As<IItemRepository>().InstancePerLifetimeScope();
            builder.RegisterType<ModuleRepository>().As<IModuleRepository>().InstancePerLifetimeScope();
            builder.RegisterType<PurchaseRepository>().As<IPurchaseRepository>().InstancePerLifetimeScope();
            builder.RegisterType<PurchaseDetailRepository>().As<IPurchaseDetailRepository>().InstancePerLifetimeScope();
            builder.RegisterType<RoleRepository>().As<IRoleRepository>().InstancePerLifetimeScope();
            builder.RegisterType<SaleDetailRepository>().As<ISaleDetailRepository>().InstancePerLifetimeScope();
            builder.RegisterType<SalePaymentRepository>().As<ISalePaymentRepository>().InstancePerLifetimeScope();
            builder.RegisterType<SaleTaxRepository>().As<ISaleTaxRepository>().InstancePerLifetimeScope();
            builder.RegisterType<ShopRepository>().As<IShopRepository>().InstancePerLifetimeScope();
            builder.RegisterType<SupplierRepository>().As<ISupplierRepository>().InstancePerLifetimeScope();
            builder.RegisterType<TaxRepository>().As<ITaxRepository>().InstancePerLifetimeScope();
            builder.RegisterType<UserRepository>().As<IUserRepository>().InstancePerLifetimeScope();
            builder.RegisterType<UserLogRepository>().As<IUserLogRepository>().InstancePerLifetimeScope();
            builder.RegisterType<UserPermissionRepository>().As<IUserPermissionRepository>().InstancePerLifetimeScope();
        }
    }
}

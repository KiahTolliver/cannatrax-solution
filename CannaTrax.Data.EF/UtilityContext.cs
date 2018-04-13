namespace CannaTrax.Data.EF
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using System.Diagnostics;
    using CannaTrax.Data.EF.Interfaces;
    using System.Data.Entity.Infrastructure;

    public partial class UtilityContext : DbContext, IUtilityContext
    {
        public UtilityContext()
            : base("name=CannaTraxModel")
        {
            Database.SetInitializer<UtilityContext>(null);
            Database.Log = (s) => Debug.Write(s);
        }
        public DbContextTransaction BeginTransaction()
        {
            return Database.BeginTransaction();
        }

        public DbRawSqlQuery SqlQuery(Type elementType, string sql, params object[] parameters)
        {
            return Database.SqlQuery(elementType, sql, parameters);
        }

        public DbRawSqlQuery<T> SqlQuery<T>(string sql, params object[] parameters) where T : class
        {
            return Database.SqlQuery<T>(sql, parameters);
        }

        public int ExecuteSqlCommand(string sql, params object[] parameters)
        {
            return Database.ExecuteSqlCommand(sql, parameters);
        }

        //not sure how well this plays with async operations / services...
        public void SetAutoDetectChanges(bool enabled)
        {
            this.Configuration.AutoDetectChangesEnabled = enabled;
        }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<tblItem>().ToTable("dbo.tblItem");
            modelBuilder.Entity<tblCategory>().ToTable("dbo.tblCategory");
            modelBuilder.Entity<tblCustomer>().ToTable("dbo.tblCustomer");
            modelBuilder.Entity<tblGeneralSetting>().ToTable("dbo.tblGeneralSetting");
            modelBuilder.Entity<tblModule>().ToTable("dbo.tblModule");
            modelBuilder.Entity<tblPurchase>().ToTable("dbo.tblPurchase");
            modelBuilder.Entity<tblPurchaseDetail>().ToTable("dbo.tblPurchaseDetail");
            modelBuilder.Entity<tblRole>().ToTable("dbo.tblRole");
            modelBuilder.Entity<tblSale>().ToTable("dbo.tblSale");
            modelBuilder.Entity<tblSaleDetail>().ToTable("dbo.tblSaleDetail");
            modelBuilder.Entity<tblSalePayment>().ToTable("dbo.tblSalePayment");
            modelBuilder.Entity<tblSaleTax>().ToTable("dbo.SaleTax");
            modelBuilder.Entity<tblShop>().ToTable("dbo.tblShop");
            modelBuilder.Entity<tblSupplier>().ToTable("dbo.tblSupplier");
            modelBuilder.Entity<tblTax>().ToTable("dbo.tblTax");
            modelBuilder.Entity<tblUser>().ToTable("dbo.tblUser");
            modelBuilder.Entity<tblUserLog>().ToTable("dbo.tblUserLog");
            modelBuilder.Entity<tblUserPermission>().ToTable("dbo.tblUserPermission");




        }
    }
}

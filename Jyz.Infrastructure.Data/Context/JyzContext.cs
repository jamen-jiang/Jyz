using Jyz.Domain;
using Jyz.Infrastructure.Data.Mappings;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq.Expressions;

namespace Jyz.Infrastructure.Data
{
    public partial class JyzContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string dbConnectionString="Data Source=.;Initial Catalog=System;User ID=sa;Password=19911004";
            // 定义要使用的数据库
            optionsBuilder.UseSqlServer(dbConnectionString, b => b.UseRowNumberForPaging());
        }
        public virtual DbSet<Module> Module { get; set; }
        public virtual DbSet<Operate> Operate { get; set; }
        public virtual DbSet<Privilege> Privilege { get; set; }
        public virtual DbSet<Role> Role { get; set; }
        public virtual DbSet<Role_User> Role_User { get; set; }
        public virtual DbSet<User> User { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //自动映射
            modelBuilder.ApplyAllConfigurations();
            //foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            //{
            //    entityType.GetOrAddProperty("IsEnable", typeof(bool));
            //    var parameter = Expression.Parameter(entityType.ClrType);
            //    var propertyMethodInfo = typeof(EF).GetMethod("Property").MakeGenericMethod(typeof(bool));
            //    var isDeletedProperty = Expression.Call(propertyMethodInfo, parameter, Expression.Constant("IsEnable"));
            //    BinaryExpression compareExpression = Expression.MakeBinary(ExpressionType.Equal, isDeletedProperty, Expression.Constant(true));
            //    var lambda = Expression.Lambda(compareExpression, parameter);
            //    modelBuilder.Entity(entityType.ClrType).HasQueryFilter(lambda);
            //}
        }
    }
}

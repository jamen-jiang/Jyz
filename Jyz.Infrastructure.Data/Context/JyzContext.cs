using Jyz.Domain;
using Jyz.Infrastructure.Configuration;
using Jyz.Infrastructure.Data.Mappings;
using Microsoft.EntityFrameworkCore;

namespace Jyz.Infrastructure.Data
{
    public partial class JyzContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // 定义要使用的数据库
            optionsBuilder.UseSqlServer(AppSetting.Connection.DbConnectionString, b => b.UseRowNumberForPaging());
        }
        public virtual DbSet<Module> Menu { get; set; }
        public virtual DbSet<Module> Module { get; set; }
        public virtual DbSet<Operate> Operate { get; set; }
        public virtual DbSet<Privilege> Privilege { get; set; }
        public virtual DbSet<Role> Role { get; set; }
        public virtual DbSet<Role_User> Role_User { get; set; }
        public virtual DbSet<User> User { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration<Module>(new ModuleMapping());
            modelBuilder.ApplyConfiguration<Operate>(new OperateMapping());
            modelBuilder.ApplyConfiguration<Privilege>(new PrivilegeMapping());
            modelBuilder.ApplyConfiguration<Role>(new RoleMapping());
            modelBuilder.ApplyConfiguration<Role_User>(new Role_UserMapping());
            modelBuilder.ApplyConfiguration<User>(new UserMapping());
            base.OnModelCreating(modelBuilder);
        }
    }
}

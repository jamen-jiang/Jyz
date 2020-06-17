using Jyz.Domain.Mappings;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Reflection;

namespace Jyz.Domain
{
    public partial class JyzContext : DbContext
    {
        public JyzContext(DbContextOptions<JyzContext> options)
            : base(options)
        {
        }
        public virtual DbSet<Menu> Menu { get; set; }
        public virtual DbSet<Module> Module { get; set; }
        public virtual DbSet<Operate> Operate { get; set; }
        public virtual DbSet<Privilege> Privilege { get; set; }
        public virtual DbSet<Role> Role { get; set; }
        public virtual DbSet<Role_User> Role_User { get; set; }
        public virtual DbSet<User> User { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration<Menu>(new MenuMapping());
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

using Jyz.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Jyz.Infrastructure.Data.Mappings
{
    public class Role_DepartmentMapping : IEntityTypeConfiguration<Role_Department>
    {
        public void Configure(EntityTypeBuilder<Role_Department> builder)
        {
            builder.Property(x => x.RoleId).IsRequired() ;
            builder.Property(x => x.DepartmentId).IsRequired() ;
        }
    }
}

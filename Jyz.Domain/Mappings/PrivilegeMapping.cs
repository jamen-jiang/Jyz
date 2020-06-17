using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Jyz.Domain.Mappings
{
    public class PrivilegeMapping : IEntityTypeConfiguration<Privilege>
    {
        public void Configure(EntityTypeBuilder<Privilege> builder)
        {
            builder.Property(x => x.Master).IsRequired().HasMaxLength(50);
            builder.Property(x => x.MasterValue).IsRequired().HasColumnType("nvarchar(50)"); ;
            builder.Property(x => x.Access).IsRequired().HasMaxLength(50);
            builder.Property(x => x.AccessValue).IsRequired().HasColumnType("nvarchar(50)"); ;
            builder.Property(x => x.Operation).IsRequired();
            builder.Ignore(x => x.IsEnable);
            builder.Ignore(x => x.CreatedBy);
            builder.Ignore(x => x.CreatedByName);
            builder.Ignore(x => x.CreatedOn);
            builder.Ignore(x => x.UpdatedBy);
            builder.Ignore(x => x.UpdatedByName);
            builder.Ignore(x => x.UpdatedOn);
        }
    }
}

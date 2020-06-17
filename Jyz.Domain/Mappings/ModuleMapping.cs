using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Jyz.Domain.Mappings
{
    public class ModuleMapping : IEntityTypeConfiguration<Module>
    {
        public void Configure(EntityTypeBuilder<Module> builder)
        {
            //builder.HasMany(x => x.Menu).WithOne();
            builder.Property(x => x.Name).IsRequired().HasMaxLength(50);
            builder.Property(x => x.Icon).IsRequired(false).HasMaxLength(200);
            builder.Property(x => x.Sort).IsRequired(false);
            builder.Property(x => x.Remark).IsRequired(false).HasMaxLength(500);
        }
    }
}

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Jyz.Domain.Mappings
{
    public class MenuMapping : IEntityTypeConfiguration<Menu>
    {
        public void Configure(EntityTypeBuilder<Menu> builder)
        {
            builder.Property(x => x.ModuleId).IsRequired();
            builder.Property(x => x.PId).IsRequired(false);
            builder.Property(x => x.Type).IsRequired();
            builder.Property(x => x.Name).IsRequired().HasMaxLength(50);
            builder.Property(x => x.Icon).IsRequired(false).HasMaxLength(200);
            builder.Property(x => x.Sort).IsRequired(false);
            builder.Property(x => x.VueUri).IsRequired(false).HasMaxLength(200);
            builder.Property(x => x.Remark).IsRequired(false).HasMaxLength(500);
        }
    }
}

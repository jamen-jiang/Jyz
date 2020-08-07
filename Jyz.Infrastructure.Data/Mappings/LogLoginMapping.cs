using Jyz.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Jyz.Infrastructure.Data.Mappings
{
    public class LogLoginMapping : IEntityTypeConfiguration<LogLogin>
    {
        public void Configure(EntityTypeBuilder<LogLogin> builder)
        {
            builder.Ignore(x => x.IsEnable);
            builder.Ignore(x => x.CreatedBy);
            builder.Ignore(x => x.CreatedByName);
            builder.Ignore(x => x.CreatedOn);
            builder.Ignore(x => x.UpdatedBy);
            builder.Ignore(x => x.UpdatedByName);
            builder.Ignore(x => x.UpdatedOn);
            builder.Property(x => x.UserName).IsRequired().HasMaxLength(50);
            builder.Property(x => x.LoginOn).IsRequired();
            builder.Property(x => x.IP).HasMaxLength(200);
            builder.Property(x => x.City).HasMaxLength(50);
            builder.Property(x => x.UserAgent).HasMaxLength(500);
            builder.Property(x => x.Browser).HasMaxLength(200);
            builder.Property(x => x.Os).HasMaxLength(200);
        }
    }
}

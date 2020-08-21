using Jyz.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Jyz.Infrastructure.Data.Mappings
{
    public class Organization_UserMapping : IEntityTypeConfiguration<Organization_User>
    {
        public void Configure(EntityTypeBuilder<Organization_User> builder)
        {
            builder.Property(x => x.OrganizationId).IsRequired() ;
            builder.Property(x => x.UserId).IsRequired() ;
        }
    }
}

﻿using Jyz.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Jyz.Infrastructure.Data.Mappings
{
    public class Role_UserMapping : IEntityTypeConfiguration<Role_User>
    {
        public void Configure(EntityTypeBuilder<Role_User> builder)
        {
            builder.Property(x => x.RoleId).IsRequired() ;
            builder.Property(x => x.UserId).IsRequired() ;
        }
    }
}

using Jyz.Domain.Seedwork;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Jyz.Infrastructure.Data.Seedwork.UnitOfWork
{
    public class BaseContext : DbContext,IUnitOfWork
    {
        public BaseContext()
        {
        }
        public BaseContext(DbContextOptions options)
            : base(options)
        {
        }
        public bool Commit()
        {
            return base.SaveChanges()>0;
        }

        public void Rollback()
        {
            throw new NotImplementedException();
        }
    }
}

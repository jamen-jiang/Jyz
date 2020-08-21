using Jyz.Domain;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace Jyz.Infrastructure.Data
{
    public  class EqualityComparerBase<T> : IEqualityComparer<T>where T : Entity<Guid>
    {
        public virtual bool Equals([AllowNull] T x, [AllowNull] T y)
        {
            return x.Id == y.Id;
        }

        public int GetHashCode([DisallowNull] T obj)
        {
            return obj.ToString().GetHashCode();
        }
    }
}

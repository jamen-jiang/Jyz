using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Jyz.Infrastructure.Repository
{
    public class EFRepository : IRepository
    {
        public void Add<T>(T entity) where T : class
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public IQueryable<T> Find<T>(Expression<Func<T, bool>> where = null) where T : class
        {
            throw new NotImplementedException();
        }

        public IQueryable<T> Find<T, S>(Expression<Func<T, bool>> where, Expression<Func<T, S>> orderBy, int pageSize, int pageIndex, out int totalCount) where T : class
        {
            throw new NotImplementedException();
        }

        public void Modify<T>(T entity) where T : class
        {
            throw new NotImplementedException();
        }

        public T Query<T>(Expression<Func<T, bool>> where) where T : class
        {
            throw new NotImplementedException();
        }

        public IQueryable<T> QueryAll<T, S>(Expression<Func<T, S>> orderBy = null) where T : class
        {
            throw new NotImplementedException();
        }

        public void Remove<T>(T entity) where T : class
        {
            throw new NotImplementedException();
        }

        public void Remove<T>(Expression<Func<T, bool>> where) where T : class
        {
            throw new NotImplementedException();
        }

        public int SaveChanges()
        {
            throw new NotImplementedException();
        }

        public IQueryable<T> SqlQuery<T>(string sql)
        {
            throw new NotImplementedException();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Jyz.Infrastructure.Repository
{
    public interface IRepository : IDisposable
    {
        int SaveChanges();
        IQueryable<T> QueryAll<T, S>(Expression<Func<T, S>> orderBy = null) where T : class;
        T Query<T>(Expression<Func<T, bool>> where) where T : class;
        void Add<T>(T entity) where T : class;
        void Modify<T>(T entity) where T : class;
        void Remove<T>(T entity) where T : class;
        void Remove<T>(Expression<Func<T, bool>> where) where T : class;
        IQueryable<T> Find<T>(Expression<Func<T, bool>> where = null) where T : class;
        IQueryable<T> Find<T, S>(Expression<Func<T, bool>> where, Expression<Func<T, S>> orderBy, int pageSize, int pageIndex, out int totalCount) where T : class;
        IQueryable<T> SqlQuery<T>(string sql);
    }
}

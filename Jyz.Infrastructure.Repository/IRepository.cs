using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Jyz.Infrastructure.Repository
{
    public interface IRepository : IDisposable
    {
        int SaveChanges();
        IQueryable<T> All<T>() where T : class;
        T Get<T>(Expression<Func<T, bool>> conditions) where T : class;
        void Add<T>(T entity) where T : class;
        void Update<T>(T entity) where T : class;
        void Remove<T>(T entity) where T : class;
        void Remove<T>(Expression<Func<T, bool>> conditions) where T : class;
        List<T> Find<T>(Expression<Func<T, bool>> conditions = null) where T : class;
        List<T> Find<T, S>(Expression<Func<T, bool>> conditions, Expression<Func<T, S>> orderBy, int pageSize, int pageIndex, out int totalCount) where T : class;
        List<T> SqlQuery<T>(string sql);
        int ExecuteSqlCommand(string sql);
        long GetNextSequenceValue(string sequenceName);
    }
}

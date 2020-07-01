using Jyz.Domain.Seedwork;
using Jyz.Infrastructure.Data.Seedwork;
using System;
using System.Linq;

namespace Jyz.Infrastructure.Repositories
{
    /// <summary>
    /// 泛型仓储，实现泛型仓储接口
    /// </summary>
    /// <typeparam name="TAggregateRoot"></typeparam>
    public class Repository<TAggregateRoot> : IRepository<TAggregateRoot> where TAggregateRoot :  Entity<Guid>
    {
        public readonly IQueryable<TAggregateRoot> _entities;

        public Repository(IDbContext dbContext)
        {
            _entities = dbContext.Set<TAggregateRoot>();
        }

        public IQueryable<TAggregateRoot> Get(Guid id)
        {
            return _entities.Where(t => t.Id == id);
        }

        public IQueryable<TAggregateRoot> GetAll()
        {
            return _entities;
        }
    }
}

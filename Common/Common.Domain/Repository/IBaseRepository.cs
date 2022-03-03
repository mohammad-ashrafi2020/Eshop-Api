using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Common.Domain.Repository
{
    public interface IBaseRepository<T> where T : BaseEntity
    {
        Task<T?> GetAsync(long id);

        Task<T?> GetTracking(long id);

        Task AddAsync(T entity);
        void Add(T entity);

        Task AddRange(ICollection<T> entities);

        void Update(T entity);

        Task<int> Save();

        Task<bool> ExistsAsync(Expression<Func<T, bool>> expression);

        bool Exists(Expression<Func<T, bool>> expression);

        T? Get(long id);
    }
}
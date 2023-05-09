using System.Linq.Expressions;

namespace BetaStore.Core.Interfaces
{
    public interface IRepository<T> where T : class
    {
        IQueryable<T> GetAllAsync();
        Task<T> GetAsync(Expression<Func<T, bool>> expression, List<string> includes = null);
        Task InsertAsync(T entity);
        Task InsertRangeAsync(IEnumerable<T> entities);
        Task<bool> Update(T entity);
        Task DeleteAsync(string id);
        void DeleteRangeAsync(IEnumerable<T> entities);
    }
}

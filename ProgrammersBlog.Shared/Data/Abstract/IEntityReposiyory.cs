using ProgrammersBlog.Shared.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammersBlog.Shared.Data.Abstract
{
    public interface IEntityReposiyory<T> where T : class, IEntity, new()
    {
        Task<T> GetAsync(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includesProperies);
        Task<T> GetAsyncV2(IList<Expression<Func<T, bool>>> predicates, IList<Expression<Func<T, object>>> includesProperies);

        Task<IList<T>> GetAllAsync(Expression<Func<T, bool>> predicate = null, params Expression<Func<T, object>>[] includesProperies);
        Task<IList<T>> GetAllAsyncV2(IList<Expression<Func<T, bool>>> predicates, IList<Expression<Func<T, object>>> includesProperies);

        Task<T> AddAsync(T Entity);

        Task<T> UpdateAsync(T Entity);

        Task DeleteAsync(T Entity);

        Task<IList<T>> SearchAsync(IList<Expression<Func<T,bool>>> predicates, params Expression<Func<T, object>>[] includesProperies);

        Task<bool> Any(Expression<Func<T, bool>> predicate);

        Task<int> Count(Expression<Func<T, bool>> predicate = null);
    }
}

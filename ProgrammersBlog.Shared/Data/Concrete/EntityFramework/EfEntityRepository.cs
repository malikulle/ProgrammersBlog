using LinqKit;
using Microsoft.EntityFrameworkCore;
using ProgrammersBlog.Shared.Data.Abstract;
using ProgrammersBlog.Shared.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammersBlog.Shared.Data.Concrete.EntityFramework
{
    public class EfEntityRepository<TEntity> : IEntityReposiyory<TEntity>
        where TEntity : class, IEntity, new()
    {
        protected readonly DbContext _context;

        public EfEntityRepository(DbContext context)
        {
            _context = context;
        }

        public async Task<TEntity> AddAsync(TEntity Entity)
        {
            await _context.Set<TEntity>().AddAsync(Entity);
            return Entity;
        }

        public async Task<bool> Any(Expression<Func<TEntity, bool>> predicate)
        {
            return await _context.Set<TEntity>().AnyAsync(predicate);
        }

        public async Task<int> Count(Expression<Func<TEntity, bool>> predicate = null)
        {
            return predicate == null ? await _context.Set<TEntity>().CountAsync() : await _context.Set<TEntity>().CountAsync(predicate);
        }

        public async Task DeleteAsync(TEntity Entity)
        {
            await Task.Run(() => _context.Set<TEntity>().Remove(Entity));
        }

        public async Task<IList<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> predicate = null, params Expression<Func<TEntity, object>>[] includesProperies)
        {
            IQueryable<TEntity> query = _context.Set<TEntity>();

            if (predicate != null)
            {
                query = query.Where(predicate);
            }
            if (includesProperies.Any())
            {
                foreach (var includeProp in includesProperies)
                {
                    query = query.Include(includeProp);
                }
            }

            return await query.AsNoTracking().ToListAsync();
        }

        public async Task<IList<TEntity>> GetAllAsyncV2(IList<Expression<Func<TEntity, bool>>> predicates, IList<Expression<Func<TEntity, object>>> includesProperies)
        {
            IQueryable<TEntity> query = _context.Set<TEntity>();

            if (predicates != null && predicates.Any())
            {
                foreach (var expression in predicates)
                    query = query.Where(expression);

            }

            if (includesProperies != null && includesProperies.Any())
            {
                foreach (var includeProp in includesProperies)
                {
                    query = query.Include(includeProp);
                }
            }
            return await query.AsNoTracking().ToListAsync();
        }

        public async Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> predicate, params Expression<Func<TEntity, object>>[] includesProperies)
        {
            IQueryable<TEntity> query = _context.Set<TEntity>();

            if (includesProperies.Any())
            {
                foreach (var includeProp in includesProperies)
                {
                    query = query.Include(includeProp);
                }
            }
            return await query.AsNoTracking().SingleOrDefaultAsync(predicate);

        }

        public async Task<TEntity> GetAsyncV2(IList<Expression<Func<TEntity, bool>>> predicates, IList<Expression<Func<TEntity, object>>> includesProperies)
        {
            IQueryable<TEntity> query = _context.Set<TEntity>();

            if(predicates != null && predicates.Any())
            {
                foreach (var expression in predicates)                
                    query = query.Where(expression);
                
            }

            if (includesProperies != null && includesProperies.Any())
            {
                foreach (var includeProp in includesProperies)
                {
                    query = query.Include(includeProp);
                }
            }
            return await query.AsNoTracking().SingleOrDefaultAsync();
        }

        public async Task<IList<TEntity>> SearchAsync(IList<Expression<Func<TEntity, bool>>> predicates, params Expression<Func<TEntity, object>>[] includesProperies)
        {
            IQueryable<TEntity> query = _context.Set<TEntity>();

            if (predicates.Any())
            {
                var predicatesChain = PredicateBuilder.New<TEntity>();
                foreach (var predicate in predicates)
                {
                    predicatesChain.Or(predicate);
                }
                query = query.Where(predicatesChain);
            }
            if (includesProperies.Any())
            {
                foreach (var includeProp in includesProperies)
                {
                    query = query.Include(includeProp);
                }
            }
            return await query.AsNoTracking().ToListAsync();
        }

        public async Task<TEntity> UpdateAsync(TEntity Entity)
        {
            await Task.Run(() => _context.Set<TEntity>().Update(Entity));
            return Entity;
        }
    }
}

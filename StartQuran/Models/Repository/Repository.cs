using StartQuran.Areas.Identity.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace StartQuran.Models.Repository
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private readonly IdentityContext _context;
        private readonly DbSet<TEntity> _dbSet;
        public Repository(IdentityContext context)
        {
            _context = context;
            _dbSet = _context.Set<TEntity>();
        }

        public async Task Add(TEntity entity)
        {
            //To ignore ef core of tracking this object to optimize adding to database
            _context.ChangeTracker.AutoDetectChangesEnabled = false;
            await _dbSet.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task AddRange(List<TEntity> entities)
        {
            _context.ChangeTracker.AutoDetectChangesEnabled = false;
            await _dbSet.AddRangeAsync(entities);
            await _context.SaveChangesAsync();
        }

        public async Task AddRange(ICollection<TEntity> entities)
        {
            _context.ChangeTracker.AutoDetectChangesEnabled = false;
            await _dbSet.AddRangeAsync(entities);
            await _context.SaveChangesAsync();
        }

        public async Task<TEntity> FirstOrDefault(Expression<Func<TEntity, bool>> wherePredict)
        {
            return await _dbSet.FirstOrDefaultAsync(wherePredict);
        }

        public async Task<TEntity> FirstOrDefault(Expression<Func<TEntity, bool>> wherePredict, string includeProperties)
        {
            IQueryable<TEntity> query = _dbSet.AsNoTracking();
            foreach (string navigationProp in includeProperties.Split(","))
            {
                query = query.Include(navigationProp);
            }
            return await query.FirstOrDefaultAsync(wherePredict);
        }

        public IQueryable<TEntity> GetAll()
        {
            return _dbSet.AsNoTracking();
            
        }

        public IQueryable<TEntity> GetAll(string includeProperties)
        {
            IQueryable<TEntity> query = _dbSet.AsNoTracking();
            foreach (string navigationProp in includeProperties.Split(","))
            {
                query = query.Include(navigationProp);
            }
            return query;
        }

        public  IEnumerable<TEntity> GetAll(Expression<Func<TEntity, bool>> filter, string IncludeProperties)
        {
            IQueryable<TEntity> query = _dbSet.AsNoTracking();
            if (filter != null)
            {
                query = query.Where(filter);
            }

            if (IncludeProperties != null)
            {
                foreach (var item in IncludeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(item);
                }
            }
            return  query.ToList();
        }

        public async Task Remove(TEntity entity)
        {
            _dbSet.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<TEntity> Remove(int id)
        {
            var entity = await _dbSet.FindAsync(id);
            await Remove(entity);
            return entity;
        }
        public async Task RemoveList(IEnumerable<TEntity> list)
        {
            _dbSet.RemoveRange(list);
            await _context.SaveChangesAsync();
        }


        public async Task Update(TEntity entity)
        {
            _dbSet.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateRange(IEnumerable<TEntity> entity)
        {
            _dbSet.UpdateRange(entity);
            await _context.SaveChangesAsync();
        }
        public  Task<bool> IsExist(System.Linq.Expressions.Expression<Func<TEntity, bool>> expression)
        {
            return  _context.Set<TEntity>().AnyAsync(expression);
        }

        public IEnumerable<TEntity> Get(System.Linq.Expressions.Expression<Func<TEntity, bool>> expression)
        {
            return _context.Set<TEntity>().Where(expression);
        }

        public List<TEntity> GetList(System.Linq.Expressions.Expression<Func<TEntity, bool>> expression)
        {
            return _context.Set<TEntity>().Where(expression).ToList();
        }
    }
}
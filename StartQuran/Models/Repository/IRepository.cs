using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace StartQuran.Models.Repository
{
    public interface IRepository<TEntity> where TEntity : class
    {
        public IQueryable<TEntity> GetAll();
        public IQueryable<TEntity> GetAll(string includeProperties);
        IEnumerable<TEntity> GetAll(
           Expression<Func<TEntity, bool>> filter,
           string IncludeProperties
           );
        public Task<TEntity> FirstOrDefault(Expression<Func<TEntity, bool>> wherePredict);
        public Task<TEntity> FirstOrDefault(Expression<Func<TEntity, bool>> wherePredict, string includeProperties);
        public Task Add(TEntity entity);
        public Task AddRange(List<TEntity> entities);
        public Task AddRange(ICollection<TEntity> entities);
        public Task Remove(TEntity entity);
        public Task<TEntity> Remove(int id);
        public Task RemoveList(IEnumerable<TEntity> list);

        public Task Update(TEntity entity);
        public Task UpdateRange(IEnumerable<TEntity> entity);
        public  Task<bool> IsExist(System.Linq.Expressions.Expression<Func<TEntity, bool>> expression);
        IEnumerable<TEntity> Get(Expression<Func<TEntity, bool>> expression);
        public List<TEntity> GetList(System.Linq.Expressions.Expression<Func<TEntity, bool>> expression);

        

    }
}

using Core.DataAccess;
using Core.Entities;
using Core.Utilities.Results;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.EntityFramework
{
    public class EfEntityRepositoryBase<TEntity, TContext> : IEntityRepository<TEntity>
    where TEntity : class, IEntity, new()
    where TContext : DbContext, new()
    {
        public TEntity Add(TEntity entity)
        {
            using (var context = new TContext())
            {
                var addedEntity = context.Entry(entity);
                addedEntity.State = EntityState.Added;
                context.SaveChanges();
                return entity;
            }
        }

        public IResult AddRange(IList<TEntity> entity)
        {
            try
            {
                using (var context = new TContext())
                {
                    context.AddRange(entity);
                    context.SaveChanges();
                    return new SuccessResult();
                }
            }
            catch
            {
                return new ErrorResult();
            }

        }

        public void Delete(TEntity entity)
        {
            using (var context = new TContext())
            {
                var deletedEntity = context.Entry(entity);
                deletedEntity.State = EntityState.Deleted;
                context.SaveChanges();
            }
        }

        public IResult DeleteRange(IList<TEntity> entity)
        {
            try
            {
                using (var context = new TContext())
                {
                    context.RemoveRange(entity);
                    context.SaveChanges();
                }
                return new SuccessResult();
            }
            catch
            {
                return new ErrorResult();
            }
        }

        public TEntity Get(Expression<Func<TEntity, bool>> filter)
        {
            using (var context = new TContext())
            {
                return context.Set<TEntity>().SingleOrDefault(filter);
            }
        }

        public IList<TEntity> GetList(Expression<Func<TEntity, bool>> filter = null)
        {
            using (var context = new TContext())
            {
                return filter == null
                    ? context.Set<TEntity>().ToList()
                    : context.Set<TEntity>().Where(filter).ToList();
            }
        }

        public TEntity Update(TEntity entity)
        {
            using (var context = new TContext())
            {
                var updatedEntity = context.Entry(entity);
                updatedEntity.State = EntityState.Modified;
                context.SaveChanges();
                return entity;
            }
        }

        public void UpdateRange(List<TEntity> entity)
        {
            using (var context = new TContext())
            {
                context.UpdateRange(entity);
                context.SaveChanges();
            }

        }
    }
}

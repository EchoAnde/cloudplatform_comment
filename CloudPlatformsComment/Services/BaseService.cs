using CloudPlatformsComment.Data;
using CloudPlatformsComment.IServices;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace CloudPlatformsComment.Services
{
    public abstract class BaseService<TEntity> : IBaseService<TEntity> where TEntity : class, new()
    {
        private ApplicationDbContext _context;

        public BaseService(ApplicationDbContext context)
        {
            _context = context;
        }

        public TEntity AddEntity(TEntity entity)
        {
            _context.Set<TEntity>().Add(entity);
            return entity;
        }

        public async Task<TEntity> AddEntityAsync(TEntity entity)
        {
            await _context.Set<TEntity>().AddAsync(entity);
            return entity;
        }

        public bool DeleteEntities(ICollection<TEntity> entities)
        {
            if (entities == null)
            {
                throw new ArgumentException("不能为null", "entities");
            }
            foreach (var entity in entities)
            {
                DeleteEntity(entity);
            }
            return true;
        }

        public bool DeleteEntity(TEntity entity)
        {
            _context.Entry(entity).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
            return true;
        }

        public bool EditEntity(TEntity entity)
        {
            _context.Entry(entity).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            return true;
        }

        public virtual IQueryable<TEntity> LoadEntities(Expression<Func<TEntity, bool>> where)
        {
            return _context.Set<TEntity>().Where(where);
        }

        public virtual IQueryable<TEntity> LoadEntitiesOrderby<TSource>(Expression<Func<TEntity, bool>> where, Expression<Func<TEntity, TSource>> order, bool isDesc = false)
        {
            if (isDesc)
            {
                return LoadEntities(where).OrderByDescending(order);
            }
            return LoadEntities(where).OrderBy(order);
        }

        public virtual TEntity LoadEntity(Expression<Func<TEntity, bool>> where)
        {
            return _context.Set<TEntity>().FirstOrDefault(where);
        }

        public bool SaveChanges()
        {
            return _context.SaveChanges() > 0;
        }

        public async Task<bool> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }

        public IQueryable<TEntity> LoadEntitiesPaging<TSource>(int pageIndex, int pageSize, out int totalCount, Expression<Func<TEntity, bool>> where, Expression<Func<TEntity, TSource>> orderby, bool isDesc = false)
        {
            var list = LoadEntitiesOrderby(where, orderby, isDesc);
            pageIndex = pageIndex <= 0 ? 1 : pageIndex;
            pageSize = pageSize <= 0 ? 10 : pageSize;
            totalCount = list.Count();
            return list.Skip((pageIndex - 1) * pageSize)
                .Take(pageSize);
        }


    }
}

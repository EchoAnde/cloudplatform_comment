using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace CloudPlatformsComment.IServices
{
    public interface IBaseService<TEntity> where TEntity : class, new()
    {
        /// <summary>
        /// 获取符合条件的实体集合
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        IQueryable<TEntity> LoadEntities(Expression<Func<TEntity, bool>> where);


        /// <summary>
        /// 获取符合条件的实体集合并排序
        /// </summary>
        /// <typeparam name="TSource"></typeparam>
        /// <param name="where"></param>
        /// <param name="order"></param>
        /// <param name="isDesc">是否倒序</param>
        /// <returns></returns>
        IQueryable<TEntity> LoadEntitiesOrderby<TSource>(Expression<Func<TEntity, bool>> where, Expression<Func<TEntity, TSource>> order, bool isDesc = false);


        /// <summary>
        /// 获取符合条件的单个实体
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        TEntity LoadEntity(Expression<Func<TEntity, bool>> where);


        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        TEntity AddEntity(TEntity entity);

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        Task<TEntity> AddEntityAsync(TEntity entity);

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        bool EditEntity(TEntity entity);


        /// <summary>
        /// 删除单个
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        bool DeleteEntity(TEntity entity);


        /// <summary>
        /// 删除多个
        /// </summary>
        /// <param name="entities"></param>
        /// <returns></returns>
        bool DeleteEntities(ICollection<TEntity> entities);

        /// <summary>
        /// 保存更改
        /// </summary>
        /// <returns></returns>
        bool SaveChanges();

        /// <summary>
        /// 保存更改
        /// </summary>
        /// <returns></returns>
        Task<bool> SaveChangesAsync();

        /// <summary>
        /// 查询并分页
        /// </summary>
        /// <typeparam name="TSource"></typeparam>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="totalCount"></param>
        /// <param name="where"></param>
        /// <param name="orderby"></param>
        /// <param name="isDesc"></param>
        /// <returns></returns>
        IQueryable<TEntity> LoadEntitiesPaging<TSource>(int pageIndex, int pageSize, out int totalCount, Expression<Func<TEntity, bool>> where, Expression<Func<TEntity, TSource>> orderby, bool isDesc = false);
    }
}

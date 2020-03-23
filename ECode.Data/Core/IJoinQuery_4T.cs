﻿using System;
using System.Linq.Expressions;

namespace ECode.Data
{
    public interface IJoinedResult<TEntity, TJoin1, TJoin2, TJoin3>
    {
        /// <summary>
        /// select选择
        /// </summary>
        IQuerySet<TSelect> Select<TSelect>(Expression<Func<TEntity, TJoin1, TJoin2, TJoin3, TSelect>> selectExpression);

        /// <summary>
        /// where过滤
        /// </summary>
        IJoinFilterResult<TEntity, TJoin1, TJoin2, TJoin3> Where(Expression<Func<TEntity, TJoin1, TJoin2, TJoin3, bool>> whereExpression);

        /// <summary>
        /// group by聚合
        /// </summary>
        IJoinGroupedResult<TEntity, TJoin1, TJoin2, TJoin3> GroupBy(Expression<Func<TEntity, TJoin1, TJoin2, TJoin3, object[]>> groupByExpression);

        /// <summary>
        /// order by排序
        /// </summary>
        IJoinSortedResult<TEntity, TJoin1, TJoin2, TJoin3> OrderBy(Expression<Func<TEntity, TJoin1, TJoin2, TJoin3, object[]>> orderByExpression);


        /// <summary>
        /// join连接
        /// </summary>
        IJoinedResult<TEntity, TJoin1, TJoin2, TJoin3, TJoin4> Join<TJoin4>(Expression<Func<TEntity, TJoin1, TJoin2, TJoin3, TJoin4, bool>> onExpression);

        /// <summary>
        /// join连接
        /// </summary>
        IJoinedResult<TEntity, TJoin1, TJoin2, TJoin3, TJoin4> Join<TJoin4>(object partitionObject, Expression<Func<TEntity, TJoin1, TJoin2, TJoin3, TJoin4, bool>> onExpression);

        /// <summary>
        /// join连接
        /// </summary>
        IJoinedResult<TEntity, TJoin1, TJoin2, TJoin3, TJoin4> Join<TJoin4>(IQuerySet<TJoin4> querySet, Expression<Func<TEntity, TJoin1, TJoin2, TJoin3, TJoin4, bool>> onExpression);

        /// <summary>
        /// left join连接
        /// </summary>
        IJoinedResult<TEntity, TJoin1, TJoin2, TJoin3, TJoin4> LeftJoin<TJoin4>(Expression<Func<TEntity, TJoin1, TJoin2, TJoin3, TJoin4, bool>> onExpression);

        /// <summary>
        /// left join连接
        /// </summary>
        IJoinedResult<TEntity, TJoin1, TJoin2, TJoin3, TJoin4> LeftJoin<TJoin4>(object partitionObject, Expression<Func<TEntity, TJoin1, TJoin2, TJoin3, TJoin4, bool>> onExpression);

        /// <summary>
        /// left join连接
        /// </summary>
        IJoinedResult<TEntity, TJoin1, TJoin2, TJoin3, TJoin4> LeftJoin<TJoin4>(IQuerySet<TJoin4> querySet, Expression<Func<TEntity, TJoin1, TJoin2, TJoin3, TJoin4, bool>> onExpression);
    }


    public interface IJoinFilterResult<TEntity, TJoin1, TJoin2, TJoin3>
    {
        /// <summary>
        /// select选择
        /// </summary>
        IQuerySet<TSelect> Select<TSelect>(Expression<Func<TEntity, TJoin1, TJoin2, TJoin3, TSelect>> selectExpression);

        /// <summary>
        /// where过滤
        /// </summary>
        IJoinFilterResult<TEntity, TJoin1, TJoin2, TJoin3> Where(Expression<Func<TEntity, TJoin1, TJoin2, TJoin3, bool>> whereExpression);

        /// <summary>
        /// group by聚合
        /// </summary>
        IJoinGroupedResult<TEntity, TJoin1, TJoin2, TJoin3> GroupBy(Expression<Func<TEntity, TJoin1, TJoin2, TJoin3, object[]>> groupByExpression);

        /// <summary>
        /// order by排序
        /// </summary>
        IJoinSortedResult<TEntity, TJoin1, TJoin2, TJoin3> OrderBy(Expression<Func<TEntity, TJoin1, TJoin2, TJoin3, object[]>> orderByExpression);
    }


    public interface IJoinSortedResult<TEntity, TJoin1, TJoin2, TJoin3>
    {
        /// <summary>
        /// 分页
        /// </summary>
        /// <param name="offset">偏移量</param>
        /// <param name="count">记录数</param>
        IJoinPagedResult<TEntity, TJoin1, TJoin2, TJoin3> Paging(uint offset, uint count);

        /// <summary>
        /// select选择
        /// </summary>
        IQuerySet<TSelect> Select<TSelect>(Expression<Func<TEntity, TJoin1, TJoin2, TJoin3, TSelect>> selectExpression);
    }


    public interface IJoinPagedResult<TEntity, TJoin1, TJoin2, TJoin3>
    {
        /// <summary>
        /// select选择
        /// </summary>
        IQuerySet<TSelect> Select<TSelect>(Expression<Func<TEntity, TJoin1, TJoin2, TJoin3, TSelect>> selectExpression);
    }


    public interface IJoinGroupedResult<TEntity, TJoin1, TJoin2, TJoin3>
    {
        /// <summary>
        /// select选择
        /// </summary>
        IQuerySet<TSelect> Select<TSelect>(Expression<Func<TEntity, TJoin1, TJoin2, TJoin3, TSelect>> selectExpression);

        /// <summary>
        /// having过滤
        /// </summary>
        IJoinGroupHavingResult<TEntity, TJoin1, TJoin2, TJoin3> Having(Expression<Func<TEntity, TJoin1, TJoin2, TJoin3, bool>> havingExpression);

        /// <summary>
        /// order by排序
        /// </summary>
        IJoinGroupSortedResult<TEntity, TJoin1, TJoin2, TJoin3> OrderBy(Expression<Func<TEntity, TJoin1, TJoin2, TJoin3, object[]>> orderByExpression);
    }


    public interface IJoinGroupHavingResult<TEntity, TJoin1, TJoin2, TJoin3>
    {
        /// <summary>
        /// select选择
        /// </summary>
        IQuerySet<TSelect> Select<TSelect>(Expression<Func<TEntity, TJoin1, TJoin2, TJoin3, TSelect>> selectExpression);

        /// <summary>
        /// order by排序
        /// </summary>
        IJoinGroupSortedResult<TEntity, TJoin1, TJoin2, TJoin3> OrderBy(Expression<Func<TEntity, TJoin1, TJoin2, TJoin3, object[]>> orderByExpression);
    }


    public interface IJoinGroupSortedResult<TEntity, TJoin1, TJoin2, TJoin3>
    {
        /// <summary>
        /// select选择
        /// </summary>
        IQuerySet<TSelect> Select<TSelect>(Expression<Func<TEntity, TJoin1, TJoin2, TJoin3, TSelect>> selectExpression);
    }
}
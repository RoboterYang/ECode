﻿
namespace ECode.Data.MySQL
{
    public class MySQLJoinedResult<TEntity, TJoin1> : DbJoinedResult<TEntity, TJoin1>
    {
        internal MySQLJoinedResult(DbSession session, DbQueryContext queryContext)
            : base(session, queryContext)
        {

        }
    }


    public class MySQLJoinFilterResult<TEntity, TJoin1> : DbJoinFilterResult<TEntity, TJoin1>
    {
        internal MySQLJoinFilterResult(DbSession session, DbQueryContext queryContext)
            : base(session, queryContext)
        {

        }
    }


    public class MySQLJoinSortedResult<TEntity, TJoin1> : DbJoinSortedResult<TEntity, TJoin1>
    {
        internal MySQLJoinSortedResult(DbSession session, DbQueryContext queryContext)
            : base(session, queryContext)
        {

        }
    }


    public class MySQLJoinPagedResult<TEntity, TJoin1> : DbJoinPagedResult<TEntity, TJoin1>
    {
        internal MySQLJoinPagedResult(DbSession session, DbQueryContext queryContext)
            : base(session, queryContext)
        {

        }
    }


    public class MySQLJoinGroupedResult<TEntity, TJoin1> : DbJoinGroupedResult<TEntity, TJoin1>
    {
        internal MySQLJoinGroupedResult(DbSession session, DbQueryContext queryContext)
            : base(session, queryContext)
        {

        }
    }


    public class MySQLJoinGroupHavingResult<TEntity, TJoin1> : DbJoinGroupHavingResult<TEntity, TJoin1>
    {
        internal MySQLJoinGroupHavingResult(DbSession session, DbQueryContext queryContext)
            : base(session, queryContext)
        {

        }
    }


    public class MySQLJoinGroupSortedResult<TEntity, TJoin1> : DbJoinGroupSortedResult<TEntity, TJoin1>
    {
        internal MySQLJoinGroupSortedResult(DbSession session, DbQueryContext queryContext)
            : base(session, queryContext)
        {

        }
    }
}

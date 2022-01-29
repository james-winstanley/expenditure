using Smooth.IoC.UnitOfWork.Interfaces;
using Winstanley.Expenditure.Database.Extensions;

namespace Winstanley.Expenditure.Database.Repositories;

public abstract partial class Repository<TEntity, TPk>
    where TEntity : class
    where TPk : IComparable
{
    public virtual async Task<IEnumerable<dynamic>> QueryDynamicAsync(ISession session, string sql, object parameters, CommandType commandType = CommandType.Text)
    {
        return await session.QueryDynamicAsync<TEntity>(sql, parameters, commandType);
    }


    public virtual async Task<IEnumerable<dynamic>> QueryDynamicAsync(IUnitOfWork unitOfWork, string sql, object parameters, CommandType commandType = CommandType.Text)
    {
        return await unitOfWork.QueryDynamicAsync<TEntity>(sql, parameters, commandType);
    }


    public virtual async Task<IEnumerable<dynamic>> QueryDynamicAsync<TSession>(string sql, object parameters, CommandType commandType = CommandType.Text) where TSession : class, ISession
    {
        using IUnitOfWork unitOfWork = Factory.Create<IUnitOfWork, TSession>();
        return await QueryDynamicAsync(unitOfWork, sql, parameters, commandType);
    }


    public virtual IEnumerable<dynamic> QueryDynamic(ISession session, string sql, object parameters, CommandType commandType = CommandType.Text)
    {
        return session.QueryDynamic<TEntity>(sql, parameters, commandType);
    }


    public virtual IEnumerable<dynamic> QueryDynamic(IUnitOfWork unitOfWork, string sql, object parameters, CommandType commandType = CommandType.Text)
    {
        return unitOfWork.QueryDynamic<TEntity>(sql, parameters, commandType);
    }


    public virtual IEnumerable<dynamic> QueryDynamic<TSession>(string sql, object parameters, CommandType commandType = CommandType.Text) where TSession : class, ISession
    {
        using IUnitOfWork unitOfWork = Factory.Create<IUnitOfWork, TSession>();
        return QueryDynamic(unitOfWork, sql, parameters, commandType);
    }
}
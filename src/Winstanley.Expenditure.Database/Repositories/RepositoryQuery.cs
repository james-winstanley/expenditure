using Smooth.IoC.UnitOfWork.Interfaces;
using Winstanley.Expenditure.Database.Extensions;

namespace Winstanley.Expenditure.Database.Repositories;

public abstract partial class Repository<TEntity, TPk>
    where TEntity : class
    where TPk : IComparable
{
    public virtual async Task<IEnumerable<TEntity>> QueryAsync(ISession session, string sql, object parameters, CommandType commandType = CommandType.Text)
    {
        return await session.QueryAsync<TEntity>(sql, parameters, commandType);
    }


    public virtual async Task<IEnumerable<TEntity>> QueryAsync(IUnitOfWork unitOfWork, string sql, object parameters, CommandType commandType = CommandType.Text)
    {
        return await unitOfWork.QueryAsync<TEntity>(sql, parameters, commandType);
    }


    public virtual async Task<IEnumerable<TEntity>> QueryAsync<TSession>(string sql, object parameters, CommandType commandType = CommandType.Text) where TSession : class, ISession
    {
        using IUnitOfWork unitOfWork = Factory.Create<IUnitOfWork, TSession>();
        return await QueryAsync(unitOfWork, sql, parameters, commandType);
    }


    public virtual IEnumerable<TEntity> Query(ISession session, string sql, object parameters, CommandType commandType = CommandType.Text)
    {
        return session.Query<TEntity>(sql, parameters, commandType);
    }


    public virtual IEnumerable<TEntity> Query(IUnitOfWork unitOfWork, string sql, object parameters, CommandType commandType = CommandType.Text)
    {
        return unitOfWork.Query<TEntity>(sql, parameters, commandType);
    }


    public virtual IEnumerable<TEntity> Query<TSession>(string sql, object parameters, CommandType commandType = CommandType.Text) where TSession : class, ISession
    {
        using IUnitOfWork unitOfWork = Factory.Create<IUnitOfWork, TSession>();
        return Query(unitOfWork, sql, parameters, commandType);
    }
}
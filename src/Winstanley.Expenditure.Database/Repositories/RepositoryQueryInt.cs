using Smooth.IoC.UnitOfWork.Interfaces;
using Winstanley.Expenditure.Database.Extensions;

namespace Winstanley.Expenditure.Database.Repositories;

public abstract partial class Repository<TEntity, TPk>
    where TEntity : class
    where TPk : IComparable
{
    public virtual async Task<IEnumerable<int>> QueryIntAsync(ISession session, string sql, object parameters, CommandType commandType = CommandType.Text)
    {
        return await session.QueryIntAsync<TEntity>(sql, parameters, commandType);
    }


    public virtual async Task<IEnumerable<int>> QueryIntAsync(IUnitOfWork unitOfWork, string sql, object parameters, CommandType commandType = CommandType.Text)
    {
        return await unitOfWork.QueryIntAsync<TEntity>(sql, parameters, commandType);
    }


    public virtual async Task<IEnumerable<int>> QueryIntAsync<TSession>(string sql, object parameters, CommandType commandType = CommandType.Text) where TSession : class, ISession
    {
        using IUnitOfWork unitOfWork = Factory.Create<IUnitOfWork, TSession>();
        return await QueryIntAsync(unitOfWork, sql, parameters, commandType);
    }


    public virtual IEnumerable<int> QueryInt(ISession session, string sql, object parameters, CommandType commandType = CommandType.Text)
    {
        return session.QueryInt<TEntity>(sql, parameters, commandType);
    }


    public virtual IEnumerable<int> QueryInt(IUnitOfWork unitOfWork, string sql, object parameters, CommandType commandType = CommandType.Text)
    {
        return unitOfWork.QueryInt<TEntity>(sql, parameters, commandType);
    }


    public virtual IEnumerable<int> QueryInt<TSession>(string sql, object parameters, CommandType commandType = CommandType.Text) where TSession : class, ISession
    {
        using IUnitOfWork unitOfWork = Factory.Create<IUnitOfWork, TSession>();
        return QueryInt(unitOfWork, sql, parameters, commandType);
    }
}
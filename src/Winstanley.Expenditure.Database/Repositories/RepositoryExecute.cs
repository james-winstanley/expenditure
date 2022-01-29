using Smooth.IoC.UnitOfWork.Interfaces;
using Winstanley.Expenditure.Database.Extensions;

namespace Winstanley.Expenditure.Database.Repositories;

public partial class Repository<TEntity, TPk>
    where TEntity : class
    where TPk : IComparable
{
    public virtual async Task<int> ExecuteAsync(ISession session, string sql, object parameters, CommandType commandType = CommandType.Text)
    {
        return await session.ExecuteAsync<TEntity>(sql, parameters, commandType);
    }


    public virtual async Task<int> ExecuteAsync(IUnitOfWork unitOfWork, string sql, object parameters, CommandType commandType = CommandType.Text)
    {
        return await unitOfWork.ExecuteAsync<TEntity>(sql, parameters, commandType);
    }


    public virtual async Task<int> ExecuteAsync<TSession>(string sql, object parameters, CommandType commandType = CommandType.Text) where TSession : class, ISession
    {
        using IUnitOfWork unitOfWork = Factory.Create<IUnitOfWork, TSession>();
        return await ExecuteAsync(unitOfWork, sql, parameters, commandType);
    }


    public virtual int Execute(ISession session, string sql, object parameters, CommandType commandType = CommandType.Text)
    {
        return session.Execute<TEntity>(sql, parameters, commandType);
    }


    public virtual int Execute(IUnitOfWork unitOfWork, string sql, object parameters, CommandType commandType = CommandType.Text)
    {
        return unitOfWork.Execute<TEntity>(sql, parameters, commandType);
    }


    public virtual int Execute<TSession>(string sql, object parameters, CommandType commandType = CommandType.Text) where TSession : class, ISession
    {
        using IUnitOfWork unitOfWork = Factory.Create<IUnitOfWork, TSession>();
        return Execute(unitOfWork, sql, parameters, commandType);
    }
}
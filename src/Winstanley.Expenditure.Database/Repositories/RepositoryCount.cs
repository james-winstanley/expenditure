using Dapper.FastCrud.Configuration.StatementOptions.Builders;
using Smooth.IoC.Repository.UnitOfWork.Extensions;
using Smooth.IoC.UnitOfWork.Interfaces;

// Harrier.Common.Database.Extensions;

namespace Winstanley.Expenditure.Database.Repositories;

public partial class Repository<TEntity, TPk>
    where TEntity : class
    where TPk : IComparable
{
    public override int Count(ISession session)
    {
        return Count(session, null);
    }


    public override int Count(IUnitOfWork unitOfWork)
    {
        return Count(unitOfWork, null);
    }


    public override int Count<TSession>()
    {
        using IUnitOfWork unitOfWork = Factory.Create<IUnitOfWork, TSession>();
        return Count(unitOfWork);
    }


    public override async Task<int> CountAsync(ISession session)
    {
        return await CountAsync(session, null);
    }


    public override async Task<int> CountAsync(IUnitOfWork unitOfWork)
    {
        return await CountAsync(unitOfWork, null);
    }


    public override async Task<int> CountAsync<TSession>()
    {
        using IUnitOfWork unitOfWork = Factory.Create<IUnitOfWork, TSession>();
        return await CountAsync(unitOfWork);
    }


    public virtual int Count(ISession session, Action<IConditionalSqlStatementOptionsBuilder<TEntity>> statementOptions)
    {
        //if (statementOptions != null)
        //    statementOptions += x => x.AttachToTransaction(session.UnitOfWork().Transaction);
        //else
        //    statementOptions = x => x.AttachToTransaction(session.UnitOfWork().Transaction);

        return session.Count(statementOptions);
    }


    public virtual int Count(IUnitOfWork unitOfWork, Action<IConditionalSqlStatementOptionsBuilder<TEntity>> statementOptions)
    {
        //if (statementOptions != null)
        //    statementOptions += x => x.AttachToTransaction(unitOfWork.Transaction);
        //else
        //    statementOptions = x => x.AttachToTransaction(unitOfWork.Transaction);

        return unitOfWork.Connection.Count(statementOptions);
    }


    public virtual int Count<TSession>(Action<IConditionalSqlStatementOptionsBuilder<TEntity>> statementOptions) where TSession : class, ISession
    {
        using IUnitOfWork unitOfWork = Factory.Create<IUnitOfWork, TSession>();
        return Count(unitOfWork, statementOptions);
    }


    public virtual async Task<int> CountAsync(ISession session, Action<IConditionalSqlStatementOptionsBuilder<TEntity>> statementOptions)
    {
        //if (statementOptions != null)
        //    statementOptions += x => x.AttachToTransaction(session.UnitOfWork().Transaction);
        //else
        //    statementOptions = x => x.AttachToTransaction(session.UnitOfWork().Transaction);

        return await session.CountAsync(statementOptions);
    }


    public virtual async Task<int> CountAsync(IUnitOfWork unitOfWork, Action<IConditionalSqlStatementOptionsBuilder<TEntity>> statementOptions)
    {
        //if (statementOptions != null)
        //    statementOptions += x => x.AttachToTransaction(unitOfWork.Transaction);
        //else
        //    statementOptions = x => x.AttachToTransaction(unitOfWork.Transaction);

        return await unitOfWork.Connection.CountAsync(statementOptions);
    }


    public virtual async Task<int> CountAsync<TSession>(Action<IConditionalSqlStatementOptionsBuilder<TEntity>> statementOptions) where TSession : class, ISession
    {
        using IUnitOfWork unitOfWork = Factory.Create<IUnitOfWork, TSession>();
        return await CountAsync(unitOfWork, statementOptions);
    }
}
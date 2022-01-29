using Dapper.FastCrud.Configuration.StatementOptions.Builders;
using Smooth.IoC.Repository.UnitOfWork.Extensions;
using Smooth.IoC.UnitOfWork.Interfaces;
// Harrier.Common.Database.Extensions;

namespace Winstanley.Expenditure.Database.Repositories;

public partial class Repository<TEntity, TPk>
    where TEntity : class
    where TPk : IComparable
{
    public IEnumerable<TEntity> Find(ISession session, Action<IRangedBatchSelectSqlSqlStatementOptionsOptionsBuilder<TEntity>> statementOptions)
    {
        //if (statementOptions != null)
        //    statementOptions += x => x.AttachToTransaction(session.UnitOfWork().Transaction);
        //else
        //    statementOptions = x => x.AttachToTransaction(session.UnitOfWork().Transaction);

        return session.Find(statementOptions);
    }


    public IEnumerable<TEntity> Find(IUnitOfWork unitOfWork, Action<IRangedBatchSelectSqlSqlStatementOptionsOptionsBuilder<TEntity>> statementOptions)
    {
        //if (statementOptions != null)
        //    statementOptions += x => x.AttachToTransaction(unitOfWork.Transaction);
        //else
        //    statementOptions = x => x.AttachToTransaction(unitOfWork.Transaction);

        return unitOfWork.Connection.Find(statementOptions);
    }


    public IEnumerable<TEntity> Find<TSession>(Action<IRangedBatchSelectSqlSqlStatementOptionsOptionsBuilder<TEntity>> statementOptions) where TSession : class, ISession
    {
        using IUnitOfWork unitOfWork = Factory.Create<IUnitOfWork, TSession>();
        return Find(unitOfWork, statementOptions);
    }


    public async Task<IEnumerable<TEntity>> FindAsync(ISession session, Action<IRangedBatchSelectSqlSqlStatementOptionsOptionsBuilder<TEntity>> statementOptions)
    {
        //if (statementOptions != null)
        //    statementOptions += x => x.AttachToTransaction(session.UnitOfWork().Transaction);
        //else
        //    statementOptions = x => x.AttachToTransaction(session.UnitOfWork().Transaction);

        return await session.FindAsync(statementOptions);
    }


    public async Task<IEnumerable<TEntity>> FindAsync(IUnitOfWork unitOfWork, Action<IRangedBatchSelectSqlSqlStatementOptionsOptionsBuilder<TEntity>> statementOptions)
    {
        //if (statementOptions != null)
        //    statementOptions += x => x.AttachToTransaction(unitOfWork.Transaction);
        //else
        //    statementOptions = x => x.AttachToTransaction(unitOfWork.Transaction);

        return await unitOfWork.Connection.FindAsync(statementOptions);
    }


    public async Task<IEnumerable<TEntity>> FindAsync<TSession>(Action<IRangedBatchSelectSqlSqlStatementOptionsOptionsBuilder<TEntity>> statementOptions) where TSession : class, ISession
    {
        using IUnitOfWork unitOfWork = Factory.Create<IUnitOfWork, TSession>();
        return await FindAsync(unitOfWork, statementOptions);
    }
}

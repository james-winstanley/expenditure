using Dapper.FastCrud.Configuration.StatementOptions.Builders;
using Smooth.IoC.UnitOfWork.Interfaces;

namespace Winstanley.Expenditure.Database.Interfaces;

public interface IRepository<TEntity, TPk> : Smooth.IoC.Repository.UnitOfWork.IRepository<TEntity, TPk>
    where TEntity : class where TPk : IComparable
{
    #region Dapper

    int Execute(ISession session, string sql, object parameters, CommandType commandType = CommandType.Text);
    int Execute(IUnitOfWork unitOfWork, string sql, object parameters, CommandType commandType = CommandType.Text);
    int Execute<TSession>(string sql, object parameters, CommandType commandType = CommandType.Text) where TSession : class, ISession;
    Task<int> ExecuteAsync(ISession session, string sql, object parameters, CommandType commandType = CommandType.Text);
    Task<int> ExecuteAsync(IUnitOfWork unitOfWork, string sql, object parameters, CommandType commandType = CommandType.Text);
    Task<int> ExecuteAsync<TSession>(string sql, object parameters, CommandType commandType = CommandType.Text) where TSession : class, ISession;

    IEnumerable<TEntity> Query(ISession session, string sql, object parameters, CommandType commandType = CommandType.Text);
    IEnumerable<TEntity> Query(IUnitOfWork unitOfWork, string sql, object parameters, CommandType commandType = CommandType.Text);
    IEnumerable<TEntity> Query<TSession>(string sql, object parameters, CommandType commandType = CommandType.Text) where TSession : class, ISession;
    Task<IEnumerable<TEntity>> QueryAsync(ISession session, string sql, object parameters, CommandType commandType = CommandType.Text);
    Task<IEnumerable<TEntity>> QueryAsync(IUnitOfWork unitOfWork, string sql, object parameters, CommandType commandType = CommandType.Text);
    Task<IEnumerable<TEntity>> QueryAsync<TSession>(string sql, object parameters, CommandType commandType = CommandType.Text) where TSession : class, ISession;

    IEnumerable<int> QueryInt(ISession session, string sql, object parameters, CommandType commandType = CommandType.Text);
    IEnumerable<int> QueryInt(IUnitOfWork unitOfWork, string sql, object parameters, CommandType commandType = CommandType.Text);
    IEnumerable<int> QueryInt<TSession>(string sql, object parameters, CommandType commandType = CommandType.Text) where TSession : class, ISession;
    Task<IEnumerable<int>> QueryIntAsync(ISession session, string sql, object parameters, CommandType commandType = CommandType.Text);
    Task<IEnumerable<int>> QueryIntAsync(IUnitOfWork unitOfWork, string sql, object parameters, CommandType commandType = CommandType.Text);
    Task<IEnumerable<int>> QueryIntAsync<TSession>(string sql, object parameters, CommandType commandType = CommandType.Text) where TSession : class, ISession;

    IEnumerable<dynamic> QueryDynamic(ISession session, string sql, object parameters, CommandType commandType = CommandType.Text);
    IEnumerable<dynamic> QueryDynamic(IUnitOfWork unitOfWork, string sql, object parameters, CommandType commandType = CommandType.Text);
    IEnumerable<dynamic> QueryDynamic<TSession>(string sql, object parameters, CommandType commandType = CommandType.Text) where TSession : class, ISession;
    Task<IEnumerable<dynamic>> QueryDynamicAsync(ISession session, string sql, object parameters, CommandType commandType = CommandType.Text);
    Task<IEnumerable<dynamic>> QueryDynamicAsync(IUnitOfWork unitOfWork, string sql, object parameters, CommandType commandType = CommandType.Text);
    Task<IEnumerable<dynamic>> QueryDynamicAsync<TSession>(string sql, object parameters, CommandType commandType = CommandType.Text) where TSession : class, ISession;

    #endregion Dapper


    // Count
    new int Count(ISession session);
    new int Count(IUnitOfWork unitOfWork);
    new int Count<TSession>() where TSession : class, ISession;
    new Task<int> CountAsync(ISession session);
    new Task<int> CountAsync(IUnitOfWork unitOfWork);
    new Task<int> CountAsync<TSession>() where TSession : class, ISession;

    int Count(ISession session, Action<IConditionalSqlStatementOptionsBuilder<TEntity>> statementOptions);
    int Count(IUnitOfWork unitOfWork, Action<IConditionalSqlStatementOptionsBuilder<TEntity>> statementOptions);
    int Count<TSession>(Action<IConditionalSqlStatementOptionsBuilder<TEntity>> statementOptions) where TSession : class, ISession;
    Task<int> CountAsync(ISession session, Action<IConditionalSqlStatementOptionsBuilder<TEntity>> statementOptions);
    Task<int> CountAsync(IUnitOfWork unitOfWork, Action<IConditionalSqlStatementOptionsBuilder<TEntity>> statementOptions);
    Task<int> CountAsync<TSession>(Action<IConditionalSqlStatementOptionsBuilder<TEntity>> statementOptions) where TSession : class, ISession;


    // Find
    IEnumerable<TEntity> Find(ISession session, Action<IRangedBatchSelectSqlSqlStatementOptionsOptionsBuilder<TEntity>> statementOptions);
    IEnumerable<TEntity> Find(IUnitOfWork unitOfWork, Action<IRangedBatchSelectSqlSqlStatementOptionsOptionsBuilder<TEntity>> statementOptions);
    IEnumerable<TEntity> Find<TSession>(Action<IRangedBatchSelectSqlSqlStatementOptionsOptionsBuilder<TEntity>> statementOptions) where TSession : class, ISession;
    Task<IEnumerable<TEntity>> FindAsync(ISession session, Action<IRangedBatchSelectSqlSqlStatementOptionsOptionsBuilder<TEntity>> statementOptions);
    Task<IEnumerable<TEntity>> FindAsync(IUnitOfWork unitOfWork, Action<IRangedBatchSelectSqlSqlStatementOptionsOptionsBuilder<TEntity>> statementOptions);
    Task<IEnumerable<TEntity>> FindAsync<TSession>(Action<IRangedBatchSelectSqlSqlStatementOptionsOptionsBuilder<TEntity>> statementOptions) where TSession : class, ISession;
}
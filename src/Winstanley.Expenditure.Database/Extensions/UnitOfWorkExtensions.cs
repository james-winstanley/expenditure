using Smooth.IoC.Repository.UnitOfWork.Helpers;
using Smooth.IoC.UnitOfWork.Interfaces;

namespace Winstanley.Expenditure.Database.Extensions;

public static class UnitOfWorkExtensions
{
    private static readonly SqlDialectHelper DialogueHelper = new();


    public static int Execute<TEntity>(this IUnitOfWork unitOfWork, string sql, object parameters = null, CommandType commandType = CommandType.Text) where TEntity : class
    {
        DialogueHelper.SetDialogueIfNeeded<TEntity>(unitOfWork.SqlDialect);
        return unitOfWork.Connection.Execute(sql, parameters, unitOfWork.Transaction, commandType: commandType);
    }


    public static Task<int> ExecuteAsync<TEntity>(this IUnitOfWork unitOfWork, string sql, object parameters = null, CommandType commandType = CommandType.Text) where TEntity : class
    {
        DialogueHelper.SetDialogueIfNeeded<TEntity>(unitOfWork.SqlDialect);
        return unitOfWork.Connection.ExecuteAsync(sql, parameters, unitOfWork.Transaction, commandType: commandType);
    }


    public static IEnumerable<TEntity> Query<TEntity>(this IUnitOfWork unitOfWork, string sql, object parameters = null, CommandType commandType = CommandType.Text) where TEntity : class
    {
        DialogueHelper.SetDialogueIfNeeded<TEntity>(unitOfWork.SqlDialect);
        return unitOfWork.Connection.Query<TEntity>(sql, parameters, unitOfWork.Transaction, commandType: commandType);
    }


    public static Task<IEnumerable<TEntity>> QueryAsync<TEntity>(this IUnitOfWork unitOfWork, string sql, object parameters = null, CommandType commandType = CommandType.Text) where TEntity : class
    {
        DialogueHelper.SetDialogueIfNeeded<TEntity>(unitOfWork.SqlDialect);
        return unitOfWork.Connection.QueryAsync<TEntity>(sql, parameters, unitOfWork.Transaction, commandType: commandType);
    }


    public static IEnumerable<int> QueryInt<TEntity>(this IUnitOfWork unitOfWork, string sql, object parameters = null, CommandType commandType = CommandType.Text) where TEntity : class
    {
        DialogueHelper.SetDialogueIfNeeded<TEntity>(unitOfWork.SqlDialect);
        return unitOfWork.Connection.Query<int>(sql, parameters, unitOfWork.Transaction, commandType: commandType);
    }


    public static Task<IEnumerable<int>> QueryIntAsync<TEntity>(this IUnitOfWork unitOfWork, string sql, object parameters = null, CommandType commandType = CommandType.Text) where TEntity : class
    {
        DialogueHelper.SetDialogueIfNeeded<TEntity>(unitOfWork.SqlDialect);
        return unitOfWork.Connection.QueryAsync<int>(sql, parameters, unitOfWork.Transaction, commandType: commandType);
    }


    public static IEnumerable<dynamic> QueryDynamic<TEntity>(this IUnitOfWork unitOfWork, string sql, object parameters = null, CommandType commandType = CommandType.Text) where TEntity : class
    {
        DialogueHelper.SetDialogueIfNeeded<TEntity>(unitOfWork.SqlDialect);
        return unitOfWork.Connection.Query<dynamic>(sql, parameters, unitOfWork.Transaction, commandType: commandType);
    }


    public static Task<IEnumerable<dynamic>> QueryDynamicAsync<TEntity>(this IUnitOfWork unitOfWork, string sql, object parameters = null, CommandType commandType = CommandType.Text) where TEntity : class
    {
        DialogueHelper.SetDialogueIfNeeded<TEntity>(unitOfWork.SqlDialect);
        return unitOfWork.Connection.QueryAsync<dynamic>(sql, parameters, unitOfWork.Transaction, commandType: commandType);
    }
    


    //public static int BulkDelete<TEntity>(this IUnitOfWork unitOfWork,
    //    Action<IConditionalBulkSqlStatementOptionsBuilder<TEntity>> statementOptions = null) where TEntity : class 
    //{
    //    DialogueHelper.SetDialogueIfNeeded<TEntity>(uow.SqlDialect);
    //    return statementOptions != null ? 
    //        uow.Connection.BulkDelete(statementOptions) : 
    //        uow.Connection.BulkDelete<TEntity>(statement=>statement.AttachToTransaction(uow.Transaction));
    //}

    //public static int BulkDelete<TEntity>(this IUnitOfWork unitOfWork, FormattableString whereClause, object parameters) where TEntity : class
    //{
    //    DialogueHelper.SetDialogueIfNeeded<TEntity>(uow.SqlDialect);
    //    return uow.Connection.BulkDelete<TEntity>(statement =>
    //    {
    //        statement.AttachToTransaction(uow.Transaction);
    //        statement.Where(whereClause);
    //        statement.WithParameters(parameters);
    //    });
    //}

    //public static Task<int> BulkDeleteAsync<TEntity>(this IUnitOfWork unitOfWork,
    //    Action<IConditionalBulkSqlStatementOptionsBuilder<TEntity>> statementOptions = null) where TEntity : class
    //{
    //    DialogueHelper.SetDialogueIfNeeded<TEntity>(uow.SqlDialect);
    //    return statementOptions != null ?
    //        uow.Connection.BulkDeleteAsync(statementOptions) :
    //        uow.Connection.BulkDeleteAsync<TEntity>(statement => statement.AttachToTransaction(uow.Transaction));
    //}

    //public static Task<int> BulkDeleteAsync<TEntity>(this IUnitOfWork unitOfWork, FormattableString whereClause, object parameters) where TEntity : class
    //{
    //    DialogueHelper.SetDialogueIfNeeded<TEntity>(uow.SqlDialect);
    //    return uow.Connection.BulkDeleteAsync<TEntity>(statement =>
    //    {
    //        statement.AttachToTransaction(uow.Transaction);
    //        statement.Where(whereClause);
    //        statement.WithParameters(parameters);
    //    });
    //}

    //public static int BulkUpdate<TEntity>(this IUnitOfWork unitOfWork, TEntity updateData,
    //    Action<IConditionalBulkSqlStatementOptionsBuilder<TEntity>> statementOptions = null) where TEntity : class
    //{
    //    DialogueHelper.SetDialogueIfNeeded<TEntity>(uow.SqlDialect);
    //    return statementOptions != null ?
    //        uow.Connection.BulkUpdate(updateData, statementOptions) :
    //        uow.Connection.BulkUpdate(updateData, statement => statement.AttachToTransaction(uow.Transaction));
    //}

    //public static Task<int> BulkUpdateAsync<TEntity>(this IUnitOfWork unitOfWork, TEntity updateData,
    //    Action<IConditionalBulkSqlStatementOptionsBuilder<TEntity>> statementOptions = null) where TEntity : class
    //{
    //    DialogueHelper.SetDialogueIfNeeded<TEntity>(uow.SqlDialect);
    //    return statementOptions != null ?
    //        uow.Connection.BulkUpdateAsync(updateData, statementOptions) :
    //        uow.Connection.BulkUpdateAsync(updateData, statement => statement.AttachToTransaction(uow.Transaction));
    //}

    //public static int Count<TEntity>(this IUnitOfWork unitOfWork,
    //    Action<IConditionalSqlStatementOptionsBuilder<TEntity>> statementOptions = null) where TEntity : class
    //{
    //    DialogueHelper.SetDialogueIfNeeded<TEntity>(uow.SqlDialect);
    //    return statementOptions != null ?
    //        uow.Connection.Count(statementOptions) :
    //        uow.Connection.Count<TEntity>(statement => statement.AttachToTransaction(uow.Transaction));
    //}

    //public static Task<int> CountAsync<TEntity>(this IUnitOfWork unitOfWork,
    //    Action<IConditionalSqlStatementOptionsBuilder<TEntity>> statementOptions = null) where TEntity : class
    //{
    //    DialogueHelper.SetDialogueIfNeeded<TEntity>(uow.SqlDialect);
    //    return statementOptions != null ?
    //        uow.Connection.CountAsync(statementOptions) :
    //        uow.Connection.CountAsync<TEntity>(statement => statement.AttachToTransaction(uow.Transaction));
    //}

    //public static bool Delete<TEntity>(this IUnitOfWork unitOfWork, TEntity entityToDelete,
    //    Action<IStandardSqlStatementOptionsBuilder<TEntity>> statementOptions = null) where TEntity : class
    //{
    //    DialogueHelper.SetDialogueIfNeeded<TEntity>(uow.SqlDialect);
    //    return statementOptions != null ?
    //        uow.Connection.Delete(entityToDelete,statementOptions) :
    //        uow.Connection.Delete(entityToDelete, statement => statement.AttachToTransaction(uow.Transaction));
    //}

    //public static Task<bool> DeleteAsync<TEntity>(this IUnitOfWork unitOfWork, TEntity entityToDelete,
    //    Action<IStandardSqlStatementOptionsBuilder<TEntity>> statementOptions = null) where TEntity : class
    //{
    //    DialogueHelper.SetDialogueIfNeeded<TEntity>(uow.SqlDialect);
    //    return statementOptions != null ?
    //        uow.Connection.DeleteAsync(entityToDelete,statementOptions) :
    //        uow.Connection.DeleteAsync(entityToDelete,statement => statement.AttachToTransaction(uow.Transaction));
    //}

    //public static IEnumerable<TEntity> Find<TEntity>(this IUnitOfWork unitOfWork,
    //    Action<IRangedBatchSelectSqlSqlStatementOptionsOptionsBuilder<TEntity>> statementOptions = null) where TEntity : class
    //{
    //    DialogueHelper.SetDialogueIfNeeded<TEntity>(uow.SqlDialect);
    //    return statementOptions != null ?
    //        uow.Connection.Find(statementOptions) :
    //        uow.Connection.Find<TEntity>(statement => statement.AttachToTransaction(uow.Transaction));
    //}

    //public static Task<IEnumerable<TEntity>> FindAsync<TEntity>(this IUnitOfWork unitOfWork,
    //    Action<IRangedBatchSelectSqlSqlStatementOptionsOptionsBuilder<TEntity>> statementOptions = null) where TEntity : class
    //{
    //    DialogueHelper.SetDialogueIfNeeded<TEntity>(uow.SqlDialect);
    //    return statementOptions != null ?
    //        uow.Connection.FindAsync(statementOptions) :
    //        uow.Connection.FindAsync<TEntity>(statement => statement.AttachToTransaction(uow.Transaction));
    //}

    //public static TEntity Get<TEntity>(this IUnitOfWork unitOfWork, TEntity entityKeys,
    //    Action<ISelectSqlSqlStatementOptionsBuilder<TEntity>> statementOptions = null) where TEntity : class
    //{
    //    DialogueHelper.SetDialogueIfNeeded<TEntity>(uow.SqlDialect);
    //    return statementOptions != null ?
    //        uow.Connection.Get(entityKeys,statementOptions) :
    //        uow.Connection.Get(entityKeys,statement => statement.AttachToTransaction(uow.Transaction));
    //}

    //public static Task<TEntity> GetAsync<TEntity>(this IUnitOfWork unitOfWork, TEntity entityKeys,
    //    Action<ISelectSqlSqlStatementOptionsBuilder<TEntity>> statementOptions = null) where TEntity : class
    //{
    //    DialogueHelper.SetDialogueIfNeeded<TEntity>(uow.SqlDialect);
    //    return statementOptions != null ?
    //        uow.Connection.GetAsync(entityKeys, statementOptions) :
    //        uow.Connection.GetAsync<TEntity>(entityKeys, statement => statement.AttachToTransaction(uow.Transaction));
    //}

    //public static void Insert<TEntity>(this IUnitOfWork unitOfWork, TEntity entityToInsert,
    //    Action<IStandardSqlStatementOptionsBuilder<TEntity>> statementOptions = null) where TEntity : class
    //{
    //    DialogueHelper.SetDialogueIfNeeded<TEntity>(uow.SqlDialect);
    //    if (statementOptions != null)
    //    {
    //        uow.Connection.Insert(entityToInsert, statementOptions);
    //        return;
    //    }
    //    uow.Connection.Insert(entityToInsert, statement => statement.AttachToTransaction(uow.Transaction));
    //}

    //public static Task InsertAsync<TEntity>(this IUnitOfWork unitOfWork, TEntity entityToInsert,
    //    Action<IStandardSqlStatementOptionsBuilder<TEntity>> statementOptions = null) where TEntity : class
    //{
    //    DialogueHelper.SetDialogueIfNeeded<TEntity>(uow.SqlDialect);
    //    return statementOptions != null ? 
    //        uow.Connection.InsertAsync(entityToInsert, statementOptions) : 
    //        uow.Connection.InsertAsync(entityToInsert, statement => statement.AttachToTransaction(uow.Transaction));
    //}

    //public static bool Update<TEntity>(this IUnitOfWork unitOfWork, TEntity entityToUpdate,
    //    Action<IStandardSqlStatementOptionsBuilder<TEntity>> statementOptions = null) where TEntity : class
    //{
    //    DialogueHelper.SetDialogueIfNeeded<TEntity>(uow.SqlDialect);
    //    return statementOptions != null ?
    //        uow.Connection.Update(entityToUpdate, statementOptions) :
    //        uow.Connection.Update(entityToUpdate, statement => statement.AttachToTransaction(uow.Transaction));
    //}

    //public static Task<bool> UpdateAsync<TEntity>(this IUnitOfWork unitOfWork, TEntity entityToUpdate,
    //    Action<IStandardSqlStatementOptionsBuilder<TEntity>> statementOptions = null) where TEntity : class
    //{
    //    DialogueHelper.SetDialogueIfNeeded<TEntity>(uow.SqlDialect);
    //    return statementOptions != null ?
    //        uow.Connection.UpdateAsync(entityToUpdate, statementOptions) :
    //        uow.Connection.UpdateAsync(entityToUpdate, statement => statement.AttachToTransaction(uow.Transaction));
    //}
}
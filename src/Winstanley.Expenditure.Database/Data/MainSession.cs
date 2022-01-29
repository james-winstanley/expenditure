using Microsoft.Data.SqlClient;
using Smooth.IoC.UnitOfWork.Abstractions;
using Smooth.IoC.UnitOfWork.Interfaces;
using Winstanley.Expenditure.Database.Interfaces;

namespace Winstanley.Expenditure.Database.Data;

public interface IMainSession : ISession
{
}

public class MainSession : Session<SqlConnection>, IMainSession
{
    public MainSession(IDbFactory factory, ISqlConnectionConfiguration connectionConfiguration)
        : base(factory, connectionConfiguration.DefaultValue)
    {
    }
}
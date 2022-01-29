using Smooth.IoC.UnitOfWork.Interfaces;
using Winstanley.Expenditure.Database.Interfaces;

namespace Winstanley.Expenditure.Database.Repositories;

public partial class Repository<TEntity, TPk> : Smooth.IoC.Repository.UnitOfWork.Repository<TEntity, TPk>, IRepository<TEntity, TPk>
    where TEntity : class
    where TPk : IComparable
{
    public Repository(IDbFactory factory) : base(factory)
    {
    }
}
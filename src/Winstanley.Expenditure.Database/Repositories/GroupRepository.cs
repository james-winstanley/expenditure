using Smooth.IoC.UnitOfWork.Interfaces;
using Winstanley.Expenditure.Database.Entities;
using Winstanley.Expenditure.Database.Interfaces;

namespace Winstanley.Expenditure.Database.Repositories;

public class GroupRepository : Repository<Group, int>, IGroupRepository
{
    public GroupRepository(IDbFactory factory) : base(factory)
    {
    }
}
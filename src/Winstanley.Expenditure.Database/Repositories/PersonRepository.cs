using Smooth.IoC.UnitOfWork.Interfaces;
using Winstanley.Expenditure.Database.Entities;
using Winstanley.Expenditure.Database.Interfaces;

namespace Winstanley.Expenditure.Database.Repositories;

public class PersonRepository : Repository<Person, int>, IPersonRepository
{
    public PersonRepository(IDbFactory factory) : base(factory)
    {
    }
}
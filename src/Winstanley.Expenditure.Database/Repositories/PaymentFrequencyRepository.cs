using Smooth.IoC.UnitOfWork.Interfaces;
using Winstanley.Expenditure.Database.Entities;
using Winstanley.Expenditure.Database.Interfaces;

namespace Winstanley.Expenditure.Database.Repositories;

public class PaymentFrequencyRepository : Repository<PaymentFrequency, int>, IPaymentFrequencyRepository
{
    public PaymentFrequencyRepository(IDbFactory factory) : base(factory)
    {
    }
}
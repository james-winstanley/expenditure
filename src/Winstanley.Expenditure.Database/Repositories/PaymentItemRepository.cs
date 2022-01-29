using Smooth.IoC.UnitOfWork.Interfaces;
using Winstanley.Expenditure.Database.Entities;
using Winstanley.Expenditure.Database.Interfaces;

namespace Winstanley.Expenditure.Database.Repositories;

public class PaymentItemRepository : Repository<PaymentItem, int>, IPaymentItemRepository
{
    public PaymentItemRepository(IDbFactory factory) : base(factory)
    {
    }
}
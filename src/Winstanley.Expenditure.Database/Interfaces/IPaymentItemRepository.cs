using Winstanley.Expenditure.Database.Entities;

namespace Winstanley.Expenditure.Database.Interfaces;

public interface IPaymentItemRepository : IRepository<PaymentItem, int>
{
}
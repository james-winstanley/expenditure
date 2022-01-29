using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using Smooth.IoC.UnitOfWork.Interfaces;
using Winstanley.Expenditure.Database;
using Winstanley.Expenditure.Database.Data;
using Winstanley.Expenditure.Database.Interfaces;
using Winstanley.Expenditure.Database.Repositories;

namespace Winstanley.Expenditure.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services
            .AddAutoMapper(Assembly.GetExecutingAssembly())
            .AddMediatR(Assembly.GetExecutingAssembly());
            //.AddValidatorsFromAssemblyContaining<OrderDtoValidator>();

        services
            .AddSingleton<IDbFactory, DbFactory>()
            .AddTransient<IMainSession, MainSession>()
            .AddTransient<IPersonRepository, PersonRepository>()
            .AddTransient<IPaymentItemRepository, PaymentItemRepository>()
            .AddTransient<IPaymentFrequencyRepository, PaymentFrequencyRepository>()
            .AddTransient<IGroupRepository, GroupRepository>();

        return services;
    }
}
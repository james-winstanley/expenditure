using Microsoft.Extensions.DependencyInjection;
using Smooth.IoC.UnitOfWork;
using Smooth.IoC.UnitOfWork.Interfaces;

namespace Winstanley.Expenditure.Database
{
    public class DbFactory : IDbFactory
    {
        private readonly IServiceProvider _container;


        public DbFactory(IServiceProvider container)
        {
            _container = container;
        }


        /// <summary>
        /// Creates an instance of your ISession expanded interface
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns>ISession</returns>
        public T Create<T>()
            where T : class, ISession
        {
            return _container.GetService<T>();
        }


        /// <summary>
        /// Creates a UnitOfWork and Session at same time. The session has the same scope as the unit of work.
        /// </summary>
        /// <param name="isolationLevel"></param>
        /// <typeparam name="TUnitOfWork"></typeparam>
        /// <typeparam name="TSession"></typeparam>
        /// <returns></returns>
        public TUnitOfWork Create<TUnitOfWork, TSession>(IsolationLevel isolationLevel = IsolationLevel.Serializable)
            where TUnitOfWork : class, IUnitOfWork
            where TSession : class, ISession
        {
            isolationLevel = IsolationLevel.Unspecified;

            return new UnitOfWork(
                _container.GetService<IDbFactory>(),
                Create<TSession>(),
                isolationLevel,
                true) as TUnitOfWork;
        }


        /// <summary>
        /// Used for Session base to create UnitOfWork. Not recommended to use in code
        /// </summary>
        /// <param name="factory"></param>
        /// <param name="session"></param>
        /// <param name="isolationLevel"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        [Obsolete("Use Create<TUnitOfWork, TSession>(IsolationLevel)")]
        public T Create<T>(IDbFactory factory, ISession session, IsolationLevel isolationLevel = IsolationLevel.Serializable)
            where T : class, IUnitOfWork
        {
            isolationLevel = IsolationLevel.Unspecified;
            return new UnitOfWork(factory, session, isolationLevel) as T;
            //throw new NotImplementedException("Obsolete: Use Create<TUnitOfWork, TSession>(IsolationLevel)");
        }


        /// <summary>
        /// Release the component. Done by Session and UnitOfWork on there own.
        /// </summary>
        /// <param name="instance"></param>
        public void Release(IDisposable instance)
        {
            instance?.Dispose();
        }
    }
}

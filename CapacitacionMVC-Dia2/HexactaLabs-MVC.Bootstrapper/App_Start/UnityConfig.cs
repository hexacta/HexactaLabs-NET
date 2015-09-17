using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.Configuration;
using HexactaLabs_MVC.Persistence.Common;
using HexactaLabs_MVC.Services.Movies;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using HexactaLabs_MVC.Business.Common;
using HexactaLabs_MVC.Business.Movies;
using HexactaLabs_MVC.Business.Genres;
using HexactaLabs_MVC.Services.Common.Mapper;

namespace HexactaLabs_MVC.Bootstrapper.App_Start
{
    /// <summary>
    /// Specifies the Unity configuration for the main container.
    /// </summary>
    public class UnityConfig
    {
        #region Unity Container
        private static Lazy<IUnityContainer> container = new Lazy<IUnityContainer>(() =>
        {
            var container = new UnityContainer();
            RegisterTypes(container);
            return container;
        });

        /// <summary>
        /// Gets the configured Unity container.
        /// </summary>
        public static IUnityContainer GetConfiguredContainer()
        {
            return container.Value;
        }
        #endregion

        /// <summary>Registers the type mappings with the Unity container.</summary>
        /// <param name="container">The unity container to configure.</param>
        /// <remarks>There is no need to register concrete types such as controllers or API controllers (unless you want to 
        /// change the defaults), as Unity allows resolving a concrete type even if it was not previously registered.</remarks>
        public static void RegisterTypes(IUnityContainer container)
        {
            RegisterServices(container);
            RegisterBusiness(container);
            RegisterRepositories(container);
        }

        private static void RegisterServices(IUnityContainer container)
        {
            container.RegisterType<DtoMapper>();

            IEnumerable<Type> excluded = new Collection<Type>();

            RegisterAutomaticalyAllServices(container, excluded);
            RegisterManuallyServices(container);
        }

        private static void RegisterManuallyServices(IUnityContainer container)
        {
        }

        private static void RegisterAutomaticalyAllServices(IUnityContainer container, IEnumerable<Type> excluded)
        {
            var serviceTypes =
                typeof(MovieService).Assembly.GetTypes()
                    .Where(t => t.IsClass && !t.IsGenericType && t.Name.EndsWith("Service"))
                    .Except(excluded);

            serviceTypes.ForEach(
                serviceType =>
                    serviceType.GetInterfaces().ForEach(
                        serviceInterface =>
                            container.RegisterType(
                                serviceInterface,
                                serviceType,
                                new PerRequestLifetimeManager())));
        }

        private static void RegisterBusiness(IUnityContainer container)
        {
        }

        private static void RegisterRepositories(IUnityContainer container)
        {
            container.RegisterType<MoviesContext>(new PerRequestLifetimeManager());
            container.RegisterType<IRepository<Movie>, Repository<Movie>>(new PerRequestLifetimeManager());
            container.RegisterType<IRepository<Genre>, Repository<Genre>>(new PerRequestLifetimeManager());
        }
    }

    public static class EnumerableExtension
    {
        public static void ForEach<T>(this IEnumerable<T> enumeration, Action<T> action)
        {
            foreach (T item in enumeration)
            {
                action(item);
            }
        }
    }
}

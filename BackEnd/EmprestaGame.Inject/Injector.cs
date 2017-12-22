using EmprestaGame.Business;
using EmprestaGame.Business.Contracts;
using EmprestaGame.Data.Context;
using EmprestaGame.Data.Repositories;
using EmprestaGame.Data.Repositories.Contracts;
using SimpleInjector;
using SimpleInjector.Integration.WebApi;
using System.Data.Entity;
using System.Linq;

namespace EmprestaGame.Inject
{
    public class Injector
    {
        private static Container _container;

        public static void SimpleInjectorDependencyResolver(Container container)
        {
            //Injetar DBContext manualmente.
            container.Register(typeof(DbContext), typeof(EmprestaGameContext), new WebApiRequestLifestyle());

            //Business e repository padrão.
            container.Register(typeof(IBusinessBase<>), typeof(BusinessBase<>), new WebApiRequestLifestyle());
            container.Register(typeof(IRepositoryBase<>), typeof(RepositoryBase<>), new WebApiRequestLifestyle());

            container.Register(typeof(IJogoBusiness), typeof(JogoBusiness), new WebApiRequestLifestyle());
            container.Register(typeof(IJogoRepository), typeof(JogoRepository), new WebApiRequestLifestyle());

            _container = container;

            //var businessAssembly = typeof(JogoBusiness).Assembly;

            //var tiposParaRegistrar =
            //    from type in businessAssembly.GetExportedTypes()
            //    where type.Namespace == "EmprestaGame.Business"
            //    where type.GetInterfaces().Any()
            //    select new
            //    {
            //        TipoConcreto = type,
            //        InterfaceBase = type.GetInterfaces()
            //            .Where(x => x.GetInterfaces() != null
            //                && x.GetInterfaces()
            //                    .Where(y => y.Name.Contains("IBusinessBase")).Count() > 0)
            //            .Single()
            //    };

            //foreach (var reg in tiposParaRegistrar)
            //{
            //    container.Register(reg.InterfaceBase, reg.TipoConcreto, new WebApiRequestLifestyle());
            //}

        }

        public static T GetObjeto<T>() where T : class
        {
            return _container.GetInstance<T>();
        }

    }
}

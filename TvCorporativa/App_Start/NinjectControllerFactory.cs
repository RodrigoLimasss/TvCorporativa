using System;
using System.Web.Mvc;
using System.Web.Routing;
using Ninject;
using TvCorporativa.DAO;

namespace TvCorporativa
{
    public class NinjectControllerFactory : DefaultControllerFactory
    {
        public static IKernel Kernel;

        public NinjectControllerFactory(IKernel kernel)
        {
            Kernel = kernel;
            AddBindings();
        }

        private void AddBindings()
        {
            Kernel.Bind<EmpresaDao>().ToSelf();
            Kernel.Bind<FeedDao>().ToSelf();
            Kernel.Bind<MidiaDao>().ToSelf();
            Kernel.Bind<PlayListDao>().ToSelf();
            Kernel.Bind<PontoDao>().ToSelf();
            Kernel.Bind<TemplateDao>().ToSelf();
            Kernel.Bind<UsuarioDao>().ToSelf();
        }

        protected override IController GetControllerInstance(RequestContext requestContext, Type controllerType)
        {
            return controllerType == null ? null : (IController)Kernel.Get(controllerType);
        }
    }
    
}
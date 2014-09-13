using System;
using System.Web.Mvc;
using System.Web.Routing;
using Ninject;
using TvCorporativa.DAO;

namespace TvCorporativa
{
    public class NinjectControllerFactory : DefaultControllerFactory
    {
        private readonly IKernel _kernel;

        public NinjectControllerFactory(IKernel kernel)
        {
            _kernel = kernel;
            AddBindings();
        }

        private void AddBindings()
        {
            _kernel.Bind<EmpresaDao>().ToSelf();
            _kernel.Bind<FeedDao>().ToSelf();
            _kernel.Bind<MidiaDao>().ToSelf();
            _kernel.Bind<PlayListDao>().ToSelf();
            _kernel.Bind<PontoDao>().ToSelf();
            _kernel.Bind<TemplateDao>().ToSelf();
            _kernel.Bind<UsuarioDao>().ToSelf();
        }

        protected override IController GetControllerInstance(RequestContext requestContext, Type controllerType)
        {
            return controllerType == null ? null : (IController)_kernel.Get(controllerType);
        }
    }
    
}
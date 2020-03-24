using Arctodus.Business;
using Arctodus.Business.Interface;
using System.Web.Mvc;
using Unity;
using Unity.Injection;
using Unity.Mvc5;

namespace Arctodus
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();
            container.RegisterType<UsuarioBusiness>(new InjectionConstructor(0));
            container.RegisterType<IUsuarioBusiness, UsuarioBusiness>();

            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}
using LibraryMvcApp.Controllers;
using LibraryMvcApp.Services;
using System.Web.Mvc;
using Unity;
using Unity.Injection;
using Unity.Mvc5;

namespace LibraryMvcApp
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
            var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();

            container.RegisterType<IMultimediaServices, MultimediaServices>();
            container.RegisterType<IController, MultimediaController>("Multimedia");

            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }

        //private static IUnityContainer BuildUnityContainer()
        //{
        //    var container = new UnityContainer();

        //    // register all your components with the container here
        //    // it is NOT necessary to register your controllers

        //    // e.g. container.RegisterType<ITestService, TestService>();

        //    container.RegisterType<IMultimediaServices, MultimediaServices>();
        //    container.RegisterType<IController, MultimediaController>("Multimedia");

        //    return container;
        //}
    }
}
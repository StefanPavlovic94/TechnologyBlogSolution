[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(TechnologyBlogSolution.App_Start.NinjectWebCommon), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethodAttribute(typeof(TechnologyBlogSolution.App_Start.NinjectWebCommon), "Stop")]

namespace TechnologyBlogSolution.App_Start
{
    using System;
    using System.Web;

    using Microsoft.Web.Infrastructure.DynamicModuleHelper;

    using Ninject;
    using Ninject.Web.Common;
    using Ninject.Web.Common.WebHost;
    using TechnologyBlogSolution.Models.BlogModels;
    using TechnologyBlogSolution.Repository.Contracts;
    using TechnologyBlogSolution.Repository.Implementations;
    using TechnologyBlogSolution.Services.Contracts;
    using TechnologyBlogSolution.Services.Implementations;

    public static class NinjectWebCommon 
    {
        private static readonly Bootstrapper bootstrapper = new Bootstrapper();

        /// <summary>
        /// Starts the application
        /// </summary>
        public static void Start() 
        {
            DynamicModuleUtility.RegisterModule(typeof(OnePerRequestHttpModule));
            DynamicModuleUtility.RegisterModule(typeof(NinjectHttpModule));
            bootstrapper.Initialize(CreateKernel);
        }
        
        /// <summary>
        /// Stops the application.
        /// </summary>
        public static void Stop()
        {
            bootstrapper.ShutDown();
        }
        
        /// <summary>
        /// Creates the kernel that will manage your application.
        /// </summary>
        /// <returns>The created kernel.</returns>
        private static IKernel CreateKernel()
        {
            var kernel = new StandardKernel();
            try
            {
                kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);
                kernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();
                kernel.Bind<TechnologyBlogDbContext>().ToSelf();
                kernel.Bind<ISubjectService>().To<SubjectService>();
                kernel.Bind<IPostService>().To<PostService>();
                kernel.Bind<ISubjectRepository>().To<SubjectRepository>();
                kernel.Bind<IPostRepository>().To<PostRepository>();
                kernel.Bind(typeof(IRepository<Subject>)).To(typeof(Repository<Subject>));

                RegisterServices(kernel);
                return kernel;
            }
            catch
            {
                kernel.Dispose();
                throw;
            }
        }

        /// <summary>
        /// Load your modules or register your services here!
        /// </summary>
        /// <param name="kernel">The kernel.</param>
        private static void RegisterServices(IKernel kernel)
        {
        }        
    }
}
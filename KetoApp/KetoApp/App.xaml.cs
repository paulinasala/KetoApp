using Autofac;
using KetoApp.Resource;
using KetoApp.Services;
using KetoApp.Views;
using System;
using System.Linq;
using Xamarin.Forms;

namespace KetoApp
{
    public partial class App : Application
    {
        public static IServiceLocator ServiceLocator { get; private set; }
        public static MasterDetailPage MasterPage;

        public App()
        {
            InitializeComponent();
            MasterPage = new MasterDetailPage
            {
                Detail = new NavigationPage(new MainPage()),
                Master = new MainPage(),
                MasterBehavior = MasterBehavior.Popover,
            };
            
            MainPage = MasterPage;
            
            
            InitializeIoC();
            InitializeResources();
            // TODO: handle initial navigation
            
            var navi = ServiceLocator.Get<INavigationService>();
            
            navi.PushPage(ApplicationPage.HomePage);
        }

        private void InitializeResources()
        {
            var resources = ServiceLocator.GetAll<IResource>();
            foreach(var resource in resources)
            {
                Resources.Add(resource.GetResources());
            } 
        }

        private void InitializeIoC()
        {
            var assembliesToImport = AppDomain.CurrentDomain.GetAssemblies()
               .Where(assemblies => assemblies.GetName().Name.Contains("KetoApp")
                                 || assemblies.GetName().Name.Contains("Android")).ToArray();

            ServiceLocator = new ServiceLocator(builder =>
            {
                builder.RegisterInstance(MasterPage.Detail.Navigation)
                    .As<INavigation>()
                    .SingleInstance();

                builder.Register(e => ServiceLocator)
                    .As<IServiceLocator>()
                    .SingleInstance();

                builder.RegisterType<PageLocator>()
                   .As<IPageLocator>()
                   .SingleInstance();

                //register all resources
                builder.RegisterType<Colors>().As<IResource>().SingleInstance();

                builder.RegisterAssemblyTypes(assembliesToImport)
                    .Where(t => t.Name.EndsWith("Service"))
                    .AsImplementedInterfaces()
                    .SingleInstance();

                builder.RegisterAssemblyTypes(assembliesToImport)
                    .Where(t => t.Name.EndsWith("ViewModel"));

                builder.RegisterAssemblyTypes(assembliesToImport)
                   .Where(t => t.Name.EndsWith("Page"));

            });
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}

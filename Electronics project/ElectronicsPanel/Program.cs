using Autofac;
using Electronics.Infracstructure.ProductsRepo;
using Electronics.Logic.InterfaceServicesFolder;
using Electronics.Logic.ProductsServicesFolder;

namespace ElectronicsPanel
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        private static IContainer container;
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();

            var containerBuilder = new ContainerBuilder();

            containerBuilder.RegisterType<ComputerRepo>().As<IComputer>();
            containerBuilder.RegisterType<ComputerServices>();
            containerBuilder.RegisterType<PhoneRepo>().As<IPhone>();
            containerBuilder.RegisterType<PhoneServices>();

/*            containerBuilder.RegisterType<PhonesPanel>();
            containerBuilder.RegisterType<ComputersPanel>();*/
            containerBuilder.RegisterType<Login>();

            container = containerBuilder.Build();

/*            var computerForm = container.Resolve<ComputersPanel>();
            var phoneForm = container.Resolve<PhonesPanel>();*/
            var loginForm = container.Resolve<Login>();

            Application.Run(loginForm);
/*            Application.Run(computerForm);
            Application.Run(phoneForm);*/
        }
    }
}
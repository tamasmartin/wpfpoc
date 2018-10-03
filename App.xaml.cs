using System;
using System.Windows;
using DataProvider.Services;
using DryIoc;
using Serilog;
using Serilog.Core;
using WpfApplicationPoc.Views;
using WpfApplicationPoc.Windows;
using WpfApplicationPoc.Windows.ProductDetailsWindow;

namespace WpfApplicationPoc
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App
    {
        public static Container Container;
        protected Logger logger;
        
        private void App_OnStartup(object sender, StartupEventArgs e)
        {
            try
            {
                SetupLogger();
                SetupContainer();
                var mainWindow = Container.Resolve<MainWindow>();
                mainWindow.Show();

                var service = new ServiceReference1.ProductProviderClient();
                var p = service.GetProduct(3);
                logger.Information(p.ProductName);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
            }
        }

        private void SetupLogger()
        {
            logger = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .WriteTo.ColoredConsole()
                .CreateLogger();
            Log.Logger = logger;
            logger.Information("Application Started");
            logger.Debug("Debug information");
            logger.Error("This is an error log");
        }

        private static void SetupContainer()
        {
            Container = new Container();
            Container.AddServiceLayer();
            Container.Register<MainWindow>();
            Container.Register<MainWindowViewModel>();
            Container.Register<SaveProductDetailsCommand>();
            Container.Register<ProductDetailsViewModel>();
            Container.Register<ProductDetails>();
            


        }
    }
}
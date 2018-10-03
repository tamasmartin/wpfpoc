using System.Windows;
using Serilog;
using Serilog.Core;

namespace WpfApplicationPoc.Windows.Abstract
{
    public abstract class WindowBase : Window
    {
        protected readonly Logger Logger;
        protected abstract string GetWindowTitle();

        protected WindowBase()
        {
            Logger = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .WriteTo.ColoredConsole()
                .CreateLogger();
            Logger.Information("Application Started");
            Logger.Debug("Debug information");
            Logger.Error("This is an error log");
        }
    }
}
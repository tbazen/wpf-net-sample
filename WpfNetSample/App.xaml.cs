using Microsoft.Extensions.DependencyInjection;
using System.Windows;


namespace WpfNetSample
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private async void Application_Startup(object sender, StartupEventArgs e)
        {
            await ServiceHost.Instance.StartAsync();
            var mainWindow = ServiceHost.Instance.Services.GetService<MainWindow>();
            mainWindow.Show();
        }

        private async void Application_Exit(object sender, ExitEventArgs e)
        {
            using (ServiceHost.Instance)
                await ServiceHost.Instance.StopAsync();
        }
    }
}

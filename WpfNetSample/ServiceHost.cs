using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;

namespace WpfNetSample
{

    public interface IPersonService
    {
        Person GetPerson();
    }
    public class PersonService : IPersonService
    {
        public Person GetPerson() => new Person { Name = "Walker", Age = 23 };
    }


    public sealed class ServiceHost
    {
        private static readonly Lazy<IHost> _lazy = new Lazy<IHost>(() => CreatHost());
        public static IHost Instance
        {
            get { return _lazy.Value; }
        }
        private static IHost CreatHost()
        {
            return new HostBuilder()
                    .ConfigureAppConfiguration((context, configBuilder) =>
                    {
                        configBuilder.SetBasePath(context.HostingEnvironment.ContentRootPath);
                        configBuilder.AddJsonFile("appsettings.json", false);
                    })
                    .ConfigureServices((context, services) =>
                    {
                        services.AddTransient<IPersonService, PersonService>();
                        services.AddSingleton<MainWindow>();
                    })
                    .Build();
        }
    }
}

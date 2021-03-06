using System;
using System.Windows;
using Avans.FlatGalaxy.Persistence.Factories;
using Avans.FlatGalaxy.Persistence.Factories.Common;
using Avans.FlatGalaxy.Persistence.Loaders;
using Avans.FlatGalaxy.Persistence.Parsers;
using Avans.FlatGalaxy.Presentation.Commands;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Avans.FlatGalaxy.Presentation
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private readonly IHost _host;

        public App()
        {
            _host = Host.CreateDefaultBuilder()
                .ConfigureServices((context, services) => {
                    ConfigureServices(context.Configuration, services);
                })
                .Build();
        }

        private void ConfigureServices(IConfiguration configuration, IServiceCollection services)
        {
            services.AddSingleton<MainWindow>();
            services.AddSingleton<SimulationWindow>();
            services.AddSingleton<ShortcutWindow>();
            services.AddSingleton<ShortcutList>();

            services.AddTransient<ICelestialBodyFactory, CelestialBodyFactory>();
            services.AddTransient<IFileLoader, FileLoader>();
            services.AddTransient<ConfigurationParserBase, ConfigurationParser>();
        }

        protected override async void OnStartup(StartupEventArgs e)
        {
            await _host.StartAsync();

            var mainWindow = _host.Services.GetRequiredService<MainWindow>();
            mainWindow.Show();

            base.OnStartup(e);
        }

        protected override async void OnExit(ExitEventArgs e)
        {
            using (_host)
            {
                await _host.StopAsync(TimeSpan.FromSeconds(5));
            }

            base.OnExit(e);
        }
    }
}

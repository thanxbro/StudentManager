using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using StudentManager.View;
using System.Windows;

namespace StudentManager
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private IHost _host;

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            //Добавляем сервисы в контейнер
            HostApplicationBuilder builder = Host.CreateApplicationBuilder();
            builder.Services.AddSingleton<MainWindow>();

            _host = builder.Build();

            MainWindow = _host.Services.GetRequiredService<MainWindow>();
            MainWindow.Show();

            _host.StartAsync();


        }
        protected override void OnExit(ExitEventArgs e)
        {
            base.OnExit(e);
            _host.Dispose();
        }
    }

}

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using StudentManager.DataBase;
using StudentManager.View;
using System;
using System.Windows;

namespace StudentManager
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private IHost _host;

        public App()
        {
            //Добавляем сервисы в контейнер
            HostApplicationBuilder builder = Host.CreateApplicationBuilder();
            builder.Services.AddSingleton<MainWindow>();
            builder.Services.AddDbContext<DataBaseContext>();

            _host = builder.Build();


            _host.StartAsync();

        }
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            MainWindow = _host.Services.GetRequiredService<MainWindow>();
            MainWindow.Show();

        }
        protected override void OnExit(ExitEventArgs e)
        {
            base.OnExit(e);
            _host.Dispose();
        }
    }

}

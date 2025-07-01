using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using StudentManager.DataBase;
using StudentManager.DataBase.Data;
using StudentManager.Services;
using StudentManager.View;
using StudentManager.ViewModel;
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

            builder.Services.AddSingleton<IRepository<Student>, StudentRepositoryService>();
            builder.Services.AddSingleton<IRepository<Departament>, DepartamentRepositoryService>();
            builder.Services.AddSingleton<IRepository<Teacher>, TeacherRepositorySrvice>();

            builder.Services.AddSingleton<MainWindowViewModel>();

            builder.Services.AddSingleton<MainWindow>();
            builder.Services.AddDbContext<DataBaseContext>();

            builder.Services.AddTransient<StudentWindow>();

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
            _host.StopAsync();
            _host.Dispose();
        }
    }

}

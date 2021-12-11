using BuscadorArquivosDuplicados.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace BuscadorArquivosDuplicados
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private ServiceProvider serviceProvider;

        public App()
        {
            InitializeComponent();
            ServiceCollection services = new ServiceCollection();
            ConfigureServices(services);
            serviceProvider = services.BuildServiceProvider();
        }

        private void ConfigureServices(ServiceCollection services)
        {
            services.AddDbContext<ArquivosDBContext>(options =>
            {
                string arq = GetDatabaseFile(this.mainWindow);
                options.UseSqlite($"Data Source = '{arq}'");
            });
            services.AddSingleton<MainWindow>();
        }

        public static string GetDatabaseFile(MainWindow _mainWindow = null)
        {
            SaveFileDialog fd = new SaveFileDialog();
            fd.DefaultExt = ".db";
            fd.Filter = "Buscador Arquivos Databases (*.db)|*.db";
            fd.Title = "Escolha o arquivo de análise";
            fd.OverwritePrompt = false;
            fd.InitialDirectory = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
            if (fd.ShowDialog(_mainWindow) ??false)
            {
                return fd.FileName;
            }
            else
                return "./arquivos.db";
        }

        MainWindow mainWindow;
        private void OnStartup(object sender, StartupEventArgs e)
        {
            mainWindow = serviceProvider.GetService<MainWindow>();
            mainWindow.Show();
        }
    }

}

using BuscadorArquivosDuplicados.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace BuscadorArquivosDuplicados
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ArquivosDBContext dbArquivos;
        public MainWindow(ArquivosDBContext db)
        {
            this.dbArquivos = db;
            InitializeComponent();
            GetArquivos();
        }

        private void GetArquivos()
        {
            List<ArquivosUnico> arquivos = dbArquivos.ArquivosUnico.ToList<ArquivosUnico>();
            ArquivosGrid.ItemsSource = arquivos;
        }

        private void TrocarDB_Click(object sender, RoutedEventArgs e)
        {
            var optionsBuilder = new DbContextOptionsBuilder<ArquivosDBContext>();
            string arq = App.GetDatabaseFile(this);
            optionsBuilder.UseSqlite(@$"DataSource={arq}");
            dbArquivos = new ArquivosDBContext(optionsBuilder.Options);
            GetArquivos();
        }

        private void SalvarDB_Click(object sender, RoutedEventArgs e)
        {
            dbArquivos.SaveChangesAsync().GetAwaiter().GetResult(); 
        }

        private void ArquivosGrid_AddingNewItem(object sender, AddingNewItemEventArgs e)
        {
            ArquivosUnico a = new ArquivosUnico();
            dbArquivos.ArquivosUnico.Add(a);
            e.NewItem = a;
        }
    }
}

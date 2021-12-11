using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace BuscadorArquivosDuplicados.Models
{
    public class ArquivosDBContext: DbContext
    {
        public DbSet<ArquivosUnico> ArquivosUnico { get; set; }
        public ArquivosDBContext(DbContextOptions<ArquivosDBContext> options): base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ArquivosUnico>().HasData(GetArquivos());
            base.OnModelCreating(modelBuilder);
        }

        private List<ArquivosUnico> GetArquivos()
        {
            return new List<ArquivosUnico>()
            {
                 new ArquivosUnico { ArquivosUnicoId=1, Hash = "AAA", NomePrimeiraOcorrencia = "AAA.TXT", CriadoEm = DateTime.Now, Tamanho = 132165421321 }
                ,new ArquivosUnico { ArquivosUnicoId=2, Hash = "AAB", NomePrimeiraOcorrencia = "AAB.TXT", CriadoEm = DateTime.Now, Tamanho = 332165421321 }
            };
        }
       
    }
}

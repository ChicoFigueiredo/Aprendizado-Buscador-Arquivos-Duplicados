using Microsoft.EntityFrameworkCore;

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuscadorArquivosDuplicados.Models
{
    [Index(nameof(ArquivosUnico.Hash), IsUnique = true)]
    public class ArquivosUnico
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long ArquivosUnicoId { get; set; }

        [Required]
        [StringLength(512)]
        public string Hash { get; set; }

        public string NomePrimeiraOcorrencia { get; set; }

        [DefaultValue("DATE('now')")]
        public DateTime CriadoEm { get; set; }

        [Required]
        public long Tamanho { get; set; }


        public ICollection<ArquivosUnicoOcorrencia>? Ocorrencias { get; set; }
    }
}

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
    [Index(nameof(ArquivosUnicoOcorrencia.ArquivosUnicoId), IsUnique = false)]
    public class ArquivosUnicoOcorrencia
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long ArquivosUnicoOcorrenciaId { get; set; }

        [Required]
        [ForeignKey("ArquivosUnicoId")]
        public long ArquivosUnicoId { get; set; }

        [Required]
        public string NomeArquivo { get; set; }

        [Required]
        public string CaminhoCompleto { get; set; }

        public bool Deletar { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        [DefaultValue("DATE('now')")]
        public DateTime CriadoEm { get; set; }
    }
}

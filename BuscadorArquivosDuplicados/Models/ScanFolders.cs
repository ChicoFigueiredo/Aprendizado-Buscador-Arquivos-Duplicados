using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuscadorArquivosDuplicados.Models
{
    [Index(nameof(ScanFolders.Pasta), IsUnique = false)]
    public class ScanFolders
    {
        [Key]
        public int ScanFolderId { get; set; }

        [Required]
        [StringLength(1000)]
        public string Pasta { get; set; }
    }
}

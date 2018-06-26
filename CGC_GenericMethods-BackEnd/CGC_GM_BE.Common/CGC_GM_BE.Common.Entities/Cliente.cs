using CGC_GM_BE.Common.Entities.Notations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CGC_GM_BE.Common.Entities
{
    [Table("neg.Cliente")]
    public class Cliente
    {
        [Key]
        public int Id { get; set; }
        [Column]
        public string Nombre { get; set; }
        [Column]
        public DateTime FechaRegistro { get; set; }
        [Column]
        public bool EsActivo { get; set; }
    }
}

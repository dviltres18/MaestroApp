using Abp.Domain.Entities.Auditing;
using MaestroApp.Maestro.Container;
using MaestroApp.Maestro.Travel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MaestroApp.Maestro.State
{
    [Table("MaestroEstado")]
    public class Estado
    {
        [Key]
        public virtual int EstadoId { get; set; }

        [Required]
        [MaxLength(100)]
        public virtual string Nombre { get; set; }      

    }
}

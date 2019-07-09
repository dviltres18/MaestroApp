using Abp.Domain.Entities.Auditing;
using MaestroApp.Maestro.Container;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MaestroApp.Maestro.Travel
{
    [Table("MaestroViaje")]
    public class Viaje : FullAuditedEntity
    {
        [Required]
        [MaxLength(100)]
        public virtual string Destino { get; set; }

        [ForeignKey("ContenedorId")]
        public virtual Contenedor Contenedor { get; set; }

        public virtual int ContenedorId { get; set; }
    }
}

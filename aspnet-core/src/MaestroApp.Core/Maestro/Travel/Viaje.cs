using Abp.Domain.Entities.Auditing;
using MaestroApp.Maestro.Container;
using MaestroApp.Maestro.State;
using MaestroApp.Maestro.TravelContainer;
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

        [Required]
        [MaxLength(100)]
        public virtual string Responsable { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd hh:mm tt}", ApplyFormatInEditMode = true)]
        public virtual DateTime FechaInicio { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd hh:mm tt}", ApplyFormatInEditMode = true)]
        public virtual DateTime FechaFin { get; set; }

        [ForeignKey("EstadoId")]
        public virtual Estado Estado { get; set; }

        public virtual int EstadoId { get; set; }

        public virtual ICollection<ViajeContenedor> ViajeContenedor { get; set; }
    }
}

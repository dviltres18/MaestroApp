using Abp.Domain.Entities.Auditing;
using MaestroApp.Maestro.Container;
using MaestroApp.Maestro.Travel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MaestroApp.Maestro.TravelContainer
{
    [Table("MaestroViajeContenedor")]
    public class ViajeContenedor : FullAuditedEntity
    {
        [ForeignKey("ViajeId")]
        public virtual Viaje Viaje { get; set; }
        public virtual int ViajeId { get; set; }

        [ForeignKey("ContenedorId")]
        public virtual Contenedor Contenedor { get; set; }
        public virtual int ContenedorId { get; set; }
    }
}

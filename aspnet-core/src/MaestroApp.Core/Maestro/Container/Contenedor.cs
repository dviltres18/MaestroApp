﻿using Abp.Domain.Entities.Auditing;
using MaestroApp.Maestro.State;
using MaestroApp.Maestro.Travel;
using MaestroApp.Maestro.TravelContainer;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MaestroApp.Maestro.Container
{
    [Table("MaestroContenedor")]
    public class Contenedor : FullAuditedEntity
    {
        [Required]
        [MaxLength(100)]
        public virtual string Nombre { get; set; }

        public virtual int CantidadViajes { get; set; }

        [ForeignKey("EstadoId")]
        public virtual Estado Estado { get; set; }

        public virtual int EstadoId { get; set; }

        public virtual ICollection<ViajeContenedor> ViajeContenedor { get; set; }

    }
}

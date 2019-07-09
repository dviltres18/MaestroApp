using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MaestroApp.Maestro.State
{
    [Table("MaestroEstado")]
    public class Estado : FullAuditedEntity
    {
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

        
    }
}

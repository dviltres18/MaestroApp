using MaestroApp.Maestro.State;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MaestroApp.Maestro.Travel.Dto
{
    public class CrearViajeInput
    {
        [Required]
        [MaxLength(100)]
        public string Origen { get; set; }

        [Required]
        [MaxLength(100)]
        public string Destino { get; set; }

        [Required]
        [MaxLength(100)]
        public string Responsable { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd hh:mm tt}", ApplyFormatInEditMode = true)]
        public DateTime FechaInicio { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd hh:mm tt}", ApplyFormatInEditMode = true)]
        public DateTime FechaFin { get; set; }

        [Required]
        public int EstadoId { get; set; }
    }
}

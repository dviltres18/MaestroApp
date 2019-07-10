using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MaestroApp.Maestro.Container.Dto
{
    public class CrearContenedorInput
    {
        [Required]
        [MaxLength(100)]
        public string Nombre { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd hh:mm tt}", ApplyFormatInEditMode = true)]
        public  DateTime FechaCreacion { get; set; }

        public  int CantidadViajes { get; set; }

        [Required]
        public int EstadoId { get; set; }


    }
}

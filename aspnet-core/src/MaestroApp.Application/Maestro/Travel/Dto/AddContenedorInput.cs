using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MaestroApp.Maestro.Travel.Dto
{
    public class AddContenedorInput
    {
        [Required]
        public int ViajeId { get; set; }

        [Required]
        public int ContenedorId { get; set; }
    }
}

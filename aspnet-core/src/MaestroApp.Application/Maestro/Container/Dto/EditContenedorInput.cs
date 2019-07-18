using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MaestroApp.Maestro.Container.Dto
{
    public class EditContenedorInput
    {
        public int Id { get; set; }

        [Required]
        public string Nombre { get; set; }

        
        public int CantidadViajes { get; set; }

        [Required]
        public int EstadoId { get; set; }
    }
}

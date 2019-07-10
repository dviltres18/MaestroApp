using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MaestroApp.Maestro.State.Dto
{
    public class EditEstadoInput
    {
        public int Id { get; set; }

        [MaxLength(100)]
        [Required]
        public string Nombre { get; set; }
       
    }
}

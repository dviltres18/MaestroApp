using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MaestroApp.Maestro.Container.Dto
{
    public class GetContenedorForEditOutput
    {
        public int Id { get; set; }

        public string Nombre { get; set; }
        
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd hh:mm tt}", ApplyFormatInEditMode = true)]
        public DateTime FechaCreacion { get; set; }

        public int CantidadViajes { get; set; }
    }
}

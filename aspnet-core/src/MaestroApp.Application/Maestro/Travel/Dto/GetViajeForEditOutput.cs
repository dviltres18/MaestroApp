using MaestroApp.Maestro.State;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MaestroApp.Maestro.Travel.Dto
{
    public class GetViajeForEditOutput
    {
        public int Id { get; set; }

        public string Destino { get; set; }
        
        public string Responsable { get; set; }
        
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd hh:mm tt}", ApplyFormatInEditMode = true)]
        public DateTime FechaInicio { get; set; }

        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd hh:mm tt}", ApplyFormatInEditMode = true)]
        public DateTime FechaFin { get; set; }

        public int EstadoId { get; set; }

        public string Estado { get; set; }
    }
}

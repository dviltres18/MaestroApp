using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MaestroApp.Maestro.Container.Dto
{
    public class ViajeInContenedorListDto
    {
        public int Id { get; set; }

        public int EstadoId { get; set; }

        public EstadoViajeListDto Estado { get; set; }

        public string Origen { get; set; }

        public string Destino { get; set; }

        public string Responsable { get; set; }

        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd hh:mm tt}", ApplyFormatInEditMode = true)]
        public DateTime FechaInicio { get; set; }

        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd hh:mm tt}", ApplyFormatInEditMode = true)]
        public DateTime FechaFin { get; set; }
    }
}

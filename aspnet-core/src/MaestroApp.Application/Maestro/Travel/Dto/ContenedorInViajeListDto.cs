using System;
using System.Collections.Generic;
using System.Text;

namespace MaestroApp.Maestro.Travel.Dto
{
    public class ContenedorInViajeListDto
    {
        public int ViajeId { get; set; }

        public int ContenedorId { get; set; }

        public string Nombre { get; set; }

        public int EstadoId { get; set; }

        public int CantidadViajes { get; set; }
    }
}

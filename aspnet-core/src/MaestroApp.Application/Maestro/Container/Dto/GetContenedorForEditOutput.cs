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

        public int CantidadViajes { get; set; }
        
        public int EstadoId { get; set; }

        public EstadoInContenedorListDto Estado { get; set; }
    }
}

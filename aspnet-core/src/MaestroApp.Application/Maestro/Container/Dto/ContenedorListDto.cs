using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MaestroApp.Maestro.Container.Dto
{
    public class ContenedorListDto : FullAuditedEntityDto
    {
        
        public string Nombre { get; set; }
       
        public  int CantidadViajes { get; set; }

        public int EstadoId { get; set; }

        public EstadoInContenedorListDto Estado { get; set; }

    }
}

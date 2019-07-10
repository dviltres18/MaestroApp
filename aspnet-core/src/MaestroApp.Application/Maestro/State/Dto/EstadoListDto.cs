using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace MaestroApp.Maestro.State.Dto
{
    public class EstadoListDto : FullAuditedEntityDto
    {
       
        public string Nombre { get; set; }
        
    }
}

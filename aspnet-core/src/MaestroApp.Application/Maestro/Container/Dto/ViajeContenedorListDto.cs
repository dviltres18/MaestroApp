using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MaestroApp.Maestro.Container.Dto
{
    public class ViajeContenedorListDto
    {
        public int ViajeId { get; set; }

        public int ContenedorId { get; set; }       

        public ViajeInContenedorListDto Viaje { get; set; }
    }
}

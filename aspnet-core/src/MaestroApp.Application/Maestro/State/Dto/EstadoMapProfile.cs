using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace MaestroApp.Maestro.State.Dto
{
    public class EstadoMapProfile: Profile
    {
        public EstadoMapProfile()
        {
            //             Estado
            CreateMap<Estado, EstadoListDto>();
            CreateMap<EstadoListDto, Estado>();

            //            Create Estado
            CreateMap<CrearEstadoInput, Estado>();
            CreateMap<Estado, CrearEstadoInput>();

            //            Edit Estado
            CreateMap<GetEstadoForEditOutput, Estado>();
            CreateMap<Estado, GetEstadoForEditOutput>();
        }
    }
}

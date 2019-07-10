using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace MaestroApp.Maestro.Travel.Dto
{
    public class ViajeMapProfile : Profile
    {
        public ViajeMapProfile()
        {
            //             Viaje
            CreateMap<Viaje, ViajeListDto>();
            CreateMap<ViajeListDto, Viaje>();

            //            Create Viaje
            CreateMap<CrearViajeInput, Viaje>();
            CreateMap<Viaje, CrearViajeInput>();

            //            Edit Viaje
            CreateMap<GetViajeForEditOutput, Viaje>();
            CreateMap<Viaje, GetViajeForEditOutput>();
        }
    }
}

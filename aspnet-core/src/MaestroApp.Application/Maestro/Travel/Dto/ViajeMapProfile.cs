using AutoMapper;
using MaestroApp.Maestro.Container;
using MaestroApp.Maestro.State;
using MaestroApp.Maestro.TravelContainer;
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

            //                Estado
            CreateMap<EstadoInViajeListDto, Estado>();
            CreateMap<Estado, EstadoInViajeListDto>();

            //           Add  Contenedor al viaje
            CreateMap<AddContenedorInput, ViajeContenedor>();
            CreateMap<ViajeContenedor, AddContenedorInput>();

            //          edit estado  Contenedor
            CreateMap<EditContenedorInput, Contenedor>();
            CreateMap<Contenedor, EditContenedorInput>();

        }
    }
}

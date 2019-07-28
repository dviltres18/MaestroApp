using AutoMapper;
using MaestroApp.Maestro.State;
using MaestroApp.Maestro.Travel;
using MaestroApp.Maestro.Travel.Dto;
using MaestroApp.Maestro.TravelContainer;
using System;
using System.Collections.Generic;
using System.Text;

namespace MaestroApp.Maestro.Container.Dto
{
    public class ContenedorMapProfile: Profile
    {
        public ContenedorMapProfile()
        {
            //             Contenedor
            CreateMap<Contenedor, ContenedorListDto>();
            CreateMap<ContenedorListDto, Contenedor>();

            //            Create Contenedor
            CreateMap<CrearContenedorInput, Contenedor>();
            CreateMap<Contenedor, CrearContenedorInput>();

            //            Edit Contenedor
            CreateMap<GetContenedorForEditOutput, Contenedor>();
            CreateMap<Contenedor, GetContenedorForEditOutput>();

            //                Estado
            CreateMap<EstadoInContenedorListDto, Estado>();
            CreateMap<Estado, EstadoInContenedorListDto>();

            //                Estado Viaje
            CreateMap<EstadoViajeListDto, Estado>();
            CreateMap<Estado, EstadoViajeListDto>();

            //                Viaje
            CreateMap<ViajeInContenedorListDto, Viaje>();
            CreateMap<Viaje, ViajeInContenedorListDto>();

            //            Viajes de los Contenedor
            CreateMap<ViajeContenedorListDto, ViajeContenedor>();
            CreateMap<ViajeContenedor, ViajeContenedorListDto>();

        }
    }
}

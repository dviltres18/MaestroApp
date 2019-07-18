using AutoMapper;
using MaestroApp.Maestro.State;
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

        }
    }
}

﻿using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Collections.Extensions;
using Abp.Domain.Repositories;
using Abp.Extensions;
using MaestroApp.Authorization;
using MaestroApp.Maestro.Container.Dto;
using MaestroApp.Maestro.TravelContainer;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaestroApp.Maestro.Container
{
    // Para poner permisos a una clase entera
    [AbpAuthorize(PermissionNames.Pages_Contenedor)]
    public class ContenedorAppService : MaestroAppAppServiceBase,IContenedorAppService
    {
        private readonly IRepository<Contenedor> _contenedorRepository;
        private readonly IRepository<ViajeContenedor> _viajeContenedorRepository;


        public ContenedorAppService(
            IRepository<Contenedor> contenedorRepository,
            IRepository<ViajeContenedor> viajeContenedorRepository
         )
        {
            _contenedorRepository = contenedorRepository;
            _viajeContenedorRepository = viajeContenedorRepository;
        }


        public ListResultDto<ContenedorListDto> GetContenedores(GetContenedorInput input)
        {
            var contenedores = _contenedorRepository
                 .GetAll()
                 .Include(c => c.Estado)
                 .WhereIf(!input.Filter.IsNullOrEmpty(),
                   c => c.Nombre.Contains(input.Filter))                
                 .OrderBy(c => c.Nombre)                
                 .ToList();

            return new ListResultDto<ContenedorListDto>(ObjectMapper.Map<List<ContenedorListDto>>(contenedores));
        }


        public async Task CrearContenedor(CrearContenedorInput input)
        {
            var contenedor = ObjectMapper.Map<Contenedor>(input);
            contenedor.EstadoId = 4;
            contenedor.CantidadViajes = 0;
            await _contenedorRepository.InsertAsync(contenedor);
        }

        public async Task DeleteContenedor(EntityDto input)
        {
            await _contenedorRepository.DeleteAsync(input.Id);
        }

        public async Task<GetContenedorForEditOutput> GetContenedorForEdit(GetContenedorForEditInput input)
        {
            var contenedor = await _contenedorRepository.GetAsync(input.Id);
            return ObjectMapper.Map<GetContenedorForEditOutput>(contenedor);
        }

        public async Task EditContenedor(EditContenedorInput input)
        {
            var contenedor = await _contenedorRepository.GetAsync(input.Id);
            contenedor.Nombre = input.Nombre;         
            contenedor.CantidadViajes = input.CantidadViajes;
            contenedor.EstadoId = input.EstadoId;


            await _contenedorRepository.UpdateAsync(contenedor);
        }

        public ListResultDto<ViajeContenedorListDto> GetViajesContenedores(GetViajeContenedorInput input)
        {
            var viajes = _viajeContenedorRepository
               .GetAll()             
               .Include(vc => vc.Viaje)
               .Include(vc => vc.Viaje.Estado)
               .Where(vc => vc.ContenedorId == input.Id)
               .ToList();

            return new ListResultDto<ViajeContenedorListDto>(ObjectMapper.Map<List<ViajeContenedorListDto>>(viajes));
        }

        
    }
}

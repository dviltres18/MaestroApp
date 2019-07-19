using Abp.Application.Services.Dto;
using Abp.Collections.Extensions;
using Abp.Domain.Repositories;
using Abp.Extensions;
using MaestroApp.Maestro.Container;
using MaestroApp.Maestro.Travel.Dto;
using MaestroApp.Maestro.TravelContainer;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaestroApp.Maestro.Travel
{
    public class ViajeAppService : MaestroAppAppServiceBase, IViajeAppService
    {
        private readonly IRepository<Viaje> _viajeRepository;
        private readonly IRepository<Contenedor> _contenedorRepository;
        private readonly IRepository<ViajeContenedor> _viajeContenedorRepository;


        public ViajeAppService(
            IRepository<Viaje> viajeRepository,
            IRepository<Contenedor> contenedorRepository,
             IRepository<ViajeContenedor> viajeContenedorRepository
        )
        {
            _viajeRepository = viajeRepository;
            _contenedorRepository = contenedorRepository;
            _viajeContenedorRepository = viajeContenedorRepository;
        }

        public ListResultDto<ViajeListDto> GetViajes(GetViajeInput input)
        {
            var viajes = _viajeRepository
                 .GetAll()
                 .Include(v => v.Estado)
                 .WhereIf(!input.Filter.IsNullOrEmpty(),
                   v => v.Destino.Contains(input.Filter))
                 .OrderBy(v => v.Destino)
                 .ToList();

            return new ListResultDto<ViajeListDto>(ObjectMapper.Map<List<ViajeListDto>>(viajes));
        }


        public async Task CrearViaje(CrearViajeInput input)
        {
            var viaje = ObjectMapper.Map<Viaje>(input);
            viaje.EstadoId = 1;
            await _viajeRepository.InsertAsync(viaje);
        }

        public async Task DeleteViaje(EntityDto input)
        {
            await _viajeRepository.DeleteAsync(input.Id);
        }

        public async Task<GetViajeForEditOutput> GetViajeForEdit(GetViajeForEditInput input)
        {
            var viaje = await _viajeRepository.GetAsync(input.Id);
            return ObjectMapper.Map<GetViajeForEditOutput>(viaje);
        }

        public async Task EditViaje(EditViajeInput input)
        {
            var viaje = await _viajeRepository.GetAsync(input.Id);
            viaje.Destino = input.Destino;         
            viaje.FechaInicio = input.FechaInicio;
            viaje.FechaFin = input.FechaFin;
            viaje.Responsable = input.Responsable;
            viaje.EstadoId = input.EstadoId;

            await _viajeRepository.UpdateAsync(viaje);
        }

        public ListResultDto<ContenedoresDispViajeListDto> GetContenedoresDispViajes(GetContenedoresViajeInput input)
        {
            var contenedores = _contenedorRepository
                .GetAll()
                .ToList();

            var list = new List<ContenedoresDispViajeListDto>();

            foreach (var item in contenedores)
            {
                var contenedor = _viajeContenedorRepository.FirstOrDefault(c => c.ViajeId == input.Id && c.ContenedorId == item.Id);

                if (contenedor == null)
                {
                    list.Add(new ContenedoresDispViajeListDto
                    {
                        Nombre = item.Nombre,                     
                        ContenedorId = item.Id,
                        EstadoId = item.EstadoId,
                        ViajeId = input.Id
                    });
                }
            }
            return new ListResultDto<ContenedoresDispViajeListDto>(list);
        }


        public ListResultDto<ContenedorInViajeListDto> GetContenedorViaje(GetContenedorViajeInput input)
        {
            var contenedores = _viajeContenedorRepository
                .GetAll()
                .Where(c => c.ViajeId == input.Id)
                .Include(c => c.Contenedor)
                .Select(c => c.Contenedor)
                .ToList();

            var list = new List<ContenedorInViajeListDto>();
            contenedores.ForEach(c => list.Add(new ContenedorInViajeListDto
            {
                Nombre = c.Nombre,               
                ContenedorId = c.Id,
                EstadoId = c.EstadoId,
                ViajeId = input.Id
            }));                       

            return new ListResultDto<ContenedorInViajeListDto>(list);
        }

    }
}

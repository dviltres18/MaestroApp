using Abp.Application.Services.Dto;
using Abp.Collections.Extensions;
using Abp.Domain.Repositories;
using Abp.Extensions;
using MaestroApp.Maestro.Travel.Dto;
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
      

        public ViajeAppService(IRepository<Viaje> viajeRepository)
        {
            _viajeRepository = viajeRepository;
        }

        public ListResultDto<ViajeListDto> GetViajes(GetViajeInput input)
        {
            var viajes = _viajeRepository
                 .GetAll()
                 .WhereIf(!input.Filter.IsNullOrEmpty(),
                   v => v.Destino.Contains(input.Filter))
                 .OrderBy(v => v.Destino)
                 .ToList();

            return new ListResultDto<ViajeListDto>(ObjectMapper.Map<List<ViajeListDto>>(viajes));
        }


        public async Task CrearViaje(CrearViajeInput input)
        {
            var viaje = ObjectMapper.Map<Viaje>(input);
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
       
    }
}

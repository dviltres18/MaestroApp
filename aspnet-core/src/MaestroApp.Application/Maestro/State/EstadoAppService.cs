using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using Abp.Collections.Extensions;
using Abp.Domain.Repositories;
using Abp.Extensions;
using Abp.Linq.Extensions;
using MaestroApp.Maestro.State.Dto;

namespace MaestroApp.Maestro.State
{
    public class EstadoAppService : MaestroAppAppServiceBase, IEstadoAppService
    {
        private readonly IRepository<Estado> _estadoRepository;


        public EstadoAppService(IRepository<Estado> estadoRepository)
        {
            _estadoRepository = estadoRepository;
        }

        public ListResultDto<EstadoListDto> GetEstados(GetEstadoInput input)
        {
            var estados = _estadoRepository
                 .GetAll()
                 .Where(
                  e => e.Nombre.Contains(input.Filter) ||
                  e.Tipo == input.Tipo)                            
                 .ToList();

            return new ListResultDto<EstadoListDto>(ObjectMapper.Map<List<EstadoListDto>>(estados));
        }


        public async Task CrearEstado(CrearEstadoInput input)
        {
            var estado = ObjectMapper.Map<Estado>(input);
            await _estadoRepository.InsertAsync(estado);
        }

        public async Task DeleteEstado(EntityDto input)
        {
            await _estadoRepository.DeleteAsync(input.Id);
        }

        public async Task<GetEstadoForEditOutput> GetEstadoForEdit(GetEstadoForEditInput input)
        {
            var estado = await _estadoRepository.GetAsync(input.Id);
            return ObjectMapper.Map<GetEstadoForEditOutput>(estado);
        }

        public async Task EditEstado(EditEstadoInput input)
        {
            var estado = await _estadoRepository.GetAsync(input.Id);
            estado.Nombre = input.Nombre;
            estado.Tipo = input.Tipo;
            
            await _estadoRepository.UpdateAsync(estado);
        }

        
    }
}

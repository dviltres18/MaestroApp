using Abp.Application.Services.Dto;
using Abp.Collections.Extensions;
using Abp.Domain.Repositories;
using Abp.Extensions;
using MaestroApp.Maestro.Container.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaestroApp.Maestro.Container
{
    public class ContenedorAppService : MaestroAppAppServiceBase, IContenedorAppService
    {
        private readonly IRepository<Contenedor> _contenedorRepository;


        public ContenedorAppService(IRepository<Contenedor> contenedorRepository)
        {
            _contenedorRepository = contenedorRepository;
        }

        public ListResultDto<ContenedorListDto> GetContenedores(GetContenedorInput input)
        {
            var contenedores = _contenedorRepository
                 .GetAll()               
                 .WhereIf(!input.Filter.IsNullOrEmpty(),
                   c => c.Nombre.Contains(input.Filter))
                 .OrderBy(c => c.Nombre)
                 .ThenBy(c => c.FechaCreacion)
                 .ToList();

            return new ListResultDto<ContenedorListDto>(ObjectMapper.Map<List<ContenedorListDto>>(contenedores));
        }


        public async Task CrearContenedor(CrearContenedorInput input)
        {
            var contenedor = ObjectMapper.Map<Contenedor>(input);
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
            contenedor.FechaCreacion = input.FechaCreacion;
            contenedor.CantidadViajes = input.CantidadViajes;


            await _contenedorRepository.UpdateAsync(contenedor);
        }
    }
}

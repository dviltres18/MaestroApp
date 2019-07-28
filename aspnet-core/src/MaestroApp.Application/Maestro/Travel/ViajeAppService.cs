using Abp.Application.Services.Dto;
using Abp.Collections.Extensions;
using Abp.Domain.Repositories;
using Abp.Extensions;
using Abp.Linq.Extensions;
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
                   v => v.Origen.Contains(input.Filter)                
                   )
                 .OrderBy(v => v.Origen)
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
            viaje.Origen = input.Origen;
            viaje.Destino = input.Destino;
            viaje.FechaInicio = input.FechaInicio;
            viaje.FechaFin = input.FechaFin;
            viaje.Responsable = input.Responsable;              

            await _viajeRepository.UpdateAsync(viaje);
        }

        public async Task CargarViaje(CargaViajeInput input) {

            var viaje = await _viajeRepository.GetAsync(input.Id);

            foreach (var item in input.ContenedoresSelec)
            {
                var contenedor = _viajeContenedorRepository.FirstOrDefault(cs => cs.ViajeId == input.Id && cs.ContenedorId == item.ContenedorId);
                if (contenedor == null)
                {
                    var viajecontenedor = ObjectMapper.Map<ViajeContenedor>(item);
                    await _viajeContenedorRepository.InsertAsync(viajecontenedor);

                    var conten = await _contenedorRepository.GetAsync(viajecontenedor.ContenedorId);

                    if (conten != null)
                    {
                        conten.EstadoId = 5;
                        await _contenedorRepository.UpdateAsync(conten);
                    }
                }
            }

            foreach (var item2 in input.ContenedoresDisponibles)
            {
                var cont = _viajeContenedorRepository.FirstOrDefault(cd => cd.ViajeId == input.Id && cd.ContenedorId == item2.ContenedorId);

                if (cont != null)
                {
                    await _viajeContenedorRepository.DeleteAsync(cont);

                    var contEliminado = await _contenedorRepository.GetAsync(cont.ContenedorId);
                    contEliminado.EstadoId = 4;
                    await _contenedorRepository.UpdateAsync(contEliminado);

                }

            }

        }

        public ListResultDto<ContenedoresDispViajeListDto> GetContenedoresDispViajes(GetContenedoresViajeInput input)
        {
            var contenedores = _contenedorRepository
                 .GetAll()
                 .Where(c => c.EstadoId == 4)
                 .ToList();


            var list = new List<ContenedoresDispViajeListDto>();

            foreach (var item in contenedores)
            {
                var contenedor = _viajeContenedorRepository.FirstOrDefault(vc => vc.ViajeId == input.Id && vc.ContenedorId == item.Id);

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
                ViajeId = input.Id,
                CantidadViajes = c.CantidadViajes
            }));

            return new ListResultDto<ContenedorInViajeListDto>(list);
        }

        public async Task IniciarViaje(IniciarViajeInput input)
        {
            var viaje = await _viajeRepository.GetAsync(input.Id);

            var contenedores = _viajeContenedorRepository
              .GetAll()
              .Where(c => c.ViajeId == viaje.Id)
              .ToList();

            foreach (var item in contenedores)
            {
                var cont = await _contenedorRepository.GetAsync(item.ContenedorId);
                if (cont != null)
                {                    
                    cont.EstadoId = 6;
                    await _contenedorRepository.UpdateAsync(cont);
                }

            }
            viaje.EstadoId = 2;
            await _viajeRepository.UpdateAsync(viaje);
        }



        public async Task FinalizarViaje(FinalizarViajeInput input)
        {
            var viaje = await _viajeRepository.GetAsync(input.Id);

            var contenedores = _viajeContenedorRepository
              .GetAll()
              .Where(c => c.ViajeId == viaje.Id)            
              .ToList();

            foreach (var item in contenedores)
            {
                var cont =  await _contenedorRepository.GetAsync(item.ContenedorId);
                if (cont != null)
                {                   
                    cont.CantidadViajes = cont.CantidadViajes+1;
                    cont.EstadoId = 4;

                    await _contenedorRepository.UpdateAsync(cont);
                }

            }
            viaje.EstadoId = 3;
            await _viajeRepository.UpdateAsync(viaje);
        }
    }
}

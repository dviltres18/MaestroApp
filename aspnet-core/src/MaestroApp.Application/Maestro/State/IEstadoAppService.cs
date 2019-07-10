using Abp.Application.Services;
using Abp.Application.Services.Dto;
using MaestroApp.Maestro.Container.Dto;
using MaestroApp.Maestro.State.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MaestroApp.Maestro.State
{
    public interface IEstadoAppService : IApplicationService
    {
        ListResultDto<EstadoListDto> GetEstados(GetEstadoInput input);

        Task CrearEstado(CrearEstadoInput input);

        Task DeleteEstado(EntityDto input);

        Task<GetEstadoForEditOutput> GetEstadoForEdit(GetEstadoForEditInput input);
    }
}

using Abp.Application.Services;
using Abp.Application.Services.Dto;
using MaestroApp.Maestro.Travel.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MaestroApp.Maestro.Travel
{
    public interface IViajeAppService : IApplicationService
    {
        ListResultDto<ViajeListDto> GetViajes(GetViajeInput input);

        Task CrearViaje(CrearViajeInput input);

        Task DeleteViaje(EntityDto input);

        Task<GetViajeForEditOutput> GetViajeForEdit(GetViajeForEditInput input);
    }
}

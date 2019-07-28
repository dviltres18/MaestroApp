using Abp.Application.Services;
using Abp.Application.Services.Dto;
using MaestroApp.Maestro.Container.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MaestroApp.Maestro.Container
{
    public interface IContenedorAppService : IApplicationService
    {

        ListResultDto<ContenedorListDto> GetContenedores(GetContenedorInput input);

        Task CrearContenedor(CrearContenedorInput input);

        Task DeleteContenedor(EntityDto input);

        Task<GetContenedorForEditOutput> GetContenedorForEdit(GetContenedorForEditInput input);

        ListResultDto<ViajeContenedorListDto> GetViajesContenedores(GetViajeContenedorInput input);
    }
}

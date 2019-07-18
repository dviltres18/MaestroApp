using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace MaestroApp.Maestro.Container.Dto
{
    public class PagedContenedorResultRequestDto : PagedResultRequestDto
    {
        public string Keyword { get; set; }
    }
}

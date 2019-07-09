using Microsoft.AspNetCore.Antiforgery;
using MaestroApp.Controllers;

namespace MaestroApp.Web.Host.Controllers
{
    public class AntiForgeryController : MaestroAppControllerBase
    {
        private readonly IAntiforgery _antiforgery;

        public AntiForgeryController(IAntiforgery antiforgery)
        {
            _antiforgery = antiforgery;
        }

        public void GetToken()
        {
            _antiforgery.SetCookieTokenAndHeader(HttpContext);
        }
    }
}

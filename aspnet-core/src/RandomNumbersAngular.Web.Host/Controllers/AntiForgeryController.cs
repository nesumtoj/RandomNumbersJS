using Microsoft.AspNetCore.Antiforgery;
using RandomNumbersAngular.Controllers;

namespace RandomNumbersAngular.Web.Host.Controllers
{
    public class AntiForgeryController : RandomNumbersAngularControllerBase
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

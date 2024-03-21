using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CryptoVue.Controllers
{
    [Authorize]
    public abstract class BaseController : Controller
    {
    }
}

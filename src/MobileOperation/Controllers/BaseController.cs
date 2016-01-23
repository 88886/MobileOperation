using Microsoft.AspNet.Mvc;
using MobileOperation.Models;

namespace MobileOperation.Controllers
{
    public class BaseController : BaseController<MOContext, User, string>
    {
    }
}

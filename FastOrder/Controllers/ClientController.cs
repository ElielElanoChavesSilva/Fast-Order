using Microsoft.AspNetCore.Mvc;

namespace FastOrder.Controllers
{
    public class ClientController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

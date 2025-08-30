using Microsoft.AspNetCore.Mvc;

namespace FastOrder.Controllers
{
    public class OrderController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

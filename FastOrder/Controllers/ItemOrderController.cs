using Microsoft.AspNetCore.Mvc;

namespace FastOrder.Controllers
{
    public class ItemOrderController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

using Microsoft.AspNetCore.Mvc;

namespace FastOrder.Controllers
{
    public class OrderController : BaseController
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

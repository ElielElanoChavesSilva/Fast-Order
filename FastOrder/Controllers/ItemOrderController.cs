using Microsoft.AspNetCore.Mvc;

namespace FastOrder.Controllers
{
    public class ItemOrderController : BaseController
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

using Microsoft.AspNetCore.Mvc;

namespace FastOrder.Controllers
{
    [Route("orders")]
    public class OrderController : BaseController
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

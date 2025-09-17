using Microsoft.AspNetCore.Mvc;

namespace FastOrder.Controllers
{
    public class ClientController : BaseController 
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

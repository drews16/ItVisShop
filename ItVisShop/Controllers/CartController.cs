using Microsoft.AspNetCore.Mvc;

namespace ItVisShop.Controllers
{
    public class CartController : Controller
    {
        [HttpGet]
        public IActionResult Cart()
        {
            return View();
        }
    }
}

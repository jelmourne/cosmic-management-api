using Microsoft.AspNetCore.Mvc;

namespace cosmic_management_api.Controllers {
    public class ProductionController : Controller {
        public IActionResult Index() {
            return View();
        }
    }
}

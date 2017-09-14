using System.Web.Mvc;

namespace UltraStock.Controllers
{
    public class ProductsController : Controller
    {
        // GET: Product
        public ActionResult Index()
        {
            return View("ProductPage");
        }
    }
}
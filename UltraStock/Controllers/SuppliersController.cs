using System.Web.Mvc;

namespace UltraStock.Controllers
{
    public class SuppliersController : Controller
    {
        // GET: Suppliers
        public ActionResult Index()
        {
            return View("SupplierPage");
        }
    }
}
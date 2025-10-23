using Microsoft.AspNetCore.Mvc;

namespace ManolaPharm.API.Controllers
{
    public class ExpenseController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

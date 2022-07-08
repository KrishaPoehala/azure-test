using Microsoft.AspNetCore.Mvc;

namespace dz3Binary.Controllers
{
    public class TasksContoroller : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Pizza.Context;
using Pizza.Models;

namespace Pizza.Areas.Admin.Controllers
{
    [Authorize]
    [Area("Admin")]
    public class SlideController : Controller
    {
        PizzaProjectContext db;
        public SlideController(PizzaProjectContext db) => this.db = db;
        [Route("slide")]
        public IActionResult Index()
        {

            return View(new SlideModel() { });
        }
    }
}

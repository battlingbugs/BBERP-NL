using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BBERP.Controllers
{
    [Authorize(Roles = Pages.MainMenu.CountryMaster.RoleName)]
    public class CountryMasterController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
    
}
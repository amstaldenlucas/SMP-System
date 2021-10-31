using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SMPSystem.Areas.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMPSystem.Areas.Web.Controllers
{
    [Authorize]
    [Area("Web")]
    public class UserProductionHistoryController : Controller
    {
        public IActionResult Index(int id)
        {
            // ProductionorderId
            return View();
        }
    }
}

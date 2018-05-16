using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Note.BLL;

namespace Note.MVC.Controllers
{
    public class JsController : Controller
    {
        private readonly UserBll _userBll;

        public JsController(UserBll userBll)
        {
            _userBll = userBll;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Test()
        {
            return View(_userBll.GetNonActiveUser());
        }
    }
}
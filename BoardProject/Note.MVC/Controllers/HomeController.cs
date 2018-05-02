using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Note.BLL;
using Note.Model;
using Note.MVC.Models;
using Note.ViewModel;

namespace Note.MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly NoticeBll _noticeBll;
        private readonly BoardBll _boardBll;

        public HomeController(NoticeBll noticeBll, BoardBll boardBll)
        {
            _noticeBll = noticeBll;
            _boardBll = boardBll;
        }
        
        [HttpGet]
        public IActionResult Index()
        {
            List<Notice> notice = _noticeBll.GetList();
            List<Board> board = _boardBll.GetList();
            var tuple = new ValueTuple<List<Notice>, List<Board>>(notice, board);

            return View(tuple);
        }
    }
}

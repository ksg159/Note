using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Note.BLL;
using Note.Model;
using Note.ViewModel;
using ReflectionIT.Mvc.Paging;

namespace Note.MVC.Controllers
{
    public class BoardController : Controller
    {
        private readonly IHostingEnvironment _environment;
        private readonly BoardBll _boardBll;
        private const int _pageSize = 5;

        public BoardController(BoardBll boardBll, IHostingEnvironment environment)
        {
            _boardBll = boardBll;
            _environment = environment;
        }

        public async Task<IActionResult> Index(int page = 1, string searchName = "")
        {
            if (string.IsNullOrEmpty(searchName))
            {
                var item = _boardBll.GetBoardTracking();
                var model = await PagingList.CreateAsync(item, _pageSize, page);
                return View(model);
            } else
            {
                var item = _boardBll.GetBoardTracking(searchName);
                var model = await PagingList.CreateAsync(item, _pageSize, page);
                return View(model);
            }

        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(AddBoardViewModel model)
        {
            if (ModelState.IsValid)
            {
                Board board = new Board();
                board.Title = model.Title;
                board.Content = model.Content;
                board.WriteDate = DateTime.Now;
                board.UserId = User.Identity.Name;
                board.ImageName = GetImageName(model.ImageName);

                if (_boardBll.SaveBoard(board))
                {
                    return Redirect("index");
                }
            }
            return View();
        }

        public IActionResult Detail(int boardNo)
        {
            return View(_boardBll.GetBoard(boardNo));
        }

        public IActionResult Edit(int boardNo)
        {
           return View(_boardBll.GetBoard(boardNo));
        }
        
        [HttpPost]
        public IActionResult Edit(EditBoardViewModel model)
        {
            if (ModelState.IsValid)
            {
                Board board = new Board();
                board.Title = model.Title;
                board.Content = model.Content;
                board.UserId = model.UserId;
                board.No = model.No;
                if (_boardBll.UpdateBoard(board))
                {
                    return Redirect("Index");
                }
            }
            return View();
        }

        public IActionResult Delete(int boardNo)
        {
            _boardBll.DeleteBoard(boardNo);
            return Redirect("Index");
        }

        [HttpPost, Route("board/upload")]
        public async Task<IActionResult> ImageUploadAsync(IFormFile file)
        {
            var path = Path.Combine(_environment.WebRootPath, @"images\boardImage"); 
            var fileFullName = file.FileName.Split('.');
            var fileName = $"{Guid.NewGuid()}.{fileFullName[1]}";

            using (var fileStream = new FileStream(Path.Combine(path, fileName), FileMode.Create))
            {
                await file.CopyToAsync(fileStream); //async를 쓰면 await는 짝임 비동기처리 웹사이트 병목현상 방지
            }
            return Ok(new { file = "/images/boardImage/" + fileName, success = true });  //자바스크립트에 전송할 URL
        }
        
        private string GetImageName(string str)
        {
            string[] _str = str.Split("/"); 
            return _str[3];
        }

    }
}
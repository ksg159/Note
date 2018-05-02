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
                var model = await PagingList<Board>.CreateAsync(item, 5, page);
                return View(model);
            } else
            {
                var item = _boardBll.GetBoardTracking(searchName);
                var model = await PagingList<Board>.CreateAsync(item, 5, page);
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

        // http://www.example.com/upload/ImageUpload/
        // http://www.example.com/api/upload
        [HttpPost, Route("board/upload")]
        public async Task<IActionResult> ImageUploadAsync(IFormFile file)
        {
            //# 이미지나 파일을 업로드 할 때 필요한 구성 

            //1. Path(경로) - 어디에다 저장할지
            var path = Path.Combine(_environment.WebRootPath, @"images\boardImage"); // @쓰면 이스케이프시퀸스인식안하고 string으로 인식
            //2. Name(이름) - DateTime저장된 시간별로(사람이 많이 없으면 괜찮으나 그게 아니라면..), GUID
            var fileFullName = file.FileName.Split('.');
            var fileName = $"{Guid.NewGuid()}.{fileFullName[1]}";
            //3. 확장자(Extension) - jpg, png, txt 등등..

            using (var fileStream = new FileStream(Path.Combine(path, fileName), FileMode.Create))
            {
                await file.CopyToAsync(fileStream); //async를 쓰면 await는 짝임 비동기처리 웹사이트 병목현상 방지
                //병목현상이 나타나게되면 다른 사용자도 웹사이트가 멈추는 현상 발생
            }
            return Ok(new { file = "/images/boardImage/" + fileName, success = true });  //자바스크립트에 전송할 URL

            //#URL 접근방식
            //ASP.NET - 호스명/ 까지 포함되어있어서 위와같이 라우트 해줌
            //JavaScript - 호스트명/이 안붙음
            // 그래서 /붙어줌
        }
        
        private string GetImageName(string str)
        {
            string[] _str = str.Split("/");
            return _str[3];
        }

    }
}
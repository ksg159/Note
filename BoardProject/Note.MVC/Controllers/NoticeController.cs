using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Note.BLL;
using Note.Model;
using Note.ViewModel;
using ReflectionIT.Mvc.Paging;

namespace Note.MVC.Controllers
{
    public class NoticeController : Controller
    {

        private readonly NoticeBll _noticeBll;
        

        public NoticeController(NoticeBll noticeBll)
        {
            _noticeBll = noticeBll;
          
        }

        public async Task<IActionResult> Index(int page = 1, string searchName = "")
        {
            
            if (string.IsNullOrEmpty(searchName))
            {
                var item = _noticeBll.GetNoticeTracking();
                var model = await PagingList.CreateAsync(item, 5, page);

                return View(model);
            } else
            {
                var item = _noticeBll.GetNoticeTracking(searchName);
                var model = await PagingList.CreateAsync(item, 5, page);

                return View(model);
            }
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(AddNoticeViewModel model)
        {
            if (ModelState.IsValid)
            {
                Notice notice = new Notice();
                notice.Title = model.Title;
                notice.Content = model.Content;
                notice.WriteDate = DateTime.Now;
                notice.Writer = User.Identity.Name;

                if (_noticeBll.SaveNotice(notice))
                {
                    return Redirect("Index");
                }
            }
            return View();
        }

        public IActionResult Detail(int noticeNo)
        {
            return View(_noticeBll.GetNotice(noticeNo));
        }

        public IActionResult Edit(int noticeNo)
        {
            return View(_noticeBll.GetNotice(noticeNo));
        }

        [HttpPost]
        public IActionResult Edit(EditNoticeViewModel model)
        {
            if(ModelState.IsValid)
            {
                Notice notice = new Notice();
                notice.Title = model.Title;
                notice.Content = model.Content;
                notice.No = model.No;

                if(_noticeBll.UpdateNotice(notice))
                {
                    return Redirect("Index");
                }
            }
            return View();
        }

        public IActionResult Delete(int noticeNo)
        {
            _noticeBll.DeleteNotice(noticeNo);
            return Redirect("Index");   
        }
    }
}
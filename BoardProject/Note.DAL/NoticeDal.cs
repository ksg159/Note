using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Note.IDAL;
using Note.Model;
using Note.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Note.DAL
{
    public class NoticeDal : INoticeDal
    {
        private readonly IConfiguration _configuration;

        public NoticeDal(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        /// <summary>
        /// 공지사항 리스트 출력
        /// </summary>
        /// <returns></returns>
        public List<Notice> GetList()
        {
            using (var db = new NoteDbContext(_configuration))
            {

                return db.Notices
                    .OrderByDescending(n => n.No)
                    .ToList();
            }
        }
        /// <summary>
        /// 공지사항 상세 출력
        /// </summary>
        public Notice GetNotice(int noticeNo)
        {
            using (var db = new NoteDbContext(_configuration))
            {
                var notice = db.Notices.FirstOrDefault(n => n.No.Equals(noticeNo));
                return notice;
            }
        }
        /// <summary>
        /// 공지사항 등록
        /// </summary>
        public bool SaveNotice(Notice notice)
        {
            using (var db = new NoteDbContext(_configuration))
            {
                db.Notices.Add(notice);
                if (db.SaveChanges() >= 1)
                {
                    return true;
                }
                return false;
            }
        }
        /// <summary>
        /// 공지사항 수정
        /// </summary>
        public bool UpdateNotice(Notice notice)
        {
            using (var db = new NoteDbContext(_configuration))
            {
                var _notice = db.Notices.First(n => n.No == notice.No);
                _notice.Title = notice.Title;
                _notice.Content = notice.Content;

                if (db.SaveChanges() >= 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public bool DeleteNotice(int noticeNo)
        {
            using (var db = new NoteDbContext(_configuration))
            {
                var _noticeNo = db.Notices.First(n => n.No == noticeNo);
                db.Notices.Remove(_noticeNo);

                if (db.SaveChanges() >= 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public IOrderedQueryable<Notice> GetNoticeTracking()
        {
            var db = new NoteDbContext(_configuration);
            var _notice = db.Notices.AsNoTracking().OrderByDescending(n => n.No);
            return _notice;
            
        }
    }
}

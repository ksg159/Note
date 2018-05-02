using Note.IDAL;
using Note.Model;
using Note.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Note.BLL
{
    public class NoticeBll
    {
        private readonly INoticeDal _noticeDal;

        public NoticeBll(INoticeDal noticeDal)
        {
            _noticeDal = noticeDal;
        }

        /// <summary>
        /// 공지사항 리스트 출력
        /// </summary>
        /// <returns></returns>
        public List<Notice> GetList()
        {
            return _noticeDal.GetList();
        }
        /// <summary>
        /// 공지사항 상세 출력
        /// </summary>
        public Notice GetNotice(int NoticeNo)
        {
            if(NoticeNo <= 0)
            {
                throw new ArgumentException();
            }
            return _noticeDal.GetNotice(NoticeNo);
        }
        /// <summary>
        /// 공지사항 등록
        /// </summary>
        public bool SaveNotice(Notice notice)
        {
            if(notice == null)
            {
                throw new ArgumentNullException();
            }
            return _noticeDal.SaveNotice(notice);
        }
        /// <summary>
        /// 공지사항 수정
        /// </summary>
        public bool UpdateNotice(Notice notice)
        {
            if (notice == null)
            {
                throw new ArgumentNullException();
            }
            return _noticeDal.UpdateNotice(notice);
        }
        /// <summary>
        /// 공지사항 삭제
        /// </summary>
        public bool DeleteNotice(int noticeNo)
        {
            if (noticeNo <= 0)
            {
                throw new ArgumentNullException();
            }
            return _noticeDal.DeleteNotice(noticeNo);
        }

        public IOrderedQueryable<Notice> GetNoticeTracking()
        {
            return _noticeDal.GetNoticeTracking(); 
        }

        public IOrderedQueryable<Notice> GetNoticeTracking(string searchName)
        {
            return _noticeDal.GetNoticeTracking(searchName);
        }
    }
}

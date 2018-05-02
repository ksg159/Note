using Note.Model;
using Note.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Note.IDAL
{
    public interface INoticeDal
    {

        /// <summary>
        /// 공지사항 리스트 출력
        /// </summary>
        /// <returns></returns>
        List<Notice> GetList();

        /// <summary>
        /// 공지사항 상세 출력
        /// </summary>
        Notice GetNotice(int noticeNo);
        /// <summary>
        /// 공지사항 등록
        /// </summary>
        bool SaveNotice(Notice model);
        /// <summary>
        /// 공지사항 수정
        /// </summary>
        bool UpdateNotice(Notice model);
        /// <summary>
        /// 공지사항 삭제
        /// </summary>
        bool DeleteNotice(int noticeNo);

        /// <summary>
        /// 페이징 리스트
        /// </summary>
        /// <returns></returns>
        IOrderedQueryable<Notice> GetNoticeTracking();

        IOrderedQueryable<Notice> GetNoticeTracking(string searchName);

    }
}

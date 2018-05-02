using Note.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Note.IDAL
{
    public interface IBoardDal
    {
        /// <summary>
        /// 글 리스트 출력
        /// </summary>
        /// <returns></returns>
        List<Board> GetList();
        /// <summary>
        /// 글 상세보기
        /// </summary>
        Board GetBoard(int boardNo);

        /// <summary>
        /// 글 저장
        /// </summary>
        bool SaveBoard(Board model);

        /// <summary>
        /// 글 수정
        /// </summary>
        bool UpdateBoard(Board model);

        /// <summary>
        /// 글 삭제
        /// </summary>
        bool DeleteBoard(int boardNo);

        IOrderedQueryable<Board> GetBoardTracking();

        IOrderedQueryable<Board> GetBoardTracking(string searchName);
    }
}

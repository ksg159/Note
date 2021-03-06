﻿using Note.IDAL;
using Note.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Note.BLL
{
    public class BoardBll
    {
        private readonly IBoardDal _boardDal;


        public BoardBll(IBoardDal boardDal)
        {
            _boardDal = boardDal;
        }

        public bool DeleteBoard(int boardNo)
        {
            if(boardNo <= 0)
            {
                throw new ArgumentNullException();
            }
            return _boardDal.DeleteBoard(boardNo);
        }

        public Board GetBoard(int boardNo)
        {
            if (boardNo <= 0)
            {
                throw new ArgumentNullException();
            }
            return _boardDal.GetBoard(boardNo);
        }

        public List<Board> GetList()
        {
            return _boardDal.GetList();
        }

        public bool SaveBoard(Board model)
        {
            if(model == null)
            {
                throw new ArgumentNullException();
            }
            return _boardDal.SaveBoard(model);
        }

        public bool UpdateBoard(Board model)
        {
            if (model == null)
            {
                throw new ArgumentNullException();
            }
            return _boardDal.UpdateBoard(model);
        }

        public IOrderedQueryable<Board> GetBoardTracking()
        {
            return _boardDal.GetBoardTracking();
        }

        public IOrderedQueryable<Board> GetBoardTracking(string searchName)
        {
            return _boardDal.GetBoardTracking(searchName);
        }
    }
}

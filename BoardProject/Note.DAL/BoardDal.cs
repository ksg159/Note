using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Note.IDAL;
using Note.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Note.DAL
{
    public class BoardDal : IBoardDal
    {
        private readonly IConfiguration _configuration;

        public BoardDal(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public bool DeleteBoard(int boardNo)
        {
            using (var db = new NoteDbContext(_configuration))
            {
                db.Remove(GetBoard(boardNo));
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

        public Board GetBoard(int boardNo) //1개의 게시글을 받아온다
        {
            using (var db = new NoteDbContext(_configuration))
            {
                return db.Boards.FirstOrDefault(b => b.No == boardNo);
            }
        }

        public IOrderedQueryable<Board> GetBoardTracking() //페이징시 사용
        {
            var db = new NoteDbContext(_configuration);
            var _board = db.Boards.AsNoTracking().OrderByDescending(b => b.No);
            return _board;
        }

        public IOrderedQueryable<Board> GetBoardTracking(string searchName)
        {
            var db = new NoteDbContext(_configuration);
            return db.Boards.AsNoTracking().Where(b => b.Title.Contains(searchName) || b.Content.Contains(searchName)).OrderByDescending(b => b.No);
        }

        public List<Board> GetList()
        {
            using (var db = new NoteDbContext(_configuration))
            {

                return db.Boards.OrderByDescending(b => b.No).ToList();

            }

        }

        public bool SaveBoard(Board board)
        {
            using (var db = new NoteDbContext(_configuration))
            {
                db.Boards.Add(board);
                if (db.SaveChanges() >= 1)
                {
                    return true;
                }

                return false;
            }
        }

        public bool UpdateBoard(Board board)
        {
            using (var db = new NoteDbContext(_configuration))
            {
                var _board = db.Boards.First(b => b.No == board.No);
                _board.Title = board.Title;
                _board.Content = board.Content;

                if(db.SaveChanges() >= 1)
                {
                    return true;
                } else
                {
                   return false;
                }
            }
        }
    }
}

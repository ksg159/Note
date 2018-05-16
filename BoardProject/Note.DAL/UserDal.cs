using Microsoft.Extensions.Configuration;
using Note.IDAL;
using Note.Model;
using Note.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Note.DAL
{
    public class UserDal : IUserDal
    {
        private readonly IConfiguration _configuration;

        public UserDal(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public User GetUser(LoginViewModel model)
        {
            using (var db = new NoteDbContext(_configuration))
            {
                var user = db.Users.FirstOrDefault(u => u.UserId.Equals(model.UserId) && u.Password.Equals(model.Password));
                
                if (user != null)
                {
                    return user;
                }
                else
                {
                    return null;
                }
            }
        }

        public bool SaveUser(User model)
        {
            using (var db = new NoteDbContext(_configuration))
            {
                db.Users.Add(model);
                if (db.SaveChanges() >= 1)
                {
                    return true;
                }
                else
                {
                    throw new ArgumentException();
                }
            }

        }

        public List<User> GetNonActiveUser()
        {
            using (var db = new NoteDbContext(_configuration))
            {
                var data = (from user in db.Users
                            join boards in db.Boards
                            on user.UserId equals boards.UserId
                            where user.UserId == "ksg"
                            select new User { UserId = user.UserId, Name = user.Name }
                            ).ToList();

                return data;
            }
        }

    }
}

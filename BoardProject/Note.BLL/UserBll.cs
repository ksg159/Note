using Note.IDAL;
using Note.Model;
using Note.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace Note.BLL 
{
    public class UserBll 
    {
        private readonly IUserDal _userDal;

        public UserBll(IUserDal userDal)
        {
            _userDal = userDal;
        }

        public bool SaveUser(User model)
        {
            return _userDal.SaveUser(model);
        }

        public User GetUser(LoginViewModel model)
        {
            return _userDal.GetUser(model);
        }

        public List<User> GetNonActiveUser()
        {
            return _userDal.GetNonActiveUser();
        }
    }
}

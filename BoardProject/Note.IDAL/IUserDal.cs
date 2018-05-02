using Note.Model;
using Note.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace Note.IDAL
{
    public interface IUserDal
    {
        /// <summary>
        /// 회원가입
        /// </summary>
        bool SaveUser(User user);
        /// <summary>
        /// 로그인 
        /// </summary>
        User GetUser(LoginViewModel model);

    }
}

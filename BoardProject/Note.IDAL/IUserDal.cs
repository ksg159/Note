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

        List<User> GetNonActiveUser();

        /// <summary>
        /// 회원가입 시 아이디 유효성 체크
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        User GetUser(string id);
    }
}

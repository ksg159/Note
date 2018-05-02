using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Note.ViewModel
{
    public class LoginViewModel
    {
        /// <summary>
        /// 아이디
        /// </summary>
        [Required]
        public string UserId { get; set; }
       
        /// <summary>
        /// 비밀번호
        /// </summary>
        [Required]
        public string Password { get; set; }
    
    }
}

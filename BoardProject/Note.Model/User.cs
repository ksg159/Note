using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Note.Model
{
    public class User
    {
        public enum UserRole
        {
            Normal,
            SubManager,
            Admin
        }

        /// <summary>
        /// 아이디
        /// </summary>
        [Key]
        public string UserId { get; set; }
        /// <summary>
        /// 비밀번호
        /// </summary>
        [Required]
        public string Password { get; set; }
        /// <summary>
        /// 이메일 주소
        /// </summary>
        [Required]
        public string Email { get; set; }
        /// <summary>
        /// 사용자 이름
        /// </summary>
        [Required]
        public string Name { get; set; }
        /// <summary>
        /// 나이
        /// </summary>
        [Required]
        public string Age { get; set; }
        
        /// <summary>
        /// 사용자 등급 0 -> 일반회원, 1 -> 부관리자, 2 -> 관리자
        /// </summary>
        public UserRole Role { get; set; }
    }
}

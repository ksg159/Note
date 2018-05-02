using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Note.ViewModel
{
    public class EditNoticeViewModel
    {

        /// <summary>
        /// 공지사항 번호
        /// </summary>
        
        public int No { get; set; }
        /// <summary>
        /// 공지사항 제목
        /// </summary>
        [Required]
        public string Title { get; set; }
        /// <summary>
        /// 공지사항 내용
        /// </summary>
        [Required]
        public string Content { get; set; }
    }
}

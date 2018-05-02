using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Note.ViewModel
{
    public class AddBoardViewModel
    {
        /// <summary>
        /// 제목
        /// </summary>
        [Required]
        public string Title { get; set; }
        /// <summary>
        /// 글 내용
        /// </summary>
        [Required]
        public string Content { get; set; }
        /// <summary>
        /// 이미지 게시판 
        /// </summary>
        public string ImageName { get; set; }

    }
}

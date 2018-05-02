using System;
using System.ComponentModel.DataAnnotations;

namespace Note.ViewModel
{
    public class IndexNoteInfo
    {
        [Required]
        public int NoticeNo { get; set; }

        [Required]
        public string NoticeTitle { get; set; }

        [Required]
        public DateTime NoticeWriteDate { get; set; }

        [Required]
        public int BoardNo { get; set; }
        /// <summary>
        /// 작성자
        /// </summary>
        [Required]
        public string BoardUserId { get; set; }
        /// <summary>
        /// 글 제목
        /// </summary>
        [Required]
        public string BoardTitle { get; set; }
        /// <summary>
        /// 글 내용
        /// </summary>
        [Required]
        public string BoardContent { get; set; }


    }
}

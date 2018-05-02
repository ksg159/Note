using System;
using System.ComponentModel.DataAnnotations;

namespace Note.Model
{
    /// <summary>
    /// 공지사항
    /// </summary>
    public class Notice 
    {
        /// <summary>
        /// 공지사항 번호
        /// </summary>
        [Key]
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
        /// <summary>
        /// 작성 날짜
        /// </summary>
        [Required]
        public DateTime WriteDate { get; set; }
        /// <summary>
        /// 작성자
        /// </summary>
        [Required]
        public string Writer { get; set; }

    }
}

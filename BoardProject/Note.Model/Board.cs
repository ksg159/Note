using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Note.Model
{
    public class Board
    {
        /// <summary>
        /// 글 번호
        /// </summary>
        [Key]
        public int No { get; set; }
        /// <summary>
        /// 작성자
        /// </summary>
        [Required]
        public string UserId { get; set; }
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
        /// 작성 날짜
        /// </summary>
        [Required]
        public DateTime WriteDate { get; set; }

     

        [ForeignKey("UserId")]
        public virtual User User { get; set; }
        
        /// <summary>
        /// 이미지 게시판 
        /// </summary>
        public string ImageName { get; set; }
    }
}

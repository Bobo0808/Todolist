﻿using System.ComponentModel.DataAnnotations;

namespace TodoAPI.ViewModel
{
    public class UpdateTodoRequest
    {
        [Required]
        public int TodoId { get; set; }
        //public int UserId { get; set; }
        [Required(ErrorMessage = "請輸入你的主題")]
        public string Category { get; set; } = null!;
        [Required]
        public string Remark { get; set; } = null!;

        //public DateTime CreateDate { get; set; }
        public DateTime? ModifyDate { get; set; }
        public DateTime? ScaheduledDate { get; set; }
        public bool? IsCompleted { get; set; }
    }
}

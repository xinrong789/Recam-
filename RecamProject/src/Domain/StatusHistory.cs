using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using RecamProject.Enums;
namespace RecamProject.Domain
{
    /// <summary>
    /// 房源状态流转历史记录
    /// </summary>
    public class StatusHistory
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int ListingCaseId { get; set; }

        [Required]
        public string ChangedByUserId { get; set; }

        [Required]
        public ListcaseStatus FromStatus { get; set; }

        [Required]
        public ListcaseStatus ToStatus { get; set; }

        public DateTime ChangedAt { get; set; } = DateTime.UtcNow;

        // 导航属性
        [ForeignKey("ListingCaseId")]
        public ListingCase ListingCase { get; set; }

        [ForeignKey("ChangedByUserId")]
        public ApplicationUser ChangedByUser { get; set; }
       
    }
}

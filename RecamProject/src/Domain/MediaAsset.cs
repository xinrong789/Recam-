using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using RecamProject.Domain;

namespace RecamProject.Domain
{
    /// <summary>
    /// 房源媒体资源（图片、视频等）
    /// </summary>
    public class MediaAsset
    {
        /// <summary>
        /// 主键，媒体ID
        /// </summary>
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// 媒体类型（如 image/video）
        /// </summary>
        public string MediaType { get; set; }

        /// <summary>
        /// 媒体文件 URL
        /// </summary>
        public string MediaUrl { get; set; }

        /// <summary>
        /// 上传时间
        /// </summary>
        public DateTime UploadedAt { get; set; }

        /// <summary>
        /// 是否选中（例如在 UI 上展示）
        /// </summary>
        public bool IsSelect { get; set; }

        /// <summary>
        /// 是否是封面图
        /// </summary>
        public bool IsHero { get; set; }

        /// <summary>
        /// 外键：关联房源
        /// </summary>
        public int ListingCaseId { get; set; }

        /// <summary>
        /// 外键：上传用户
        /// </summary>
        public string UserId { get; set; }

        /// <summary>
        /// 是否已删除
        /// </summary>
        public bool IsDeleted { get; set; }

        /// <summary>
        /// 房源导航属性
        /// </summary>
        [ForeignKey("ListingCaseId")]
        public ListingCase ListingCase { get; set; }

        /// <summary>
        /// 用户导航属性（可选）
        /// </summary>
     [ForeignKey("UserId")]
      public ApplicationUser User { get; set; }  
    }
}

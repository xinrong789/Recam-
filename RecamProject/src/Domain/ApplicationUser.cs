using Microsoft.AspNetCore.Identity;
using System;

namespace RecamProject.Domain
{
    /// <summary>
    /// 用户实体，继承自 ASP.NET Core IdentityUser
    /// </summary>
    public class ApplicationUser : IdentityUser
    {
        /// <summary>
        /// 用户是否被逻辑删除
        /// </summary>
        public bool IsDeleted { get; set; } = false;

        /// <summary>
        /// 用户创建时间
        /// </summary>
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        /// <summary>
        /// 导航属性：一对一代理人信息（可选）
        /// </summary>
        public Agent Agent { get; set; }
        /// <summary>
        /// 导航属性：一对一摄影公司信息（可选）
        /// </summary>
        public PhotographyCompany PhotographyCompany { get; set; }

        /// <summary>
        /// 导航属性：该用户创建的 ListingCases
        /// </summary>
        public ICollection<ListingCase> ListingCases { get; set; }



        /// <summary>
        /// 导航属性：该用户上传的媒体资源
        /// </summary>
        public ICollection<MediaAsset> MediaAssets { get; set; }
        public ICollection<StatusHistory> ChangedStatusHistories { get; set; }


      

 
    }
}

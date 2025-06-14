using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RecamProject.Domain
{
    /// <summary>
    /// 联系人信息（与房源关联）
    /// </summary>
    public class CaseContact
    {
        /// <summary>
        /// 主键，联系人编号
        /// </summary>
        [Key]
        public int ContactId { get; set; }

        /// <summary>
        /// 联系人名
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// 联系人姓
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// 公司名
        /// </summary>
        public string CompanyName { get; set; }

        /// <summary>
        /// 头像或简介链接
        /// </summary>
        public string ProfileUrl { get; set; }

        /// <summary>
        /// 邮箱
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// 电话号码
        /// </summary>
        public string PhoneNumber { get; set; }

        /// <summary>
        /// 外键：关联房源
        /// </summary>
        public int ListingCaseId { get; set; }

        /// <summary>
        /// 房源导航属性
        /// </summary>
        [ForeignKey("ListingCaseId")]
        public ListingCase ListingCase { get; set; }
    }
}

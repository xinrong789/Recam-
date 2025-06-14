using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RecamProject.Domain
{
    /// <summary>
    /// 摄影公司实体，用于标识用户所属摄影机构
    /// </summary>
    public class PhotographyCompany
    {
        /// <summary>
        /// 主键，同时作为与 ApplicationUser 的外键（1:1）
        /// </summary>
        [Key, ForeignKey("UserId")]
        public string UserId { get; set; }

        /// <summary>
        /// 摄影公司名称
        /// </summary>
        public string PhotographyCompanyName { get; set; }

        /// <summary>
        /// 导航属性：摄影公司绑定的用户（1:1）
        /// </summary>
        public ApplicationUser User { get; set; }
        public ICollection<AgentPhotographyCompany> AgentPhotographyCompanies { get; set; }

    }
}

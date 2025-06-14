using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RecamProject.Domain
{
    /// <summary>
    /// 多对多关系：代理人与摄影公司的关联表
    /// </summary>
    public class AgentPhotographyCompany
    {
        public string AgentId { get; set; }

        public string PhotographyCompanyId { get; set; }

        // 导航属性
        
                public Agent Agent { get; set; }
            
        public PhotographyCompany PhotographyCompany { get; set; }
    }
}

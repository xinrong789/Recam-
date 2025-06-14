using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;


namespace RecamProject.Domain
{
    /// <summary>
    /// 多对多关系：代理人与房源的绑定中间表
    /// </summary>
    public class AgentListingCase
    {
        
        public string AgentId { get; set; }
        
        public int ListingCaseId { get; set; }

        // 导航属性
        public Agent Agent { get; set; }
        public ListingCase ListingCase { get; set; }
    }
}

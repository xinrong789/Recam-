using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace RecamProject.Domain
{
    public class Agent
    {
        [Key, ForeignKey("User")]
        public string Id { get; set; }

        public string AgentFirstName { get; set; }
        public string AgentLastName { get; set; }
        public string AvatarUrl { get; set; }
        public string CompanyName { get; set; }

       /// <summary>
    /// 导航属性：一对一用户
    /// </summary>
    public ApplicationUser User { get; set; }
    public ICollection<AgentListingCase> AgentListingCases { get; set; }


        public ICollection<AgentPhotographyCompany> AgentPhotographyCompanies { get; set; }
    }
}
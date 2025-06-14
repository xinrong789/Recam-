using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using RecamProject.Enums;

namespace RecamProject.Domain
{
    public class ListingCase
    {
        [Key]

        public int Id { get; set; }
        [Required]
        public string Title { get; set; }

        public string Description { get; set; }

        public string Street { get; set; }

        public string City { get; set; }

        public string State { get; set; }

        public int Postcode { get; set; }

        public decimal Longitude { get; set; }

        public decimal Latitude { get; set; }

        public double Price { get; set; }

        public int Bedrooms { get; set; }

        public int Bathrooms { get; set; }

        public int Garages { get; set; }

        public double FloorArea { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public bool IsDeleted { get; set; } = false;

        public PropertyType PropertyType { get; set; }

        public SaleCategory SaleCategory { get; set; }

        public ListcaseStatus ListcaseStatus { get; set; }

        [Required, ForeignKey("User")]
        public string UserId { get; set; }

        // 可选：如果你有 User 实体并设置关系
        public ApplicationUser User { get; set; }
        public ICollection<AgentListingCase> AgentListingCases { get; set; }
        public ICollection<MediaAsset> MediaAssets { get; set; }
        public ICollection<CaseContact> CaseContacts { get; set; }
        public ICollection<StatusHistory> StatusHistories { get; set; }

    }

   
}

using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;

namespace RecamProject.Domain.Mongo
{
    public class CaseHistory
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("listingCaseId")]
        public string ListingCaseId { get; set; }

        [BsonElement("changeType")]
        public string ChangeType { get; set; }

        [BsonElement("changedBy")]
        public ChangedByUser ChangedBy { get; set; }

        [BsonElement("changedAt")]
        public DateTime ChangedAt { get; set; }

        [BsonElement("details")]
        public ChangeDetails Details { get; set; }

        [BsonElement("notes")]
        public string Notes { get; set; }
    }

    public class ChangedByUser
    {
        public string UserId { get; set; }
        public string UserName { get; set; }
    }

    public class ChangeDetails
    {
        public string From { get; set; }
        public string To { get; set; }
    }
}

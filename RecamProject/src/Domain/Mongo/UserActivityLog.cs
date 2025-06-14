using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;

namespace RecamProject.Domain.Mongo
{
    public class UserActivityLog
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("userId")]
        public string UserId { get; set; }

        [BsonElement("userName")]
        public string UserName { get; set; }

        [BsonElement("action")]
        public string Action { get; set; }

        [BsonElement("target")]
        public TargetInfo Target { get; set; }

        [BsonElement("timestamp")]
        public DateTime Timestamp { get; set; }

        [BsonElement("ip")]
        public string IP { get; set; }

        [BsonElement("userAgent")]
        public string UserAgent { get; set; }

        [BsonElement("extraData")]
        public BsonDocument ExtraData { get; set; }  // 可选，结构灵活
    }

    public class TargetInfo
    {
        public string Type { get; set; }
        public string Id { get; set; }
    }
}

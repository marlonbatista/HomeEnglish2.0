using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace HomeEnglish.Domain.DomainContext.Queries
{
    public class GetStudentQueryResult
    {
        [BsonRepresentation(BsonType.ObjectId)]
        public String Uid { get; set; }
        public string Name { get; set; }
        public string Document { get; set; }
        public string Email { get; set; }
    }
}

using HomeEnglish.Domain.DomainContext.Interfaces;
using HomeEnglish.Domain.DomainContext.ValueObjects;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace HomeEnglish.Domain.DomainContext.Queries
{
    public class GetLessonQueryResult
    {
        public string Titulo { get; set; }
        public bool Watched { get ; set ; }
        public Video Video { get ; set ; }
        public DateTime StartClass { get ; set ; }
        public DateTime FinishClass { get ; set ; }
        public TimeSpan Duration { get ; set ; }

        [BsonRepresentation(BsonType.ObjectId)]
        public ObjectId UidStudent { get; }

        [BsonRepresentation(BsonType.ObjectId)]
        public ObjectId UidTeacher { get; }
        
        [BsonRepresentation(BsonType.ObjectId)]
        public ObjectId Uid { get ; set ; }
        public DateTime CreateDate { get ; set ; }
        public DateTime ModifyDate { get ; set ; }

    }
}

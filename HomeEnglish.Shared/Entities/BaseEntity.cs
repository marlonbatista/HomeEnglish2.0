using FluentValidator;
using HomeEnglish.Shared.Interfaces;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Runtime.Serialization;

namespace HomeEnglish.Shared.Entities
{
    [BsonIgnoreExtraElements]
    public abstract class BaseEntity<T>: Notifiable, IBaseEntity
    {
        
        // [DataMember]
        // public ObjectId _id { get; set; }

        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        [DataMember]
        public String Uid { get; set; }

        [DataMember]
        public DateTime CreateDate { get; set; }

        [DataMember]
        public DateTime ModifyDate { get; set; }

        public BaseEntity()
        {
            CreateDate = DateTime.Now;
        }

    }
}
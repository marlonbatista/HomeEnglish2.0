using System;
using System.Collections.Generic;
using HomeEnglish.Domain.DomainContext.Entitites;
using HomeEnglish.Domain.Entities;
using HomeEnglish.Shared.Interfaces;
using MongoDB.Bson;

namespace HomeEnglish.Domain.Interfaces
{
    public interface IProof : IBaseEntity
    {
        String UidStudent { get; set; }
        String UidTeacher { get; set; }
        Decimal Score { get; set; }

        DateTime Date { get;}
        Vocabulary Vocabulary { get; set; }
        IReadOnlyList<Question> Questions { get; }
        
        void CountScore();
    }
}
using System;
using System.Collections.Generic;
using HomeEnglish.Domain.DomainContext.Entitites;
using HomeEnglish.Domain.Entities;

namespace HomeEnglish.Domain.Interfaces
{
    public interface IProof
    {
        Guid Uid { get; set;}
        Guid UidStudent { get; set; }
        Guid UidTeacher { get; set; }
        Decimal Score { get; set; }

        DateTime Date { get;}
        Vocabulary Vocabulary { get; set; }
        IReadOnlyList<Question> Questions { get; }
        
        void CountScore();
    }
}
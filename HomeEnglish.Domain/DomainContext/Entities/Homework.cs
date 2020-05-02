using System;
using System.Collections.Generic;
using HomeEnglish.Shared.Entities;

namespace HomeEnglish.Domain.DomainContext.Entitites
{
    public class Homework : BaseEntity
    {
        public Guid UidTeacher { get; private set; }
        public Guid UidStudent { get; private set; }
        public IList<Question> Questions { get; private set; }
    }
}
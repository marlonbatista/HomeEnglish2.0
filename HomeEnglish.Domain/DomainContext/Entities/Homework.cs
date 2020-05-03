using System;
using System.Collections.Generic;
using System.Linq;
using HomeEnglish.Shared.Entities;

namespace HomeEnglish.Domain.DomainContext.Entitites
{
    public class Homework : BaseEntity
    {
        public string Translate { get; private set; }
        public Guid UidTeacher { get; private set; }
        public Guid UidStudent { get; private set; }
        public IList<Question> Questions { get; private set; }

        public Homework(Guid IdTeacher, Guid IdStudent)
        {
            this.UidTeacher = IdTeacher;
            this.UidStudent = IdStudent;
            this.Questions = new List<Question>();
        }
    }
}
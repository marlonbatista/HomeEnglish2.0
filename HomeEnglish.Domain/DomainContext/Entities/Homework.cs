using System;
using System.Collections.Generic;
using System.Linq;
using HomeEnglish.Domain.DomainContext.ValueObjects;
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

        public void AddQuestion(Question question)
        {
            this.Questions.Add(question);
        }

        public void RemoveQuestion(Question question)
        {
            this.Questions.Remove(question);
        }

        public void AnswerQuestion(Question question)
        {
            var awsore = Questions.FirstOrDefault(x => x.Uid == question.Uid);
            foreach (var item in awsore.Alternatives)
            {
                item.MarkFalse();
            }
            var mark = question.Alternatives.FirstOrDefault(aws => aws.Marked == true);
            var res = awsore.Alternatives.FirstOrDefault(e => e == mark);
            res = mark;
        }
    }


}
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
        public decimal Score { get; private set; }
        public decimal Weight { get; private set; }

        public Homework(Guid IdTeacher, Guid IdStudent)
        {
            this.UidTeacher = IdTeacher;
            this.UidStudent = IdStudent;
            this.Questions = new List<Question>();
            this.Score = 0.0M;
        }

        public void AddQuestion(Question question)
        {
            this.Questions.Add(question);
        }

        public void RemoveQuestion(Question question)
        {
            this.Questions.Remove(question);
        }

        public void AnswerQuestion(Guid idQuestion, Alternative alt)
        {
            var result = Questions.FirstOrDefault(x => x.Uid == idQuestion);
            var mark = result.Alternatives.FirstOrDefault(al => al.Text == alt.Text && al.Index == alt.Index);
            if(mark.Correct)
            {
                this.Score = 100 + result.Weight;
                Console.WriteLine($"Total Score {this.Score}");
            }

            Console.WriteLine("Option select is invalid");
            
        }
    }


}
using System;
using System.Collections.Generic;
using System.Linq;
using HomeEnglish.Domain.DomainContext.ValueObjects;
using HomeEnglish.Shared.Entities;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace HomeEnglish.Domain.DomainContext.Entitites
{
    public class Homework : BaseEntity<Homework>
    {
        public string Translate { get; private set; }
        
        [BsonRepresentation(BsonType.ObjectId)]
        public String UidTeacher { get; private set; }

        [BsonRepresentation(BsonType.ObjectId)]
        public String UidStudent { get; private set; }
        public IList<Question> Questions { get; private set; }

        public decimal Score { get; private set; }
        public decimal Weight { get; private set; }

        public Homework(string IdTeacher, string IdStudent)
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

        public void AnswerQuestion(string idQuestion, Alternative alt)
        {
            var result = Questions.FirstOrDefault(x => x.Uid == idQuestion);
            var mark = result.Alternatives.FirstOrDefault(al => al.Text == alt.Text && al.Number == alt.Number);
            if(!mark.Correct)
            {
                this.Score = 100 + result.Weight;
                Console.WriteLine($"Total Score {this.Score}");
            }

            Console.WriteLine("Option select is invalid");
            
        }

        public override string ToString()
        {
            return $"Id :{this.Uid}, Student:{this.UidStudent}, Teacher:{this.UidTeacher} ";
        }
    }


}
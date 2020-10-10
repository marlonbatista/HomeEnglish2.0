using System;
using System.Collections.Generic;
using System.Linq;
using HomeEnglish.Domain.DomainContext.Entitites;
using HomeEnglish.Domain.DomainContext.ValueObjects;
using HomeEnglish.Domain.Interfaces;
using HomeEnglish.Shared.Entities;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace HomeEnglish.Domain.Entities
{
    public class Proof : BaseEntity<Proof>, IProof
    {
        private List<Question> _questions;
        
        [BsonRepresentation(BsonType.ObjectId)]
        public String UidStudent { get; set; }

        [BsonRepresentation(BsonType.ObjectId)]
        public String UidTeacher { get; set; }
        public Decimal Score { get; set; }
        public Vocabulary Vocabulary { get; set; }
        public IReadOnlyList<Question> Questions => this._questions.ToArray();
        public DateTime Date { get; }
        public DateTime DateStart { get;  private set; }
        public DateTime DateFinish { get; private set; }

        public Proof(List<Question> questions,
                    String uidStudent,
                    String uidTeacher,
                    DateTime date,
                    Vocabulary vocabulary)
        {
            this._questions = questions;
            this.UidStudent = uidStudent;
            this.UidTeacher = uidTeacher;
            this.Date = date;
            this.Score = 0;
            this.Vocabulary = vocabulary;
        }

        public void CountScore()
        {
            int dateSituation = Function.CompareDate(DateFinish, DateStart);
            if (dateSituation < 0 || dateSituation == 0)
                throw new Exception("The test should be finish");

            foreach (var question in Questions)
            {
                foreach (var alt in question.Alternatives)
                {
                    if (alt.Marked && alt.Correct)
                        this.Score += question.Weight;
                }

            }
        }

        public void SetStartProofTime()
        {
            this.DateStart = DateTime.Now;
        }

        public void SetFinishProofTime()
        {
            this.DateFinish = DateTime.Now;
        }

        public override string ToString()
        {
            return $"Day {this.Date}, Student: {this.UidStudent}, Teacher:{this.UidTeacher}";
        }
    }
}
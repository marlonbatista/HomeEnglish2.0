using System;
using System.Collections.Generic;
using System.Linq;
using HomeEnglish.Domain.DomainContext.ValueObjects;
using HomeEnglish.Shared.Entities;
using MongoDB.Bson;

namespace HomeEnglish.Domain.DomainContext.Entitites
{
    public class Question : BaseEntity<Question>
    {
        public int Number { get; private set; }
        public string Text { get; private set; }
        public IList<Alternative> Alternatives { get; private set; }
        public decimal Weight { get; private set; }
        public Boolean valid { get; private set; }
        public Question(string text, int number, decimal weight)
        {
            this.Uid = ObjectId.GenerateNewId().ToString();
            this.Text = text;
            this.Number = number;
            this.Alternatives = new List<Alternative>();
            this.Weight = weight;
            this.valid = true;
        }
        public void AddAlternative(Alternative alternative)
        {
            this.Alternatives.Add(alternative);
        }

         public void AnwserQuestion(String uidQuestion, Alternative alternative)
        {
            Alternative alt = Alternatives.FirstOrDefault(al => al == alternative);
            alt.MarkTrue();
        }

        public void CancelCancel(String guidTeacher)
        {
            if(guidTeacher == null)
            {
                throw new Exception("Para anular a questão o código do professor deve ter um valor válido");
            }
            this.valid = false;
        }
    }
}
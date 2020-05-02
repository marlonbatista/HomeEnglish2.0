using System.Collections.Generic;
using HomeEnglish.Domain.DomainContext.ValueObjects;
using HomeEnglish.Shared.Entities;

namespace HomeEnglish.Domain.DomainContext.Entitites
{
    public class Question : BaseEntity
    {
        public int Index { get; private set; }
        public string Text { get; private set; }
        public IList<Alternative> Alternatives { get; private set; }

        public Question(string text, int index)
        {
            this.Text = text;
            this.Index = index;
            this.Alternatives = new List<Alternative>();
        }
        public void AddAlternative(Alternative alternative)
        {
            this.Alternatives.Add(alternative);
        }
    }
}
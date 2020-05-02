using FluentValidator;

namespace HomeEnglish.Domain.DomainContext.ValueObjects
{
    public class Alternative : Notifiable
    {
        public int Index { get; private set; }
        public string Text { get; private set; }
        public decimal Weight { get; private set; }

        public Alternative(int index, string text, decimal weight)
        {
            this.Index = index;
            this.Text = text;
            this.Weight = weight;
        }

        public string toString()
        {
            return this.Text;
        }
    }
} 
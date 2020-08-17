using FluentValidator;

namespace HomeEnglish.Domain.DomainContext.ValueObjects
{
    public class Alternative : Notifiable
    {
        public int Index { get; private set; }
        public string Text { get; private set; }
        public bool Correct { get; private set;}
        public bool Marked { get; private set; }

        public Alternative(int index, string text, bool correct)
        {
            this.Index = index;
            this.Text = text;
            this.Correct = correct;
            this.Marked = false;
        }

        public void MarkTrue()
        {
            this.Marked = true;
        }

        public void MarkFalse()
        {
            this.Marked  = false;
        }

        public string toString()
        {
            return this.Text;
        }
    }
} 
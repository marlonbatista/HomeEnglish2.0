using HomeEnglish.Shared.Entities;

namespace HomeEnglish.Domain.Entities
{
    public class Word : BaseEntity
    {
        public string Text { get; private set; }
        public string Translate { get; private set; }
        public string Description { get; private set; }

        public Word(string text, string translate, string description)
        {
            this.Text = text;
            this.Translate = translate;
            this.Description = description;
        }

        public void ChangeWord(string text, string translate, string description)
        {
            this.Text = text;
            this.Translate = translate; 
            this.Description = description;
        }

        public string toString()
        {
            return this.Text;
        }
    }
}
namespace HomeEnglish.Domain.ValueObjects
{
    public class Name
    {
        public string FirstName { get; private set; }
        public string Lastname { get; private set; }

        public Name(string firstName, string lastName)
        {
            this.FirstName = firstName;
            this.Lastname = lastName;

        }

        public string toString()
        {
            return $"{this.FirstName} {this.Lastname}";
        }
    }

}
using FluentValidator;
using HomeEnglish.Domain.ValueObjects;

namespace HomeEnglish.Domain.Entities
{
    public abstract class User : Person
    {
        public string Login { get; set; }
        public Email Email { get; set; }
        public string Password { get; set; }

        public string RecoverdPassword(string Password)
        {
            // todo implementar
            return "";
        }

        public string toString()
        {
            return base.ToString();
        }

        public string Log(string email, string password)
        {
            if(this.Email.Address != email || this.Password != password)
            {
                return $"Welcome to HomeEnglish, {this.Name.toString()} ";
            }

            return "Login or password incorret";
        }
    }
}
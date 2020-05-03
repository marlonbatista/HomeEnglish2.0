using FluentValidator;
using HomeEnglish.Domain.ValueObjects;

namespace HomeEnglish.Domain.Entities
{
    public abstract class User : Person
    {
        public string Login { get; set; }
        public Email Email { get; set; }
        public string Password { get; set; }

        public string RecoverPassword(Email email,string Password)
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
            // Check email and password exists
            if(this.Email.Address != email || this.Password != password)
            {
                return $"Welcome to HomeEnglish, {this.Name.toString()} ";
            }
            
            // Return message

            return "Login or password incorret";
        }
    }
}
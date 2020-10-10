using FluentValidator;
using HomeEnglish.Domain.ValueObjects;
using HomeEnglish.Shared.Entities;

namespace HomeEnglish.Domain.Entities
{
    public abstract class User : Person
    {
        public string Login { get; set; }
        public Email Email { get; set; }
        public string Password { get; private set; }

        public string RecoverPassword(Email email,string Password)
        {
            // todo implementar
            return "";
        }

        protected void changePassword(string newPassword)
        {
            Password = Function.EncodeHash(newPassword);
        }

        public override string ToString()
        {
            return base.ToString();
        }

        public string Log(string email, string password)
        {
            // Check email and password exists
            if(this.Email.Address != email || this.Password != password)
            {
                return $"Welcome to HomeEnglish, {Name.ToString()} ";
            }
            
            // Return message

            return "Login or password incorret";
        }
    }
}
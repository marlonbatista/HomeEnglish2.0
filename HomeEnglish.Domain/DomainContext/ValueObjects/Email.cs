using FluentValidator;
using FluentValidator.Validation;

namespace HomeEnglish.Domain.ValueObjects
{
    public class Email : Notifiable
    {
        public string Address { get; private set; }

        public Email(string address)
        {
            this.Address = address;

            AddNotifications(new ValidationContract()
                .IsEmail(this.Address, nameof(this.Address), "the e-mail address is not valid")
            );
        }

        public override string ToString()
        {
            return Address;
        }
    }
}
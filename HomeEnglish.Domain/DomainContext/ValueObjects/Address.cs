using FluentValidator;
using FluentValidator.Validation;

namespace HomeEnglish.Domain.ValueObjects
{
    public class Address : Notifiable
    {
        public string Street { get; private set; }
        public string Number { get; private set; }
        public string City { get; private set; }
        public string State { get; private set; }
        public string Country { get; private set; }
        public string ZipCode { get; private set; }
        public string Neightborhood { get; private set; }

        public Address(
            string street, 
            string number, 
            string city, 
            string state,
            string country,
            string zipcode, 
            string neightborhood)
        {
            this.Street = street;
            this.Number = number;
            this.City = city;
            this.State = state;
            this.Country = country;
            this.ZipCode = zipcode;
            this.Neightborhood = neightborhood;

            AddNotifications(new  ValidationContract()
                .HasMinLen(this.Street, 2, nameof(this.Street), "the Street should be bigger than 2 character")
                .HasMaxLen(this.Street, 40, nameof(this.Street), "the street should be less than 41 characteres")
                .HasMinLen(this.Number, 2, nameof(this.Number), "the Number should be bigger than 0 character")
                .HasMaxLen(this.Number, 5, nameof(this.Number), "the Number should be less than 5 characteres")
                .HasMinLen(this.City, 2, nameof(this.City), "the City name should be bigger than 2 character")
                .HasMaxLen(this.City, 20, nameof(this.City), "the City name should be less than 21 characteres")
                .HasMinLen(this.State, 0, nameof(this.State), "the State name should be bigger than 0 character")
                .HasMaxLen(this.State, 2, nameof(this.State), "the State name should be less than 3 characteres")
                .HasMinLen(this.Country, 2, nameof(this.Country), "the Country name should be bigger than 2 character")
                .HasMaxLen(this.Country, 25, nameof(this.Country), "the Country name should be less than 26 characteres")
                .HasMinLen(this.ZipCode, 0, nameof(this.Country), "the ZipCode should be bigger than 2 character")
                .HasMaxLen(this.ZipCode, 8, nameof(this.Country), "the ZipCode should be less than 9 characteres")
                .HasMinLen(this.Neightborhood, 2, nameof(this.Neightborhood), "the Neightborhood name should be bigger than 2 character")
                .HasMaxLen(this.Neightborhood, 25, nameof(this.Neightborhood), "the Neightborhood name should be less than 26 characteres")
            );
        }

         public override string ToString()
        {
            return $"{Street}, {Number} - {City}/{State}"; 
        }
    }
}
using System;
using FluentValidator;
using FluentValidator.Validation;
using HomeEnglish.Domain.Enumns;
using HomeEnglish.Shared.Commands;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace HomeEnglish.Domain.DomainContext.Commands.Inputs
{
    public class CreateStudentCommand: Notifiable, ICommand
    {
        [BsonRepresentation(BsonType.ObjectId)]
        public string UidTeacher { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Document { get; set; }
        public string Celphone { get; set; }
        public string Phone { get; set; }
        public EnglishLevel EnglishLevel { get; set; }
        public string Email { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string PasswordConfirm { get; set; }
        public string Street { get; set; }
        public string Number { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string ZipCode { get; set; }
        public string Neightborhood { get; set; }

        public bool Valid()
        {
            AddNotifications(new ValidationContract()
                // .IsNotNull(UidTeacher, nameof(UidTeacher), "The teacher should be valid")
                .HasMinLen(FirstName, 2, nameof(FirstName), "The first name should be bigger than 2 characters")
                .HasMaxLen(FirstName, 20, nameof(FirstName), "The first name should be bigger than 2 characters")
                .HasMinLen(LastName, 2, nameof(LastName), "The last name should be bigger than 2 characters")
                .HasMaxLen(LastName, 20, nameof(LastName), "The last name should be bigger than 2 characters")
                .IsEmail(Email, "Email", "The E-mail is invalid")
                .IsNotNullOrEmpty(Document, nameof(Document), "The document not be null or Empty")
                .AreEquals(Document, 11, nameof(Document), "Document should be have 11 caracteres")
                .HasLen(Celphone, 11, nameof(Celphone), "The celphone number should be hava 11 numbers")
                .IsNotNullOrEmpty(Login, nameof(Login), "The login should not be empty or null")
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
            return IsValid;
        }
    }
}
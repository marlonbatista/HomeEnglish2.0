using System;
using HomeEnglish.Domain.Enumns;

namespace HomeEnglish.Domain.Commands
{
    public class CreateStudentCommand
    {
        public Guid UidTeacher { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Document { get; set; }
        public string Celphone { get; set; }
        public EnglishLevel EnglishLevel { get; set; }
        public string Email { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string PasswordConfirm { get; set; }
        public string Street { get; private set; }
        public string Number { get; private set; }
        public string City { get; private set; }
        public string State { get; private set; }
        public string Country { get; private set; }
        public string ZipCode { get; private set; }
        public string Neightborhood { get; private set; }
    }
}
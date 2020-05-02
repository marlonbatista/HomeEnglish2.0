using System;
using System.Collections.Generic;
using HomeEnglish.Domain.Commands;
using HomeEnglish.Domain.DomainContext.Entitites;
using HomeEnglish.Domain.Enumns;
using HomeEnglish.Domain.ValueObjects;

namespace HomeEnglish.Domain.Entities
{
    public class Student : User
    {
        public EnglishLevel EnglishLevel { get; private set; }
        public Vocabulary Vocabulary { get; private set; }
        public IList<Homework> Homeworks { get; private set; }

        public Student(CreateStudentCommand command)
        {
            this.Uid = Guid.NewGuid();
            this.Name = new Name(command.FirstName, command.LastName);
            this.Document = new Document(command.Document);
            this.Email = new Email(command.Email);
            this.Vocabulary = new Vocabulary(this.Uid);
            this.EnglishLevel = command.EnglishLevel;
            this.Address = new Address(
                                    command.Street,
                                    command.Number,
                                    command.City, 
                                    command.State,
                                    command.Country, 
                                    command.ZipCode, 
                                    command.Neightborhood);
        }
    }
}
using System.Collections.Generic;
using FluentValidator.Validation;
using HomeEnglish.Domain.DomainContext.Commands.Inputs;
using HomeEnglish.Domain.DomainContext.Entitites;
using HomeEnglish.Domain.Enumns;
using HomeEnglish.Domain.ValueObjects;
using HomeEnglish.Shared.Entities;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace HomeEnglish.Domain.Entities
{
    [BsonIgnoreExtraElements]
    public class Student : User
    {
        public EnglishLevel EnglishLevel { get; private set; }
        public Vocabulary Vocabulary { get; private set; }
        public IList<Homework> Homeworks { get; private set; }

        public Student(
            Name name, 
            Document document, 
            Email email,
            Address address,
            CreateStudentCommand command
            )
        {
            Uid = new ObjectId().ToString();
            Name = name;
            Document = document;
            Email = email;
            Vocabulary = new Vocabulary(Uid);
            Homeworks = new List<Homework>();
            EnglishLevel = command.EnglishLevel;
            Address = address;
            Login = command.Login;
            CelPhone = command.Celphone;
            Phone = command.Phone;
            changePassword(command.Password, command.PasswordConfirm);

            AddNotifications(new ValidationContract()
                .IsNotNullOrEmpty(command.UidTeacher, nameof(command.UidTeacher), "Please, to info a id teacher valid")
                .IsNotNullOrEmpty(Login, nameof(Login), "The Login can not be empty or null")
                .IsNotNullOrEmpty(command.Password, nameof(Password), "The password can not be empty or null")
                .IsNotNullOrEmpty(command.PasswordConfirm, nameof(Password), "The co-password can not be empty or null")
                .AreEquals(command.Password, command.PasswordConfirm, nameof(Password), "The password and co-password should be equals")
                .IsNotNullOrEmpty(CelPhone, nameof(CelPhone), "The number from celphone can not be empty or null")              
            );
        }

        public Student(
            Name name, 
            Document document, 
            Email email,
            Address address,
            UpdateStudentCommand command
            )
        {
            Name = name;
            Document = document;
            Email = email;
            Address = address;
            Login = command.Login;
            CelPhone = command.Celphone;
            Phone = command.Phone;

            AddNotifications(new ValidationContract()
                .IsNotNullOrEmpty(command.Uid, nameof(command.Uid), "Please set a student code valid")
                .IsNotNullOrEmpty(Login, nameof(Login), "The Login can not be empty or null")
                .IsNotNullOrEmpty(CelPhone, nameof(CelPhone), "The number from celphone can not be empty or null")              
            );
        }

        public void changePassword(string newPassword, string confirmPassword)
        {
            if (string.Equals(newPassword, confirmPassword))
            {
                changePassword(newPassword);
            }
        }
    }
}
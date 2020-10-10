using System;
using FluentValidator;
using FluentValidator.Validation;
using HomeEnglish.Domain.DomainContext.Queries;
using HomeEnglish.Domain.DomainContext.ValueObjects;
using HomeEnglish.Shared.Commands;
using MongoDB.Bson;

namespace HomeEnglish.Domain.DomainContext.Commands.Inputs
{
    public class CreateLessonCommand : Notifiable, ICommand
    {
        public string Titulo { get; set; }
        public bool Watched { get; set; }
        public Video Video { get; set; }
        public DateTime StartClass { get; set; }
        public DateTime FinishClass { get; set; }
        public TimeSpan Duration { get; set; }
        public String UidStudent { get; }
        public String UidTeacher { get; }
        public DateTime CreateDate { get; set; }
        public DateTime ModifyDate { get; set; }

        public bool Valid()
        {
            AddNotifications(new ValidationContract()
                .HasMinLen(Titulo, 3, "FirstName", "O nome deve conter pelo menos 3 caracteres")
                .HasMaxLen(Titulo, 40, "FirstName", "O nome deve conter no máximo 40 caracteres")
                .IsNotNullOrEmpty(UidStudent.ToString(), nameof(UidStudent), "O código do aluno deve ser válido") 
                .IsNotNullOrEmpty(UidTeacher.ToString(), nameof(UidTeacher), "O código do professor deve ser válido") 
            );
            return IsValid;
        }
    }
}
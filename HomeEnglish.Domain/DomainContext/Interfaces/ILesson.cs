using System;
using HomeEnglish.Domain.DomainContext.ValueObjects;
using HomeEnglish.Shared.Interfaces;
using MongoDB.Bson;

namespace HomeEnglish.Domain.DomainContext.Interfaces
{
    interface ILesson : IBaseEntity
    {
        String Titulo { get; }
        bool Watched { get; set; }
        Video Video { get; set; }
        DateTime StartClass { get; set; }
        DateTime FinishClass { get; set; }
        TimeSpan Duration { get; set; }
        String UidStudent { get; }
        String UidTeacher { get; }

        void AlterationDate(DateTime newDate);
        void AddStudent(String uidStudent);
        void AddVideo(Video video);
        void toStartClass();
        void toFinishClass();
    }
}

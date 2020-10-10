using HomeEnglish.Domain.DomainContext.Interfaces;
using HomeEnglish.Domain.DomainContext.ValueObjects;
using HomeEnglish.Shared.Entities;
using HomeEnglish.Shared.Interfaces;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace HomeEnglish.Domain.DomainContext.Entities
{
    public class Lesson : BaseEntity<Lesson>, ILesson
    {
        public string Titulo { get; private set; }
        public bool Watched { get; set; }
        public Video Video { get; set; }
        public TimeSpan Duration { get; set; }


        [BsonRepresentation(BsonType.ObjectId)]
        public String UidStudent { get; private set; }


        [BsonRepresentation(BsonType.ObjectId)]
        public String UidTeacher { get; private set; }
        
        public DateTime StartClass { get; set; }
        public DateTime FinishClass { get; set; }

        public Lesson(string titulo, bool watched, Video video, string uidStudent, string uidTeacher)
        {
            Uid = ObjectId.GenerateNewId().ToString();
            Titulo = titulo;
            Watched = watched;
            Video = video;
            UidStudent = uidStudent;
            UidTeacher = uidTeacher;
        }

        public void AddStudent(string uidStudent)
        {
            UidStudent = uidStudent;
        }

        public void AddVideo(Video video)
        {
            if (!video.IsValid)
            {
                throw new ArgumentException("The video is not valid");
            }
                Video = video;
        }

        public void AlterationDate(DateTime newDate)
        {
            
        }

        public void toStartClass()
        {
            this.StartClass = Function.GetDateTimeNow();
        }

        public void toFinishClass()
        {
            this.FinishClass = Function.GetDateTimeNow();
        }

        public void setDuration()
        {
            Duration = Function.SubtractDate(FinishClass, StartClass);
        }

        public override string ToString()
        {
            return $"Aula {Titulo}";
        }

        public void AddVideo(byte[] video)
        {
            throw new NotImplementedException();
        }
    }
}

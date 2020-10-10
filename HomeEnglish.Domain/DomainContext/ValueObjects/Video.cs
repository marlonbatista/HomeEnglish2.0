using FluentValidator;
using FluentValidator.Validation;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Text;

namespace HomeEnglish.Domain.DomainContext.ValueObjects
{
    public class Video : Notifiable
    {
        public ObjectId Uid { get; set; }
        public String Title { get; set; }
        public String Path { get; private set; }

        public Video(string titulo, string path)
        {
            Uid = ObjectId.GenerateNewId();
            Title = titulo;
            Path = path;

            AddNotifications(new ValidationContract()
                .HasMinLen(Title, 2, nameof(Title), "the Title should be bigger than 2 character")
                .HasMaxLen(Title, 40, nameof(Title), "the street should be less than 41 characteres")
                .IsNotNullOrEmpty(path, nameof(Path), "The path from video should be a path valid")
            );
        }

        public string ReturnPathVideo()
        {
            return Path;
        }

        public override string ToString()
        {
            return Title.ToString() ;
        }
    }
}

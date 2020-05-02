using System;
using HomeEnglish.Domain.ValueObjects;
using HomeEnglish.Shared.Entities;

namespace HomeEnglish.Domain.Entities
{
    public abstract class Person : BaseEntity
    {
        public Name Name { get; set; }
        public DateTime Birthday { get; set; }
        public Document Document { get; set; }
        public string Phone { get; set; }
        public string CelPhone { get; set; }
        public Address Address { get; set; }

        // public void ChangeName(string firstname, string lastname)
        // {
        //     this.Name = $"{firstname} {lastname}";
        // }

        public void ChangeCelPhone(string number)
        {
            this.CelPhone = number;
        }
    }
}
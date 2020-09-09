using System;

namespace HomeEnglish.Shared.Entities
{
    public abstract class BaseEntity<T>
    {
        public Guid Uid { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime AlterationDate { get; set; }

    }
}
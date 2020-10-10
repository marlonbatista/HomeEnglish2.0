using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Text;

namespace HomeEnglish.Domain.DomainContext.Repositories
{
    public interface IBaseRepository<T>
    {
        T GetById(String uid);
        List<T> GetAll();
        void Save(T command);
        void Update(T command);
        void Delete(String uid);
    }
}

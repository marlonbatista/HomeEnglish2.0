using HomeEnglish.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace HomeEnglish.Domain.DomainContext.Repositories
{
    public interface IStudentRepository : IBaseRepository<Student>
    {
        bool CheckDocument(string document);
        bool CheckEmail(string email);
    }
}

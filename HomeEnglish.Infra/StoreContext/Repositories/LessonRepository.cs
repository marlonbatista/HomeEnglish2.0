using HomeEnglish.Domain.DomainContext.Entities;
using HomeEnglish.Domain.DomainContext.Repositories;
using HomeEnglish.Infra.StoreContext.ConnectionDB;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;

namespace HomeEnglish.Infra.StoreContext.Repositories
{
    public class LessonRepository : ILessonRepository
    {
        private readonly HomeEnglishDataContext _context;

        public LessonRepository(HomeEnglishDataContext connection)
        {
            _context = connection;
        }
        public void Save(Lesson lesson)
        {
            var colecao = GetColletion();
            Console.WriteLine("Salvando Class");
            colecao.InsertOneAsync(lesson);
        }
        
        private void Update(Lesson lesson)
        {
            var colecao = GetColletion();
            var filter = Builders<Lesson>.Filter.Eq("Uid", lesson.Uid);
            var altearion = Builders<Lesson>.Update.Set("*", lesson);

            colecao.UpdateOne(filter, altearion);
        }
       
        private IMongoCollection<Lesson> GetColletion()
        {
            var database = _context.Connect();
            return database.GetCollection<Lesson>("Classes");
        }

        public IEnumerable<Lesson> Get()
        {
            throw new NotImplementedException();
        }

        public Lesson GetById(String uid)
        {
            throw new NotImplementedException();
        }

        public List<Lesson> GetAll()
        {
            var collection = GetColletion();
            var filter = Builders<Lesson>.Filter.Empty;
            var list = new List<Lesson>();
            list = (List<Lesson>)collection.Find(filter);
            return list;
        }

        public void Delete(String uid)
        {
            throw new NotImplementedException();
        }

        void IBaseRepository<Lesson>.Update(Lesson command)
        {
            throw new NotImplementedException();
        }
    }
}
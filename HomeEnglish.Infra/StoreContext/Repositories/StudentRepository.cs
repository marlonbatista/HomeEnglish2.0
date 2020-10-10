using HomeEnglish.Domain.DomainContext.Repositories;
using HomeEnglish.Domain.Entities;
using HomeEnglish.Infra.StoreContext.ConnectionDB;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;

namespace HomeEnglish.Infra.StoreContext.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        private readonly HomeEnglishDataContext _context;

        public StudentRepository(HomeEnglishDataContext context)
        {
            this._context = context;
        }

        public bool CheckDocument(string document)
        {
            var collection = GetColletion();
            var filter = Builders<Student>.Filter.Eq("Document", document);
            var doc = collection.Find<Student>(filter).FirstOrDefault();
            if (doc == null)
                return false;

            return true;
        }

        public bool CheckEmail(string address)
        {
            var collection = GetColletion();
            var filter = Builders<Student>.Filter.Eq("Email", address);
            var email = collection.Find<Student>(filter).FirstOrDefault();

            if (email == null)
                return false;

            return true;
        }

        public void Delete(string uid)
        {
            var collection = GetColletion();
            var filter = Builders<Student>.Filter.Eq("Uid", uid);
            collection.DeleteOne(filter);
        }

        public List<Student> GetAll()
        {
            var collection = GetColletion();
            var filter = Builders<Student>.Filter.Empty;
            var list = new List<Student>();
            list =  collection.Find(filter).ToList();
            return list;
        }

        public Student GetById(string uid)
        {
            var collection = GetColletion();
            var filter = Builders<Student>.Filter.Eq("Uid", new ObjectId(uid));
            return collection.Find(filter).FirstOrDefault();
        }

        public void Save(Student command)
        {
            var colecao = GetColletion();
            Console.WriteLine("Saving Student");
            colecao.InsertOne(command);
        }

        public void Update(Student student)
        {
            var collection = GetColletion();
            var filter = Builders<Student>.Filter.Eq("Uid", student.Uid);
            var options = new UpdateOptions();
            collection.ReplaceOneAsync(doc => doc.Uid == student.Uid, student);
        }

        public IMongoCollection<Student> GetColletion()
        {
            var database = _context.Connect();
            return database.GetCollection<Student>("Student");
        }
    }
}

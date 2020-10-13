using System;
using System.Collections.Generic;
using HomeEnglish.Domain.DomainContext.Entitites;
using HomeEnglish.Domain.DomainContext.ValueObjects;
using HomeEnglish.Domain.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace HomeEnglish.Tests
{
    [TestClass]
    public class ProofTest
    {
        [BsonRepresentation(BsonType.ObjectId)]
        private String _idStudent { get; set; }

        [BsonRepresentation(BsonType.ObjectId)]
        private String _idTeacher { get; set; }
        private Alternative _alternative { get; set; }
        private Question _question { get; set; }

        public ProofTest()
        {
            this._idStudent = ObjectId.GenerateNewId().ToString();
            this._idTeacher = ObjectId.GenerateNewId().ToString();
            this._question = CreateQuetion("Who is the first man in the holy bible?",1,10);
        }

        [TestMethod]
        public void ShouldReturn10Score()
        {
            Alternative alt = CreateAlternative(1,"Adam", true);
            Alternative alt2 = CreateAlternative(2,"Moises", false);
            Alternative alt3 = CreateAlternative(3,"Abraam", false);
            Alternative alt4 = CreateAlternative(4,"Joseph", false);

            this._question.AddAlternative(alt);
            this._question.AddAlternative(alt2);
            this._question.AddAlternative(alt3);
            this._question.AddAlternative(alt4);

            List<Question> list = new List<Question>();
            list.Add(this._question);

            Proof proof = new Proof(list, this._idStudent, this._idTeacher, DateTime.Now, null);
            proof.SetStartProofTime();
            proof.Questions[0].AnwserQuestion(proof.Questions[0].Uid, alt);
            proof.SetFinishProofTime();
            proof.CountScore();
            Assert.AreEqual(10, proof.Score);
               
        }

        [TestMethod]
        public void ShouldReturn0WhenNotMarkedAlternative()
        {
            Alternative alt = CreateAlternative(1, "Adam", true);
            Alternative alt2 = CreateAlternative(2, "Moises", false);
            Alternative alt3 = CreateAlternative(3, "Abraam", false);
            Alternative alt4 = CreateAlternative(4, "Joseph", false);

            this._question.AddAlternative(alt);
            this._question.AddAlternative(alt2);
            this._question.AddAlternative(alt3);
            this._question.AddAlternative(alt4);

            List<Question> list = new List<Question>();
            list.Add(this._question);

            Proof proof = new Proof(list, this._idStudent, this._idTeacher, DateTime.Now, null);
            proof.SetStartProofTime();
            proof.SetFinishProofTime();
            proof.CountScore();
            Assert.AreEqual(0, proof.Score);

        }

        public Question CreateQuetion(String message, int number, decimal value)
        {
            return new Question(message, number, value);
        }

        public Alternative CreateAlternative(int number, String text, Boolean correct)
        {
            return new Alternative(number, text, correct);
        }
    }
}

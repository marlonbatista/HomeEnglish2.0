using System;
using HomeEnglish.Domain.DomainContext.Entitites;
using HomeEnglish.Domain.DomainContext.ValueObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MongoDB.Bson;

namespace HomeEnglish.Tests
{
    [TestClass]
    public class HomeworkTest
    {
        private String _idStudent { get; set; }
        private String _idTeacher { get; set; }
        private Homework _homeWork { get; set; }

        public HomeworkTest()
        {
            this._idStudent = ObjectId.GenerateNewId().ToString();
            this._idTeacher = ObjectId.GenerateNewId().ToString();
            this._homeWork = new Homework(this._idTeacher, this._idStudent);
        }

        [TestMethod]
        public void ShouldReturnFalseAlternatives()
        {
            foreach (var question in this._homeWork.Questions)
            {
                foreach (var alternative in question.Alternatives)
                {
                    Assert.IsFalse(alternative.Marked);
                }
            }
        }

        [TestMethod]
        public void ShouldReturnTrueWhenMarktrueAlternative()
        {
            var question = new Question("How many cats are there on the tree?", 1, 10);
            var alternative1 = new Alternative(1, "1", false);
            var alternative2 = new Alternative(2, "2", true);
            var alternative3 = new Alternative(3, "3", false);

            question.AddAlternative(alternative1);
            question.AddAlternative(alternative2);
            question.AddAlternative(alternative3);

            question.Alternatives[1].MarkTrue();
            this._homeWork.AddQuestion(question);

            Assert.IsTrue(alternative2.Marked);
        }

        [TestMethod]
        public void ShouldBeScoringScoreWhenAnswerValid()
        {
            var question = new Question("How many cats are there on the tree?", 1, 10);
            var alternative1 = new Alternative(1, "1", true);
            var alternative2 = new Alternative(2, "2", false);
            var alternative3 = new Alternative(3, "3", false);

            question.AddAlternative(alternative1);
            question.AddAlternative(alternative2);
            question.AddAlternative(alternative3);

            question.Alternatives[0].MarkTrue();
            this._homeWork.AddQuestion(question);
            this._homeWork.AnswerQuestion(question.Uid, alternative1);
        }
    }
}

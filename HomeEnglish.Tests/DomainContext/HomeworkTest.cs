using System;
using HomeEnglish.Domain.DomainContext.Entitites;
using HomeEnglish.Domain.DomainContext.ValueObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HomeEnglish.Tests
{
    [TestClass]
    public class HomeworkTest
    {
        private Guid _idStudent { get; set; }
        private Guid _idTeacher { get; set; }
        private Homework _homeWork { get; set; }

        public HomeworkTest()
        {
            this._idStudent = Guid.NewGuid();
            this._idTeacher = Guid.NewGuid();
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
        public void ShouldReturnTrueWhenMarkAlternative()
        {
            var question = new Question("How many cats are there on the tree?", 1);
            var alternative1 = new Alternative(1, "1", 0, false);
            var alternative2 = new Alternative(2, "2", 2, true);
            var alternative3 = new Alternative(3, "3", 0, false);

            question.AddAlternative(alternative1);
            question.AddAlternative(alternative2);
            question.AddAlternative(alternative3);

            alternative2.MarkTrue();
            this._homeWork.AddQuestion(question);

            Assert.IsTrue(alternative2.Marked);
        }
    }
}
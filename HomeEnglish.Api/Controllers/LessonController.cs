using HomeEnglish.Domain.DomainContext.Commands.Inputs;
using HomeEnglish.Domain.DomainContext.Entities;
using HomeEnglish.Domain.DomainContext.Handlers;
using HomeEnglish.Domain.DomainContext.Repositories;
using HomeEnglish.Shared.Commands;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using System.Collections.Generic;

namespace HomeEnglish.Api.Controllers
{
    public class LessonController : Controller
    {
        private readonly ILessonRepository _repository;
        private readonly LessonHandler _handler;

        public LessonController(ILessonRepository repository, LessonHandler handler)
        {
            _repository = repository;
            _handler = handler;
        }

        [HttpGet]
        [Route("v1/lesson")]
        // [ResponseCache(Duration = 0)]
        public IEnumerable<Lesson> Get()
        {
            return _repository.GetAll();
        }

        [HttpPost]
        [Route("v1/lesson")]
        public ICommandResult Post([FromBody] CreateLessonCommand command)
        {
            var result = _handler.Handle(command);
            return result;
        }
    }
}
using HomeEnglish.Domain.DomainContext.Commands.Inputs;
using HomeEnglish.Domain.DomainContext.Commands.Outputs;
using HomeEnglish.Domain.DomainContext.Handlers;
using HomeEnglish.Domain.DomainContext.Queries;
using HomeEnglish.Domain.DomainContext.Repositories;
using HomeEnglish.Domain.Entities;
using HomeEnglish.Domain.StoreContext.CustomerCommands.Inputs;
using HomeEnglish.Shared.Commands;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HomeEnglish.Api.Controllers
{
    public class StudentController : Controller
    {
        private readonly IStudentRepository _repository;
        private readonly StudentHandler _handler;

        public StudentController(IStudentRepository repository, StudentHandler handler)
        {
            _repository = repository;
            _handler = handler;
        }

        [HttpGet]
        [Route("v1/students")]
        //[ResponseCache(Duration = 15)]
        public IEnumerable<GetStudentQueryResult> Get()
        {
            var listStudent = _repository.GetAll();
            var listCommand = new List<GetStudentQueryResult>();
            foreach(var item in listStudent)
            {
                var resultCommand = ConvertToStudentQuery(item);
                listCommand.Add(resultCommand);
            }
            return listCommand;
        }

        [HttpGet]
        [Route("v1/students/{id}")]
        public GetStudentQueryResult GetById(string id)
        {
            var student = _repository.GetById(id);
            return ConvertToStudentQuery(student);
        }


        [HttpPost]
        [Route("v1/students")]
        public ICommandResult Post([FromBody] CreateStudentCommand command)
        {
            var result = _handler.Handle(command);
            return result;
        }

        [HttpPatch]
        [Route("v1/students")]
        public ICommandResult Patch([FromBody] UpdateStudentCommand command)
        {
            var result = _handler.Handle(command);
            return result;
        }

        private GetStudentQueryResult ConvertToStudentQuery(Student std)
        {
            return new GetStudentQueryResult
            {
                Uid = std.Uid,
                Email = std.Email.ToString(),
                Document = std.Document.Number,
                Name = std.ToString()
            };
        }
    }
}

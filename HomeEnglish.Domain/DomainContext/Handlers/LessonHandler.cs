using FluentValidator;
using HomeEnglish.Domain.DomainContext.Commands.Inputs;
using HomeEnglish.Domain.DomainContext.Commands.Outputs;
using HomeEnglish.Domain.DomainContext.Entities;
using HomeEnglish.Domain.DomainContext.Repositories;
using HomeEnglish.Shared.Commands;

namespace HomeEnglish.Domain.DomainContext.Handlers
{
    public class LessonHandler :
    Notifiable,
    ICommandHandler<CreateLessonCommand>
    {
        private readonly ILessonRepository _repository;
        public LessonHandler(ILessonRepository  repository)
        {
            _repository = repository;
        }
        public ICommandResult Handle(CreateLessonCommand command)
        {
            var lesson = new Lesson(
                command.Titulo,
                command.Watched,
                command.Video,
                command.UidStudent,
                command.UidTeacher
                );
            
            if(Invalid)
                return new CommandResult(
                    false,
                    "Por favor, corrija os campos abaixo",
                    Notifications);

            _repository.Save(lesson);

            return new CommandResult(true, "Aula gravada com sucesso!", new 
            {
                Id = lesson.Uid,
                Data = lesson.CreateDate,
                Aluno = lesson.UidStudent,
                Professor = lesson.UidTeacher
            });
        }
    }
}
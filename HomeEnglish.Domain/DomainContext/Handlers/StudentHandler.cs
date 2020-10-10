using FluentValidator;
using HomeEnglish.Domain.DomainContext.Commands.Inputs;
using HomeEnglish.Domain.DomainContext.Commands.Outputs;
using HomeEnglish.Domain.DomainContext.Repositories;
using HomeEnglish.Domain.Entities;
using HomeEnglish.Domain.Services;
using HomeEnglish.Domain.ValueObjects;
using HomeEnglish.Shared.Commands;

namespace HomeEnglish.Domain.DomainContext.Handlers
{
    public class StudentHandler :
        Notifiable,
        ICommandHandler<CreateStudentCommand>
    {
        private readonly IStudentRepository _repository;

        private readonly IEmailService _emailService;

        public StudentHandler(IStudentRepository repository)
        {
            _repository = repository;
        }

        public ICommandResult Handle(CreateStudentCommand command)
        {
            // Verificar se o CPF já existe na base
            if (_repository.CheckDocument(command.Document))
                AddNotification("Document", "Este CPF já está em uso");

            // Verificar se o E-mail já existe na base
            if (_repository.CheckEmail(command.Email))
                AddNotification("Email", "Este E-mail já está em uso");
            
            // Criar os VOs
            var name = new Name(command.FirstName, command.LastName);
            var document = new Document(command.Document);
            var email = new Email(command.Email);

            var address = new Address(
                command.Street, 
                command.Number, 
                command.City,
                command.State,
                command.Country,
                command.ZipCode,
                command.Neightborhood);
            
            
            var student = new Student(name, document, email, address, command);

            AddNotifications(name.Notifications);
            AddNotifications(document.Notifications);
            AddNotifications(email.Notifications);
            AddNotifications(student.Notifications);
            
            if (Invalid)
                return new CommandResult(
                    false,
                    "Por favor, corrija os campos abaixo",
                    Notifications);

            _repository.Save(student);
            
            _emailService.Send(email.Address, "marlon.batista18@hotmail.com", "Bem vindo", "Seja bem vindo ao Home English!");

            return new CommandResult(true, "Bem vindo ao balta Store", new
            {
                Id = student.Uid,
                Name = name.ToString(),
                Email = email.Address
            });
        }

        public ICommandResult Handle(UpdateStudentCommand command) 
        {
            var name = new Name(command.FirstName, command.LastName);
            var document = new Document(command.Document);
            var email = new Email(command.Email);

            var address = new Address(
                command.Street, 
                command.Number, 
                command.City,
                command.State,
                command.Country,
                command.ZipCode,
                command.Neightborhood);
            
            
            var student = new Student(name, document, email, address, command);

            return new CommandResult(true, "All data was update", new
            {
                Id = student.Uid,
                Name = name.ToString(),
                Email = email.Address
            });
        }

    }
}

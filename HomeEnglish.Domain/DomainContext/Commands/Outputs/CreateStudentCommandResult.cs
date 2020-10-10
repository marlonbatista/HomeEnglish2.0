using System;

using FluentValidator;
using FluentValidator.Validation;
using HomeEnglish.Shared.Commands;

namespace HomeEnglish.Domain.StoreContext.CustomerCommands.Inputs
{
    public class CreateStudentCommandResult : ICommandResult
    {
        public CreateStudentCommandResult(bool success, string message, object data)
        {
            Success = success;
            Message = message;
            Data = data;
        }

        public bool Success { get; set; }
        public string Message { get; set; }
        public object Data { get; set; }
    }
}
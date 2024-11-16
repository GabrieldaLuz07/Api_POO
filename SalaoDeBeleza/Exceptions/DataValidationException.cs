using FluentValidation.Results;

namespace SalaoDeBeleza.Exceptions
{
    // Exception básica
    public class DataValidationException : Exception
    {
        public DataValidationException(string message) : base(message) { }
    }
}

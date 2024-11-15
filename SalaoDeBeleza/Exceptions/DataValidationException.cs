using FluentValidation.Results;

namespace SalaoDeBeleza.Exceptions
{
    public class DataValidationException : Exception
    {
        public DataValidationException(string message) : base(message) { }
    }
}

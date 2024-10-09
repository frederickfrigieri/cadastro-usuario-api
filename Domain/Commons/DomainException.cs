namespace Domain.Commons
{
    public class DomainException : Exception
    {
        public DomainException() : base("One or more errors have occurred in Business Roles")
        {
            ErrorMessage = string.Empty;
        }

        public DomainException(string message) : this()
        {
            ErrorMessage = message;
        }

        public string ErrorMessage { get; }
    }
}

namespace Domain.Commons
{
    public interface IBusinessRule
    {
        bool IsBroken();

        string Message { get; }
    }
}

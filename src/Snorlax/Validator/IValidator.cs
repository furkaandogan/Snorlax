namespace Snorlax.Validator
{
    public interface IValidator
    {
        ValidatorResult Valid(object obj);
    }
}
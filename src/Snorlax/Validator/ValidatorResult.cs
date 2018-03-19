using System.Collections.Generic;

namespace Snorlax.Validator
{
    public class ValidatorResult
    {
        public bool IsValid { get; set; }
        public ICollection<ErrorModel> Errors { get; set; }
        
        public static implicit operator bool(ValidatorResult validatorResult)
        {
            return validatorResult.IsValid;
        }
    }
}
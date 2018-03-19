using System.Collections.Generic;

namespace Snorlax
{
    public class ApiResponse
        : Result
    {
        public ICollection<ErrorModel> Errors { get; set; }

        public ApiResponse()
        {
            Set(false,"beklenmedik bir hata gerçekleşti.");
        }

        public void Error(Validator.ValidatorResult validatorResult)
        {
            Error("validate_error",validatorResult.Errors);
        }
        public void Error(string message=null,ICollection<ErrorModel> errors=null)
        {
            Set(false,message);
            this.Errors=errors;
        }
        public void Error(ErrorModel error){
            Error("validate_error",new List<ErrorModel>(){error});
        }
    }
    public class ApiResponse<T>
        : ApiResponse
        where T:class
    {
        public T Data { get; set; }

        public void Success(string message=null,T data=default(T))
        {
            Set(true,message);
            this.Data=data;
        }
    }
}
using System;

namespace Snorlax
{
    public abstract class Result
        : IResult
    {
        public bool IsOk { get; set; }
        public string Message { get; set; }

        public void Set(bool isOk,string message){
            this.IsOk=isOk;
            this.Message=message;
        }
        public void Success(string message){
            Set(true,message);
        }
        public void Error(string message){
            Set(false,message);
        }
         public static implicit operator bool(Result result)
        {
            return result.IsOk;
        }
        public void Error(Exception ex){
            Error(ex.Message);
        }
    }
}
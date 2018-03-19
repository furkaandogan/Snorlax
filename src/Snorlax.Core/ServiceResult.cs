using System;

namespace Snorlax.Core
{
    public class ServiceResult<T>
        : Result
    {
        public T Data { get; set; }

        public void Success(string message=null,T data=default(T))
        {
            Success(message);
            this.Data=data;
        }
        public void Error(string message,T data=default(T))
        {
            Error(message);
            this.Data=data;
        }
        public void Error(Exception ex,T data=default(T))
        {
            Error(ex);
            this.Data=data;
        }
    }
}
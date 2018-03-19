using System;
using System.Threading.Tasks;

namespace Snorlax.Utilities
{
    public abstract class BaseLogger
        : ILogger
    {
        public BaseLogger()
        {
            
        }

        public abstract Task WriteAsync(string message);
        public abstract Task WriteAsync(Exception ex);

        public string MessageFormat(string message)
        {
            return string.Format("{0} : {1}",DateTime.Now,message);
        }
    }
}
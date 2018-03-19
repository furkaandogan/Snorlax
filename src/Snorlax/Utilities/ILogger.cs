using System;
using System.Threading.Tasks;

namespace Snorlax.Utilities
{
    public interface ILogger
    {
        Task WriteAsync(string message);
        Task WriteAsync(Exception ex);
    }
}
using System;
using System.Threading.Tasks;

namespace Snorlax.Utilities
{
    public sealed class ConsoleLogger
        : BaseLogger
    {
        public ConsoleLogger()
            :base()
        {
        }

        public override async Task WriteAsync(string message)
        {
            Console.WriteLine(MessageFormat(message));
        }

        public override async Task WriteAsync(Exception ex)
        {
            await WriteAsync(ex.Message);
        }
    }
}
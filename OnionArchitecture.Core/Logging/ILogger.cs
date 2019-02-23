using System;

namespace OnionArchitecture.Core.Logging
{
    public interface ILogger
    {
        void Log(string message);
        void Log(Exception ex);
    }
}

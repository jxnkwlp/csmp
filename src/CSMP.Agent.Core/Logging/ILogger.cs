using System;
using System.Collections.Generic;
using System.Text;

namespace CSMP.Agent.Logging
{
    public interface ILogger
    {
        bool Enabled(LogLevel level);

        void Log(Exception ex, string message, params object[] args);
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace CSMP.Agent.Logging
{
    public class NullLogger : ILogger
    {
        public bool Enabled(LogLevel level)
        {
            return false;
        }

        public void Log(Exception ex, string message, params object[] args)
        {
        }
    }
}

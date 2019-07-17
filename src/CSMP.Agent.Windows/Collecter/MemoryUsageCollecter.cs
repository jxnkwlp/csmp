using CSMP.Agent.Collecter;
using System;
using System.Collections.Generic;
using System.Text;

namespace CSMP.Agent.Windows.Collecter
{
    public class MemoryUsageCollecter : IMemoryUsageCollecter
    {
        public string Name => "memory";

        public MemoryUsageResult GetSnapshot()
        {
            // TODO 
            return new MemoryUsageResult();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace CSMP.Agent.Collecter
{
    public interface ICollecter<TReturn> where TReturn : CollectionResult
    {
        string Name { get; }

        TReturn GetSnapshot();
    }
}

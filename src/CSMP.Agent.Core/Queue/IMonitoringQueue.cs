using CSMP.Agent.Collecter;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CSMP.Agent.Queue
{
    /// <summary> 
    /// </summary>
    public interface IMonitoringQueue
    {
        Task<List<CollectionResult>> PopAsync();

        Task PushAsync(IList<CollectionResult> result);
    }
}

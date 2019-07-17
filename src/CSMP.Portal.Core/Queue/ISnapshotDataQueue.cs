using CSMP.Portal.Domains;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CSMP.Portal.Queue
{
    /// <summary>
    ///  数据队列
    /// </summary>
    public interface ISnapshotDataQueue
    {
        Task PushAsync(Snapshot snapshot);

        Task<IList<Snapshot>> PopAsync(int max = 100);
    }
}

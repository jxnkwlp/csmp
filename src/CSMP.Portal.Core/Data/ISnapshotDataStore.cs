using CSMP.Portal.Domains;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CSMP.Portal.Data
{
    public interface ISnapshotDataStore
    {
        Task InsertAsync(IList<Snapshot> snapshots);

        Task<IList<Snapshot>> SearchAsync(string name, int offset, int maxCount, DateTime? insertTimeStart = null, DateTime? insertTimeEnd = null);

    }
}

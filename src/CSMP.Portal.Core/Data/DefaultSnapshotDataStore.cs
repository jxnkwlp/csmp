using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using CSMP.Portal.Domains;
using Passingwind.UnitOfWork;

namespace CSMP.Portal.Data
{
    public class DefaultSnapshotDataStore : ISnapshotDataStore
    {
        private readonly IUnitOfWork<AppDbContext> _unitOfWork;
        private readonly IRepository<Snapshot> _repository;

        public DefaultSnapshotDataStore(IRepository<Snapshot> repository, IUnitOfWork<AppDbContext> unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public async Task InsertAsync(IList<Snapshot> snapshots)
        {
            if (snapshots == null)
            {
                throw new ArgumentNullException(nameof(snapshots));
            }

            foreach (var snapshot in snapshots)
            {
                await _repository.InsertAsync(snapshot);
            }

            await _unitOfWork.SaveChangesAsync();
        }

        public Task<IList<Snapshot>> SearchAsync(string name, int offset, int maxCount, DateTime? insertTimeStart = null, DateTime? insertTimeEnd = null)
        {
            throw new NotImplementedException();
        }
    }
}

using DataAdapter.Sdk.Sql;
using DeviceManager.Shared.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static DeviceManager.Data.Internal.Procedures;

namespace DeviceManager.Data.Repositories
{
    public class DeviceRepository
    {
        private SqlAdapter _adapter;
        public DeviceRepository(SqlAdapter adapter)
        {
            _adapter = adapter;
        }
        public async Task<IEnumerable<DeviceModel>> FindAsync(CancellationToken cancellationToken)
        {
            return await _adapter.FindAsync<DeviceModel, dynamic>(Sites.GetSites, new { }, cancellationToken, commandType: System.Data.CommandType.StoredProcedure);
        }
    }
}

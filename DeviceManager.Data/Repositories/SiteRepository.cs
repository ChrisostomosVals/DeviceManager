using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using DataAdapter.Sdk.Sql;
using DeviceManager.Shared.Models;
using static DeviceManager.Data.Internal.Procedures;

namespace DeviceManager.Data.Repositories
{
    public class SiteRepository
    {
        private SqlAdapter _adapter;

        public SiteRepository(SqlAdapter adapter)
        {
            _adapter = adapter;
        }

        public async Task<IEnumerable<SiteModel>> FindAsync(CancellationToken cancellationToken)
        {
            return await _adapter.FindAsync<SiteModel, dynamic>(Sites.GetSites, new { }, cancellationToken, commandType: System.Data.CommandType.StoredProcedure);
        }

    }
}

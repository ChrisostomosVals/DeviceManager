using DeviceManager.Data.Repositories;
using DeviceManager.Shared.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DeviceManager.Cli.Commands
{
    public class GetAllCommand<T>
    {
        private readonly SiteRepository _siteRepository;
        public GetAllCommand(SiteRepository siteRepository = null)
        {
            _siteRepository = siteRepository;
        }

        public async Task<IEnumerable<SiteModel>> ExecuteAsync(T service, CancellationToken cancellationToken)
        {
            return await _siteRepository.FindAsync(cancellationToken);
        }
    }
}

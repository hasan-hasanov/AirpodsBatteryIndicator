using ABI.Core.Entities;
using ABI.Core.Queries;
using System.Threading;
using System.Threading.Tasks;

namespace ABI.Adapter.NamedPipe.Queries.GetAirpodsBatteryStatus
{
    public class GetAirpodsBatteryStatusQueryHandler : IQueryHandler<GetAirpodsBatteryStatusQuery, BatteryIndicator>
    {
        public Task<BatteryIndicator> HandleAsync(GetAirpodsBatteryStatusQuery query, CancellationToken cancellationToken = default)
        {
            throw new System.NotImplementedException();
        }
    }
}

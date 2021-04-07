using ABI.Common.Constants;
using ABI.Core.Entities;
using ABI.Core.Queries;
using Newtonsoft.Json;
using System;
using System.IO.Pipes;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ABI.Adapter.NamedPipe.Queries.GetAirpodsBatteryStatus
{
    public class GetAirpodsBatteryStatusQueryHandler : IQueryHandler<GetAirpodsBatteryStatusQuery, BatteryIndicator>
    {
        private readonly NamedPipeContext _context;

        public GetAirpodsBatteryStatusQueryHandler(NamedPipeContext context)
        {
            _context = context;
        }

        public async Task<BatteryIndicator> HandleAsync(GetAirpodsBatteryStatusQuery query, CancellationToken cancellationToken = default)
        {
            NamedPipeClientStream pipe = await _context.CreateNamedPipeAsync(cancellationToken);

            byte[] inBuffer = new byte[NamedPipeConstants.NamedPipeChunkLength];
            await pipe.ReadAsync(inBuffer.AsMemory(0, NamedPipeConstants.NamedPipeChunkLength), cancellationToken);

            string jsonMessage = Encoding.UTF8.GetString(inBuffer);
            BatteryIndicator airpodsBattery = JsonConvert.DeserializeObject<BatteryIndicator>(jsonMessage);

            return airpodsBattery;
        }
    }
}

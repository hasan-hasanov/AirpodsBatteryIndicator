using System;
using System.IO.Pipes;
using System.Threading;
using System.Threading.Tasks;

namespace ABI.Adapter.NamedPipe
{
    public class NamedPipeContext
    {
        private readonly Func<CancellationToken, Task<NamedPipeClientStream>> _createNamedPipe;

        private NamedPipeClientStream _namedPipe;

        public NamedPipeContext()
            : this(async cancellationToken =>
            {
                NamedPipeClientStream pipe = new(".", "airpods-service", PipeDirection.In);
                await pipe.ConnectAsync(cancellationToken);

                return pipe;
            })
        {
        }

        public NamedPipeContext(Func<CancellationToken, Task<NamedPipeClientStream>> createNamedPipe)
        {
            _createNamedPipe = createNamedPipe;
        }

        public virtual async Task<NamedPipeClientStream> CreateNamedPipeAsync(CancellationToken cancellationToken = default)
        {
            _namedPipe = _namedPipe ?? await _createNamedPipe(cancellationToken);

            if (!_namedPipe.IsConnected)
            {
                await _namedPipe.DisposeAsync();
                _namedPipe = null;

                _namedPipe = await _createNamedPipe(cancellationToken);
            }

            return _namedPipe;
        }
    }
}

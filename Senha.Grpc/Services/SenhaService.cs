using Grpc.Core;
using Senha.Grpc.Protos;

namespace Senha.Grpc.Services
{
    public class SenhaClienteService : SenhaService.SenhaServiceBase
    {
        private readonly ILogger<SenhaClienteService> _logger;

    }
}

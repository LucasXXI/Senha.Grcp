using AutoMapper;
using Grpc.Core;
using Senha.Grpc.Domain.Entities;
using Senha.Grpc.Protos;

namespace Senha.Grpc.Services
{
    public class SenhaClienteService : SenhaService.SenhaServiceBase
    {
        private readonly ILogger<SenhaClienteService> _logger;
        private readonly IMapper _mapper;

        public SenhaClienteService(ILogger<SenhaClienteService> logger, IMapper mapper)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public override Task<SenhaModel> GetSenha(GetSenhaRequest request, ServerCallContext context)
        {


            // var senhaModel = _mapper.Map<SenhaModel>();

            //  return senhaModel;
            return null;
        }    
    }
}

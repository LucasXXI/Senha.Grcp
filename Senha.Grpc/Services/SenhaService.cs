using AutoMapper;
using Grpc.Core;
using Senha.Grpc.Adapter.Mongo.Services;
using Senha.Grpc.Domain.Entities;
using Senha.Grpc.Mapper;
using Senha.Grpc.Protos;

namespace Senha.Grpc.Services
{
    public class SenhaClienteService : SenhaService.SenhaServiceBase
    {
        private readonly ILogger<SenhaClienteService> _logger;
        //private readonly IMapper _mapper;
        private readonly SenhaMongoService _mongoService;

        public SenhaClienteService(ILogger<SenhaClienteService> logger)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            //_mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public override async Task<SenhaModel> GetSenha(GetSenhaRequest request, ServerCallContext context)
        {
            SenhaClass senhaRetorno = await _mongoService.GetSenhaAsync(request.Id);

            if (senhaRetorno is null)
            {
               throw new ArgumentNullException(nameof(senhaRetorno));
            }

            //var senhaRetornoModel = _mapper.Map<SenhaModel>(senhaRetorno);
            return MappingMongo.MongoToProto(senhaRetorno);

        }

        public override async Task<SenhaModel> CreateSenha(CreateSenhaRequest request, ServerCallContext context)
        {

            var novaSenha = await _mongoService.CreateSenhaAsync(request.IdClienteRef);

            var novaSenhaReturn = MappingMongo.MongoToProto(novaSenha);

            return novaSenhaReturn;

            //var novaSenhaModel = _mapper.Map<SenhaModel>(novaSenha);

            //return novaSenhaModel;
 
        }
    }
}

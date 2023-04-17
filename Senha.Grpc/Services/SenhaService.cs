using AutoMapper;
using Grpc.Core;
using Senha.Grpc.Adapter.Mongo.NovaPasta;
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
        private readonly ISenhaMongoService _mongoService;

        public SenhaClienteService(ILogger<SenhaClienteService> logger, ISenhaMongoService mongoService)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _mongoService = mongoService;
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

            var a = MappingMongo.MongoToProto(novaSenha);

            return a;

            //var novaSenhaReturn = MappingMongo.MongoToProto(novaSenha);
            //var novaSenhaModel = _mapper.Map<SenhaModel>(novaSenha);

            //return novaSenhaModel;
 
        }

        public override async Task<SenhaModel> UpdateSenha(UpdateSenhaRequest request, ServerCallContext context)
        {
            SenhaClass senhaAtualizada2 = new SenhaClass
            {
                Id = request.Senha.Id,
                IdCliente = request.Senha.IdCliente,
                SenhaCliente = request.Senha.SenhaCliente,
                SenhaClienteCifrada = request.Senha.SenhaClienteCifrada,
                Status = Domain.Enums.ESenhaStatus.SENHA_INATIVA
            };

             await _mongoService.UpdateAsync(senhaAtualizada2);

            var retorno = MappingMongo.MongoToProto(senhaAtualizada2);

            return retorno;
        }

        public override async Task<DeleteSenhaResponse> DeleteSenha(DeleteSenhaRequest request, ServerCallContext context)
        {
            await _mongoService.RemoveAsync(request.Id);

            return null;
        }
    }
}
